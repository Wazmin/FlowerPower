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

    // NOMS DES INPUTS
    private string _horizontalAxis = "HorizontalJ";
    private string _verticalAxis = "VerticalJ";

    // CONTROLE DIRECTION
    private float _horizontalInput;
    private float _verticalInput;

    // FORCES DE DEPLACEMENT
    public float _vitesseMax;
    public float _forceAvant;
    public float _forceArriere;
    public float _intensiteRotation;
    private float _directionToRotate = 0.0f;
    private float _retourDeForce = 0.0f;
    public float facteurDrift;

    // awake
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null)
        {
            Debug.LogError("rigidbody Vehicule non trouvé !");
        }
        _hauteurReference = transform.position.y;
        // affectation des inputs selon le num joueur
        _horizontalAxis += numJoueur.ToString();
        _verticalAxis += numJoueur.ToString();
        _intensiteRotation = -_intensiteRotation;
    }

    // Use this for initialization
    void Start()
    {

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

        _rigidbodyVelocityOnY = (_hauteurReference - transform.position.y) * 5000;
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

        _retourDeForce = _rigidbody.velocity.x / _vitesseMax;
        _retourDeForce = Mathf.Max(1.0f - _retourDeForce, 0.1f);
        transform.Rotate(Vector3.forward, _directionToRotate * _intensiteRotation * _retourDeForce);
    }
}