using UnityEngine;
using System.Collections;

public class VehiculeMovements : MonoBehaviour
{
    public int numJoueur;
    public Animator AN;

    public bool estActif = false;

    // GRAVITE ET HAUTEUR
    public float forceAntiGrave;
    public float dynamicVelocityControler;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;
    private float _rigidbodyVelocityOnY;
    private float _hauteurReference;
    private float _hauteurVaisseau;
    private Ray myRayGlobalAltitude;
    private RaycastHit myRayCast;
    public Transform[] pointsInclinaison = new Transform[2];
    private float[] altitudePoints = new float[2];
    public int vitesseChuteLimite = 7;
    public int valeurVitesseAmortiChute = 1700;

    // NOMS DES INPUTS
    private string _horizontalAxis = "HorizontalJ";
    private string _verticalAxis = "VerticalJ";
    private string _boutonBoost = "Boost_J";

    // CONTROLE DIRECTION
    private float _horizontalInput;
    private float _verticalInput;

    // FORCES DE DEPLACEMENT
    public float _vitesseMax;
    public float fakeVitesseMultiplicator;
    public float _forceAvant;
    public float _forceArriere;
    public float _intensiteRotation;
    private float _directionToRotate = 0.0f;
    private float _retourDeForce = 0.0f;
    public float facteurDrift;
    private float facteurMouvement;

    //INFO RAYCAST
    private int layer = 1 << 8;
    private bool tic = true;

    // BOOST
    private float valBoost = 1.50f;
    public bool surZoneRechargeBoost;
    public float ticRateRechargeBoost;
    public float quantiteBoostRechargeParTic;
    private float timerRateRechargeBoost;
    private float boost;
    public float forceAddedWhenBoosting;
    private bool isBoosting;
    private bool isFirstImpulse;
    public float forceFirstImpulse;
    public float consomationBoostParTic;
    private float ticRateConsoBoost;
    private float timerRateConsoBoost;
    private int cptBoost = 0;

    // Events
    public delegate void MajVitesse(int numJoueur,float vitesse);
    public static event MajVitesse OnChangeVitesse;

    public delegate void MajBoost(int numJoueur, float boost);
    public static event MajBoost OnChangeBoost;

    // compteur utiles
    private int compteurRefreshVitesse = 0; // cadence 5

    // SYSTEM SON
    public AudioSource AS;
    public AudioSource ASImpact;
    public float ticRateSonsImpact;
    private float timerSonsImpact;
    private float valMinPitch = 0.5f;
    private float valMaxPitch = 1.0f;
    public AudioClip sonAcceleration;
    public AudioClip sonDecceleration;
    public AudioClip[] sonsImpacts = new AudioClip[2];
    public AudioClip sonEntreeBoost;

    // awake
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("rigidbody Vehicule non trouvé !");
        }
        //_hauteurReference = transform.position.y;
        // affectation des inputs selon le num joueur
        _horizontalAxis += numJoueur.ToString();
        _verticalAxis += numJoueur.ToString();
        _boutonBoost += numJoueur.ToString();
        _intensiteRotation = -_intensiteRotation;
        facteurMouvement = 1.0f;
        ticRateConsoBoost = 0.05f;
    }

    // Use this for initialization
    void Start()
    {
        myRayGlobalAltitude = new Ray(transform.position, transform.forward);
        Physics.Raycast(myRayGlobalAltitude, out myRayCast, Mathf.Infinity, layer);
        _hauteurReference = myRayCast.distance;
        // init de boost a zero et booleen a false
        surZoneRechargeBoost = false;
        boost = 100.0f;
        isBoosting = false;
        timerRateRechargeBoost = Time.time;
        timerRateConsoBoost = Time.time;
        timerSonsImpact = Time.time;
        isFirstImpulse = true;
    }

    // Update is called once per frame
    void Update()
    {

        GetInputs();
        

        Tourner();
        Inclinaison();

        if (++compteurRefreshVitesse > 2)
        {
            compteurRefreshVitesse = 0;

          
        }

        if (cptBoost>=1)
        {
            RemplirBoost();
        }

    }

    void FixedUpdate()
    {
        AvancerReculer();
        CorrectifHauteur();
    }

    private void CorrectifHauteur()
    {
        // force de contre gravité
        _rigidbody.AddForce(Vector3.up * forceAntiGrave * 9.81f, ForceMode.Force);
        _velocity = _rigidbody.velocity;

        _rigidbody.AddForce(Vector3.up * Mathf.Clamp((_hauteurReference + 1.5f) - _hauteurVaisseau, 0, 1000) * 9.81f * 6000f, ForceMode.Force);  // cette ligne a étée faite par lucas



        // correction hauteur
        _rigidbodyVelocityOnY = _velocity.y;
        _rigidbodyVelocityOnY = -_rigidbodyVelocityOnY;
        if (_rigidbodyVelocityOnY > vitesseChuteLimite)
        {
            _rigidbodyVelocityOnY *= dynamicVelocityControler;
            _rigidbody.AddForce(Vector3.up * _rigidbodyVelocityOnY / 2, ForceMode.Force);

            _rigidbodyVelocityOnY = (_hauteurReference - _hauteurVaisseau) * valeurVitesseAmortiChute; //valeur vitesse amorti
            _rigidbody.AddForce(Vector3.up * _rigidbodyVelocityOnY, ForceMode.Force);

            //clamp sur les cotés
            _velocity = transform.InverseTransformVector(_velocity);
            _velocity.x = Mathf.Clamp(_velocity.x, -facteurDrift, facteurDrift);
            _rigidbody.velocity = transform.TransformVector(_velocity);
        }
        else
        {
            _rigidbodyVelocityOnY *= dynamicVelocityControler;
            _rigidbody.AddForce(Vector3.up * _rigidbodyVelocityOnY, ForceMode.Force);

            _rigidbodyVelocityOnY = (_hauteurReference - _hauteurVaisseau) * 8000; //valeur vitesse amorti
            _rigidbody.AddForce(Vector3.up * _rigidbodyVelocityOnY, ForceMode.Force);

            //clamp sur les cotés
            _velocity = transform.InverseTransformVector(_velocity);
            _velocity.x = Mathf.Clamp(_velocity.x, -facteurDrift, facteurDrift);
            _rigidbody.velocity = transform.TransformVector(_velocity);
        }
    }

    private void GetInputs()
    {
        if (!estActif) return;

        if (Input.GetAxis(_horizontalAxis) > 0.1f)
        {
            _directionToRotate += 0.1f;
        }
        else if (Input.GetAxis(_horizontalAxis) < -0.1f)
        {
            _directionToRotate -= 0.1f;
        }
        else
        {
            if (_directionToRotate >= 0.1f)
            {
                _directionToRotate -= 0.1f;
            }
            else if(_directionToRotate <= - 0.1f)
            {
                _directionToRotate += 0.1f;
            }
        }
        _directionToRotate = Mathf.Min(Mathf.Max(_directionToRotate, -1.0f), 1.0f);
        if(_directionToRotate < 0.1f && _directionToRotate > -0.1f)
        {
            _directionToRotate = 0.0f;
        }
        AN.SetFloat("Turn",_directionToRotate);

        _verticalInput = Input.GetAxis(_verticalAxis);

        if (Input.GetButton(_boutonBoost))
        {
            isBoosting = UseBoost();
            AN.SetBool("Burst",isBoosting);

        }
        else if (Input.GetButtonUp(_boutonBoost))
        {
            isFirstImpulse = true;
            isBoosting = false;
            AN.SetBool("Burst", isBoosting);
            if (boost > 0.0f)
            ASImpact.PlayOneShot(sonDecceleration);

        }

    }

    private void AvancerReculer()
    {
        if (_verticalInput < 0)
        {
            facteurMouvement = 0.3f;
        }
        else
        {
            if (isBoosting)
            {
                facteurMouvement = valBoost;
            }
            else // avancer vitesse normal
            {
                facteurMouvement = 1.0f;
            }
        }

        AN.SetFloat("Speed",Mathf.Abs(_velocity.y)/_vitesseMax);
        if (OnChangeVitesse != null)
        {
            OnChangeVitesse(numJoueur, _velocity.y * fakeVitesseMultiplicator);
        }
        _rigidbody.AddForce(_verticalInput * transform.up * _forceAvant * facteurMouvement, ForceMode.Impulse);
        SetPitch();

    }

    private void Tourner()
    {
        _retourDeForce = _velocity.x / _vitesseMax;
        _retourDeForce = Mathf.Max(1.0f - _retourDeForce, 0.1f);
        transform.Rotate(Vector3.forward, _directionToRotate * _intensiteRotation * _retourDeForce);
    }

    private void Inclinaison()
    {
        if (tic)
        {
            // Altitude Globale
            myRayGlobalAltitude = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(myRayGlobalAltitude, out myRayCast, Mathf.Infinity, layer))
            {
                _hauteurVaisseau = myRayCast.distance;

                //// point avant
                //myRayGlobalAltitude = new Ray(pointsInclinaison[0].position, transform.forward);
                //Physics.Raycast(myRayGlobalAltitude, out myRayCast, Mathf.Infinity, layer);
                //altitudePoints[0] = myRayCast.distance;
                ////point arriere
                //myRayGlobalAltitude = new Ray(pointsInclinaison[1].position, transform.forward);
                //Physics.Raycast(myRayGlobalAltitude, out myRayCast, Mathf.Infinity, layer);
                //altitudePoints[1] = myRayCast.distance; 
            }
            else
            {
                _hauteurVaisseau = _hauteurReference;
            }
            tic = false;
        }
        else
        {
            tic = true;
        }
    }

    private void RemplirBoost()
    {
        if (boost >= 100.0f) return;
        if(Time.time - timerRateRechargeBoost >= ticRateRechargeBoost)
        {
            boost += quantiteBoostRechargeParTic;
            if (boost >= 100.0f) boost = 100.0f;
            timerRateRechargeBoost = Time.time;
        }

        if (OnChangeBoost != null)
        {
            OnChangeBoost(numJoueur, boost);
        }
    }

    private bool UseBoost()
    {
        if (boost <= 0.0f) return false;

        if(Time.time - timerRateConsoBoost > ticRateConsoBoost)
        {
            boost -= consomationBoostParTic;
            timerRateConsoBoost = Time.time;
            if (boost <= 0.0f) boost = 0.0f;

            if (OnChangeBoost != null)
            {
                OnChangeBoost(numJoueur, boost);
            }

            if (isFirstImpulse)
            {
                ASImpact.PlayOneShot(sonAcceleration);
                _rigidbody.AddForce(transform.up * forceFirstImpulse, ForceMode.Impulse);
                isFirstImpulse = false;
            }
            //Debug.Log("boost restant :" + boost);
        }
        return true;
    }

    private void SetPitch()
    {

        float pitchInter = (Mathf.Abs(_velocity.y) / _vitesseMax);
        AS.pitch = (valMinPitch + (pitchInter * 2));
    }

    // son impact
    void OnCollisionEnter(Collision collision)
    {
        if (Time.time - timerSonsImpact >= ticRateSonsImpact)
        {
            ASImpact.PlayOneShot(sonsImpacts[Random.Range(0, 1)], 0.3f);
            timerSonsImpact = Time.time;
        }
        
    }

    public void Activate(bool b)
    {
        estActif = b;
        if (!b)
        {
            _directionToRotate = 0.0f;
            _verticalInput = 0.0f;
            _horizontalInput = 0.0f;
        }
    }

    public void ZoneBoost (bool entrer)
    {
        int tmpValBoost = cptBoost;

        if (entrer)
        {
            cptBoost++;
        }
        else
        {
            cptBoost--;
        }

        if(tmpValBoost == 0 && cptBoost == 1)//activation boost
        {
            ASImpact.PlayOneShot(sonEntreeBoost,0.7f);
        }
   


    }

}