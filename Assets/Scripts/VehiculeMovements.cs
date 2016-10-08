using UnityEngine;
using System.Collections;

public class VehiculeMovements : MonoBehaviour
{
    public int numJoueur;

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

    // NOMS DES INPUTS
    private string _horizontalAxis = "HorizontalJ";
    private string _verticalAxis = "VerticalJ";

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

    //INFO RAYCAST
    private int layer = 1 << 8;
    private bool tic = true;

    // Events
    public delegate void MajVitesse(int numJoueur,float vitesse);
    public static event MajVitesse OnChangeVitesse;

    // compteur utiles
    private int compteurRefreshVitesse = 0; // cadence 5

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
        _intensiteRotation = -_intensiteRotation;

    }

    // Use this for initialization
    void Start()
    {
        myRayGlobalAltitude = new Ray(transform.position, transform.forward);
        Physics.Raycast(myRayGlobalAltitude, out myRayCast, Mathf.Infinity, layer);
        _hauteurReference = myRayCast.distance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _rigidbody.AddForce(Vector3.up * 2, ForceMode.VelocityChange);
        }
        GetInputs();
        AvancerReculer();
        Tourner();
        Inclinaison();

        if (++compteurRefreshVitesse > 5)
        {
            compteurRefreshVitesse = 0;
            if (OnChangeVitesse != null)
            {
                OnChangeVitesse(numJoueur, _velocity.y * fakeVitesseMultiplicator);
            }
        }
        

    }

    void FixedUpdate()
    {
        CorrectifHauteur();
    }

    private void CorrectifHauteur()
    {
        // force de contre gravité
        _rigidbody.AddForce(Vector3.up * forceAntiGrave * 9.81f, ForceMode.Force);
        _velocity = _rigidbody.velocity;

        // correction hauteur
        _rigidbodyVelocityOnY = _velocity.y;
        _rigidbodyVelocityOnY = -_rigidbodyVelocityOnY;
        _rigidbodyVelocityOnY *= dynamicVelocityControler;
        _rigidbody.AddForce(Vector3.up * _rigidbodyVelocityOnY, ForceMode.Force);

        _rigidbodyVelocityOnY = (_hauteurReference - _hauteurVaisseau) * 8000; //valeur vitesse amorti
        _rigidbody.AddForce(Vector3.up * _rigidbodyVelocityOnY, ForceMode.Force);

        //clamp sur les cotés
        _velocity = transform.InverseTransformVector(_velocity);
        _velocity.x = Mathf.Clamp(_velocity.x, -facteurDrift, facteurDrift);
        _rigidbody.velocity = transform.TransformVector(_velocity);
    }

    private void GetInputs()
    {
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
        _verticalInput = Input.GetAxis(_verticalAxis);
    }

    private void AvancerReculer()
    {
        _rigidbody.AddForce(_verticalInput * transform.up * _forceAvant, ForceMode.Impulse);
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
}