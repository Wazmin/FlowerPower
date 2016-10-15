using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetUpShip : MonoBehaviour {

    public Camera Camdujoueur;
    public int IndexJoueur;
    private int NombreDeJoueur;
    public GameObject Gamemanager;
    private int IndexVaisseau;
    private GameObject Info;
    public GameObject V1, V2, V3, V4;
    public GameObject JoueurContainer;

    // Use this for initialization
    void Awake()
    {

        RecupIndex();
        SpawnShip();
        SetNumJoueur();
        dispatch();
        AssigntoGameManager();
        affectcommands();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void RecupIndex()
    {
        Info = GameObject.Find("Info");

        if (IndexJoueur == 1)
        {
            IndexVaisseau = Info.GetComponent<GetInfo>().vaisseauJ1;
        }
        if (IndexJoueur == 2)
        {
            IndexVaisseau = Info.GetComponent<GetInfo>().vaisseauJ2;
        }
        if (IndexJoueur == 3)
        {
            IndexVaisseau = Info.GetComponent<GetInfo>().vaisseauJ3;
        }
        if (IndexJoueur == 4)
        {
            IndexVaisseau = Info.GetComponent<GetInfo>().vaisseauJ4;
        }
    }

    void SpawnShip()
    {
        if (IndexVaisseau == 1)
        {
            Object.Instantiate(V1);
            GameObject.Find("Vaisseau"+IndexVaisseau.ToString()+"(Clone)").transform.parent = JoueurContainer.transform;
        }
        if (IndexVaisseau == 2)
        {
            Object.Instantiate(V2);
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString()+"(Clone)").transform.parent = JoueurContainer.transform;
        }
        if (IndexVaisseau == 3)
        {
            Object.Instantiate(V3);
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString()+"(Clone)").transform.parent = JoueurContainer.transform;
        }
        if (IndexVaisseau == 4)
        {
            Object.Instantiate(V4);
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString()+"(Clone)").transform.parent = JoueurContainer.transform;
        }
    }

    void dispatch()
    {
        if (IndexVaisseau == 1)
        {
            Camdujoueur.GetComponent<CameraScript>().target = GameObject.Find("Joueur " + IndexJoueur+ "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Position" + IndexVaisseau.ToString()).transform;
            Camdujoueur.GetComponent<CameraScript>().lookatTarget = GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Look Target" + IndexVaisseau.ToString()).transform;
        }
        if (IndexVaisseau == 2)
        {
            Camdujoueur.GetComponent<CameraScript>().target = GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Position" + IndexVaisseau.ToString()).transform;
            Camdujoueur.GetComponent<CameraScript>().lookatTarget = GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Look Target" + IndexVaisseau.ToString()).transform;
        }
        if (IndexVaisseau == 3)
        {
            Camdujoueur.GetComponent<CameraScript>().target = GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Position" + IndexVaisseau.ToString()).transform;
            Camdujoueur.GetComponent<CameraScript>().lookatTarget = GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Look Target" + IndexVaisseau.ToString()).transform;

        }
        if (IndexVaisseau == 4)
        {
            Camdujoueur.GetComponent<CameraScript>().target = GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Position" + IndexVaisseau.ToString()).transform;
            Camdujoueur.GetComponent<CameraScript>().lookatTarget =  GameObject.Find("Joueur " + IndexJoueur + "/Vaisseau" + IndexVaisseau.ToString() + "(Clone)/Camera Look Target" + IndexVaisseau.ToString()).transform;
        }
    }

    void SetNumJoueur()
    {
        if(JoueurContainer.name =="Joueur 1")
        {
            Debug.Log("coucou");
            GameObject.Find("Joueur 1/Vaisseau"+IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 1 ;
        }
        if (JoueurContainer.name == "Joueur 2")
        {
            GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 2;
        }
        if (JoueurContainer.name == "Joueur 3")
        {
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 3;
        }
        if (JoueurContainer.name == "Joueur 4")
        {
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 4;
        }
    }

    void AssigntoGameManager()
    {
        if (JoueurContainer.name == "Joueur 1")
        {
            Debug.Log("aurevoir");
            Gamemanager.GetComponent<GameManager>().vaisseauJ1 = GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
        if (JoueurContainer.name == "Joueur 2")
        {
            Gamemanager.GetComponent<GameManager>().vaisseauJ2 = GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
        if (JoueurContainer.name == "Joueur 3")
        {
            Gamemanager.GetComponent<GameManager>().vaisseauJ3 = GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
        if (JoueurContainer.name == "Joueur 4")
        {
            Gamemanager.GetComponent<GameManager>().vaisseauJ4 = GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
    }

    void affectcommands()

    {
        if (JoueurContainer.name == "Joueur 1")
        {
            GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }
        if (JoueurContainer.name == "Joueur 2") { 
        GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
        GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
        GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }
        if (JoueurContainer.name == "Joueur 3")
        {
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }
        if (JoueurContainer.name == "Joueur 4")
        {
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }

    }

}
