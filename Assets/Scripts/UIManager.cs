using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


struct CursorDmg
{
    public float _timeToLive;
    public GameObject _anchorCursor;
}

public class UIManager : MonoBehaviour
{
    public int nbJoueursMax;
    private int nbToursMax;
    private int nbCheckPoint;

    private string preLaps;
    private string endLaps;
    private string endCP;

    public GameManager GM;

    static UIManager _manager;
    public static UIManager Get
    {
        get
        {
            if (_manager == null)
                _manager = GameObject.FindObjectOfType<UIManager>();
            return _manager;
        }
    }

    // Images a utilisées
    public Sprite[] spritePos = new Sprite[4];


    // vitesse
    private Text vitesseJoueur1;
    private Text vitesseJoueur2;
    private Text vitesseJoueur3;
    private Text vitesseJoueur4;

    //private Barre de boost
    private Image barreBoosJoueur1;
    private Image barreBoosJoueur2;
    private Image barreBoosJoueur3;
    private Image barreBoosJoueur4;

    // position dans la course
    private Image positionJoueur1;
    private Image positionJoueur2;
    private Image positionJoueur3;
    private Image positionJoueur4;

    // Nombre de Tours
    private Text nbToursJoueur1;
    private Text nbToursJoueur2;
    private Text nbToursJoueur3;
    private Text nbToursJoueur4;

    // numCheckPoint en cours
    private Text numCheckPointJoueur1;
    private Text numCheckPointJoueur2;
    private Text numCheckPointJoueur3;
    private Text numCheckPointJoueur4;

    // Compteur
    public Text compteurJ1;
    public Text compteurJ2;
    public Text compteurJ3;
    public Text compteurJ4;

    public Text messageFin;
    string textFin = "Appuyez sur A pour \nretourner à l'écran titre";


    // Use this for initialization
    void Start()
    {
        nbToursMax = GameObject.Find("SystemCourse").GetComponent<SystemCourse>().NBTOURSJEU;
        nbCheckPoint = GameObject.Find("SystemCourse").GetComponent<SystemCourse>().nombreCheckPoint;
        preLaps = "LAPS ";
        endLaps = "/" + nbToursMax.ToString();
        endCP = "/"+nbCheckPoint.ToString();

        //enregistrement des composants externes
        //BoostPack.OnChangeNbBoost += MajBoost;
        VehiculeMovements.OnChangeVitesse += UIVitesse;
        VehiculeMovements.OnChangeBoost += UIBarreBoost;
        SystemCourse.OnChangeClassement += UIMajPosition;
        SystemCourse.OnChangeNbTours += UINbTour;
        SystemCourse.OnChangeCP += UInbCheckPoint;
        GameManager.OnChangeCompteur += UICompteur;
        GameManager.OnFinJoueur += UIFinJoueur;
        GameManager.OnChangeClassement += UIMajPosition;
        GameManager.OnFinPartie += MessageFinJeu;

        //GameObject canvasGO = GameObject.Find("Canvas").GetComponent<GameObject>();
        //_imageBarreVideBazooka = GameObject.Find("Canvas/HUD/ChargeBazooka/barreVide").GetComponent<Image>();


        vitesseJoueur1 = GameObject.Find("Canvas/Vitesse/J1").GetComponent<Text>();
        vitesseJoueur2 = GameObject.Find("Canvas/Vitesse/J2").GetComponent<Text>();
        vitesseJoueur3 = GameObject.Find("Canvas/Vitesse/J3").GetComponent<Text>();
        vitesseJoueur4 = GameObject.Find("Canvas/Vitesse/J4").GetComponent<Text>();

        barreBoosJoueur1 = GameObject.Find("Canvas/BoostBarre/J1").GetComponent<Image>();
        barreBoosJoueur2 = GameObject.Find("Canvas/BoostBarre/J2").GetComponent<Image>();
        barreBoosJoueur3 = GameObject.Find("Canvas/BoostBarre/J3").GetComponent<Image>();
        barreBoosJoueur4 = GameObject.Find("Canvas/BoostBarre/J4").GetComponent<Image>();

        positionJoueur1 = GameObject.Find("Canvas/Positions/J1").GetComponent<Image>();
        positionJoueur2 = GameObject.Find("Canvas/Positions/J2").GetComponent<Image>();
        positionJoueur3 = GameObject.Find("Canvas/Positions/J3").GetComponent<Image>();
        positionJoueur4 = GameObject.Find("Canvas/Positions/J4").GetComponent<Image>();

        nbToursJoueur1 = GameObject.Find("Canvas/NbTours/J1").GetComponent<Text>();
        nbToursJoueur2 = GameObject.Find("Canvas/NbTours/J2").GetComponent<Text>();
        nbToursJoueur3 = GameObject.Find("Canvas/NbTours/J3").GetComponent<Text>();
        nbToursJoueur4 = GameObject.Find("Canvas/NbTours/J4").GetComponent<Text>();

        numCheckPointJoueur1 = GameObject.Find("Canvas/NumCheckpoint/J1").GetComponent<Text>();
        numCheckPointJoueur2 = GameObject.Find("Canvas/NumCheckpoint/J2").GetComponent<Text>();
        numCheckPointJoueur3 = GameObject.Find("Canvas/NumCheckpoint/J3").GetComponent<Text>();
        numCheckPointJoueur4 = GameObject.Find("Canvas/NumCheckpoint/J4").GetComponent<Text>();



    }

    //private 
    private void UIVitesse(int numJoueur, float vitesse)
    {
        if(numJoueur == 1)
        {
            vitesseJoueur1.text = vitesse.ToString("F0");
        }
        else if (numJoueur == 2)
        {
            vitesseJoueur2.text = vitesse.ToString("F0");
        }
        else if (numJoueur == 3)
        {
            vitesseJoueur3.text = vitesse.ToString("F0");
        }
        else if (numJoueur == 4)
        {
            vitesseJoueur4.text = vitesse.ToString("F0");
        }
    }

    // maj de la barre boost
    private void UIBarreBoost(int numJoueur, float _jauge)
    {

        if (numJoueur == 1)
        {
            barreBoosJoueur1.fillAmount = _jauge/100.0f;
        }
        else if (numJoueur == 2)
        {
            barreBoosJoueur2.fillAmount = _jauge / 100.0f;
        }
        else if (numJoueur == 3)
        {
            barreBoosJoueur3.fillAmount = _jauge / 100.0f;
        }
        else if (numJoueur == 4)
        {
            barreBoosJoueur4.fillAmount = _jauge / 100.0f;
        }
    }

    // maj pos
    private void UIMajPosition(int _leNumDuJoueur, int _saPosition)
    {
        if (_leNumDuJoueur == 1)
        {
            positionJoueur1.sprite = spritePos[_saPosition - 1];
        }
        else if (_leNumDuJoueur == 2)
        {
            positionJoueur2.sprite = spritePos[_saPosition - 1];
        }
        else if (_leNumDuJoueur == 3)
        {
            positionJoueur3.sprite = spritePos[_saPosition - 1];
        }
        else if (_leNumDuJoueur == 4)
        {
            positionJoueur4.sprite = spritePos[_saPosition - 1];
        }
    }

    private void UINbTour(int numJoueur, int _nbTours)
    {
        
        if (numJoueur == 1)
        {
            nbToursJoueur1.text = preLaps+_nbTours.ToString()+endLaps;
        }
        else if (numJoueur == 2)
        {
            nbToursJoueur2.text = preLaps + _nbTours.ToString() + endLaps;
        }
        else if (numJoueur == 3)
        {
            nbToursJoueur3.text = preLaps + _nbTours.ToString() + endLaps;
        }
        else if (numJoueur == 4)
        {
            nbToursJoueur4.text = preLaps + _nbTours.ToString() + endLaps;
        }
    }

    private void UInbCheckPoint(int numJoueur, int _nbCheckPoint)
    {

        if (numJoueur == 1)
        {
            numCheckPointJoueur1.text = _nbCheckPoint.ToString() + endCP;
        }
        else if (numJoueur == 2)
        {
            numCheckPointJoueur2.text = _nbCheckPoint.ToString() + endCP;
        }
        else if (numJoueur == 3)
        {
            numCheckPointJoueur3.text = _nbCheckPoint.ToString() + endCP;
        }
        else if (numJoueur == 4)
        {
            numCheckPointJoueur4.text = _nbCheckPoint.ToString() + endCP;
        }
    }

    private void UICompteur(string s)
    {
        compteurJ1.text = s;
        compteurJ2.text = s;
        compteurJ3.text = s;
        compteurJ4.text = s;
    }

    private void UIFinJoueur(int _numJoueur, string _message)
    {

        if (_numJoueur == 1)
        {
            compteurJ1.text = _message;
        }
        else if (_numJoueur == 2)
        {
            compteurJ2.text = _message;
        }
        else if (_numJoueur == 3)
        {
            compteurJ3.text = _message;
        }
        else if (_numJoueur == 4)
        {
            compteurJ4.text = _message;
        }
    }

    private void MessageFinJeu()
    {
        messageFin.text = textFin;
    }

    void OnDestroy()
    {
        VehiculeMovements.OnChangeVitesse -= UIVitesse;
        VehiculeMovements.OnChangeBoost -= UIBarreBoost;
        SystemCourse.OnChangeClassement -= UIMajPosition;
        SystemCourse.OnChangeNbTours -= UINbTour;
        SystemCourse.OnChangeCP -= UInbCheckPoint;
        GameManager.OnChangeCompteur -= UICompteur;
        GameManager.OnFinJoueur -= UIFinJoueur;
        GameManager.OnChangeClassement -= UIMajPosition;
        GameManager.OnFinPartie -= MessageFinJeu;

    }

}
