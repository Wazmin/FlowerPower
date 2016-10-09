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
    private Text positionJoueur1;
    private Text positionJoueur2;
    private Text positionJoueur3;
    private Text positionJoueur4;

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

        barreBoosJoueur1 = GameObject.Find("Canvas/Boost/J1").GetComponent<Image>();
        barreBoosJoueur2 = GameObject.Find("Canvas/Boost/J2").GetComponent<Image>();
        barreBoosJoueur3 = GameObject.Find("Canvas/Boost/J3").GetComponent<Image>();
        barreBoosJoueur4 = GameObject.Find("Canvas/Boost/J4").GetComponent<Image>();

        positionJoueur1 = GameObject.Find("Canvas/Positions/J1").GetComponent<Text>();
        positionJoueur2 = GameObject.Find("Canvas/Positions/J2").GetComponent<Text>();
        positionJoueur3 = GameObject.Find("Canvas/Positions/J3").GetComponent<Text>();
        positionJoueur4 = GameObject.Find("Canvas/Positions/J4").GetComponent<Text>();

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
    private void UIBarreBoost(float _jauge)
    {

    }

}
