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

    private Text vitesseJoueur1;
    private Text vitesseJoueur2;
    private Text vitesseJoueur3;
    private Text vitesseJoueur4;

    //-------------------------------------------------------
    // Boost
    private Image _imageBarreBoost;
    private Image _imageFlouBoost;

    //texte de mort
    private Text _textMort;

    // systeme GameManager
    private Canvas _canvasTabScore;
    private GameObject _BtnRetourMenu;
    public Text _txtMessageGameManager;
    public Text _chronoPartie;



    // Use this for initialization
    void Start()
    {

        //enregistrement des composants externes
        //BoostPack.OnChangeNbBoost += MajBoost;
        VehiculeMovements.OnChangeVitesse += UIVitesse;

        //GameObject canvasGO = GameObject.Find("Canvas").GetComponent<GameObject>();
        //_imageBarreVideBazooka = GameObject.Find("Canvas/HUD/ChargeBazooka/barreVide").GetComponent<Image>();


        vitesseJoueur1 = GameObject.Find("Canvas/Vitesse/J1").GetComponent<Text>();
        vitesseJoueur2 = GameObject.Find("Canvas/Vitesse/J2").GetComponent<Text>();
        vitesseJoueur3 = GameObject.Find("Canvas/Vitesse/J3").GetComponent<Text>();
        vitesseJoueur4 = GameObject.Find("Canvas/Vitesse/J4").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
       
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

    // UI Dose Boost
    private void MajBoost(int _nbBoost)
    {
        //nbBoost += _nbBoost;
        float fillToDo = 0.0f;
        switch (_nbBoost)
        {
            case 0:
                fillToDo = 0.0f;
                break;
            case 1:
                fillToDo = 0.33f;
                break;
            case 2:
                fillToDo = 0.67f;
                break;
            case 3:
                fillToDo = 1.0f;
                break;
            default:
                fillToDo = 1.5f; //bug visuel
                break;
        }
        _imageBarreBoost.fillAmount = fillToDo;
    }

}
