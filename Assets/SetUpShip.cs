using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetUpShip : MonoBehaviour {

    //pour affecter les bonnes valeurs
    public Camera Camdujoueur;
    public int IndexJoueur;
    private int NombreDeJoueur;
    public GameObject Gamemanager;
    private int IndexVaisseau;
    private GameObject Info;
    //pour déterminer quel préfab faire pop
    public GameObject V1, V2, V3, V4;
    //pour y faire pop le vaisseau
    public GameObject JoueurContainer;
    public GameObject SystemCourse;
    //Sources des moteurs
    private AudioSource Source1, Source2, Source3, Source4;
    //Sources des boost et des impacts
    private AudioSource BSource1, BSource2, BSource3, BSource4;
    //P1, P2 et cie
    public GameObject PS1, PS2, PS3, PS4;
    private Vector3 Pos1, Pos2, Pos3, Pos4;

    // Use this for initialization
    void Awake()
    {
        //récuperer les infos
        RecupIndex();
        //faire pop les vaisseaux selon l'index
        SpawnShip();
        //appliquer le bon numéro de joueur à vehiculemovements
        SetNumJoueur();
        //répartir les points d'ancrage de la caméra
        dispatch();
        //affecter les vaisseaux au game manager ingame
        AssigntoGameManager();
        //affecter les bonnes commandes aux vaisseaux
        affectcommands();
        //affecter les vaisseaux au bon endroit sur le systemcourse
        affectsystemcourse();
        //régler le panoramique des audiosource
        setpanoramic();
        //changer les icones
        affectPlayerIcon();
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
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString() + "(Clone)").transform.parent = JoueurContainer.transform;
        }
        if (IndexVaisseau == 2)
        {
            Object.Instantiate(V2);
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString() + "(Clone)").transform.parent = JoueurContainer.transform;
        }
        if (IndexVaisseau == 3)
        {
            Object.Instantiate(V3);
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString() + "(Clone)").transform.parent = JoueurContainer.transform;
        }
        if (IndexVaisseau == 4)
        {
            Object.Instantiate(V4);
            GameObject.Find("Vaisseau" + IndexVaisseau.ToString() + "(Clone)").transform.parent = JoueurContainer.transform;
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
        if (IndexJoueur == 1)
        {
            Debug.Log("coucou");
            GameObject.Find("Joueur 1/Vaisseau"+IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 1 ;
        }
        if (IndexJoueur == 2)
        {
            GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 2;
        }
        if (IndexJoueur == 3)
        {
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 3;
        }
        if (IndexJoueur == 4)
        {
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>().numJoueur = 4;
        }
    }

    void AssigntoGameManager()
    {
        if (IndexJoueur == 1)
        {
            Debug.Log("aurevoir");
            Gamemanager.GetComponent<GameManager>().vaisseauJ1 = GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
        if (IndexJoueur == 2)
        {
            Gamemanager.GetComponent<GameManager>().vaisseauJ2 = GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
        if (IndexJoueur == 3)
        {
            Gamemanager.GetComponent<GameManager>().vaisseauJ3 = GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
        if (IndexJoueur == 4)
        {
            Gamemanager.GetComponent<GameManager>().vaisseauJ4 = GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>();
        }
    }

    void affectcommands()

    {
        if (IndexJoueur == 1)
        {
            GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 1/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }
        if (IndexJoueur == 2)
        { 
        GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
        GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
        GameObject.Find("Joueur 2/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }
        if (IndexJoueur == 3)
        {
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 3/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }
        if (IndexJoueur == 4)
        {
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._horizontalAxis = "HorizontalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._verticalAxis = "VerticalJ" + IndexJoueur.ToString();
            GameObject.Find("Joueur 4/Vaisseau" + IndexVaisseau.ToString() + "(Clone)").GetComponent<VehiculeMovements>()._boutonBoost = "Boost_J" + IndexJoueur.ToString();
        }

    }

    void affectsystemcourse()
    {
        if (IndexJoueur == 1)
        {
            SystemCourse.GetComponent<SystemCourse>().vaisseauxJoueurs[0] = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)");
            SystemCourse.GetComponent<SystemCourse>().vaisseauxJoueurs[1] = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)");
            SystemCourse.GetComponent<SystemCourse>().vaisseauxJoueurs[2] = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)");
            SystemCourse.GetComponent<SystemCourse>().vaisseauxJoueurs[3] = GameObject.Find("Joueur 4/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString() + "(Clone)");
        }
    }

    void setpanoramic()
    {
        if (Info.GetComponent<GetInfo>().NbJoueur == 1)
        {
            Source1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
            Source1.panStereo = 0.0f;
            BSource1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
            BSource1.panStereo = 0.0f;
        }
        if (Info.GetComponent<GetInfo>().NbJoueur == 2)
        {
            if (IndexJoueur == 1)
            {
                Source1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
                Source1.panStereo = -1.0f;
                Source2 = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString()).GetComponent<AudioSource>();
                Source2.panStereo = 1.0f;
                BSource1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
                BSource1.panStereo = -1.0f;
                BSource2 = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString()).GetComponent<AudioSource>();
                BSource2.panStereo = 1.0f;
            }
        }
        if (Info.GetComponent<GetInfo>().NbJoueur == 3)
        {
            if (IndexJoueur == 1)
            {
                Source1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
            Source1.panStereo = -1.0f;
            Source2 = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString()).GetComponent<AudioSource>();
            Source2.panStereo = 1.0f;
            Source3 = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString()).GetComponent<AudioSource>();
            Source3.panStereo = -0.2f;
            BSource1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
            BSource1.panStereo = -1.0f;
            BSource2 = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString()).GetComponent<AudioSource>();
            BSource2.panStereo = 1.0f;
            BSource3 = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString()).GetComponent<AudioSource>();
            BSource3.panStereo = -0.2f;
            }
        }
        if (Info.GetComponent<GetInfo>().NbJoueur == 4)
        {
            if (IndexJoueur == 1)
            {
                Source1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
                Source1.panStereo = -1.0f;
                Source2 = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString()).GetComponent<AudioSource>();
                Source2.panStereo = 1.0f;
                Source3 = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString()).GetComponent<AudioSource>();
                Source3.panStereo = -0.6f;
                Source4 = GameObject.Find("Joueur 4/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString()).GetComponent<AudioSource>();
                Source4.panStereo = 0.6f;
                BSource1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString()).GetComponent<AudioSource>();
                BSource1.panStereo = -1.0f;
                BSource2 = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString()).GetComponent<AudioSource>();
                BSource2.panStereo = 1.0f;
                BSource3 = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString()).GetComponent<AudioSource>();
                BSource3.panStereo = -0.6f;
                BSource4 = GameObject.Find("Joueur 4/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString() + "(Clone)/J" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "/SJ" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString()).GetComponent<AudioSource>();
                BSource4.panStereo = 0.6f;
            }
        }
    }

    void affectPlayerIcon()
    {
        if(IndexJoueur == 1)
        {
            Object.Instantiate(PS1);
            GameObject.Find("particle_p1(Clone)").transform.parent = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)").transform;
            //Pos1 = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)").transform.position;
            GameObject.Find("particle_p1(Clone)").transform.position = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)").transform.position;
            GameObject.Find("particle_p1(Clone)").transform.Translate(0, 10, Time.deltaTime);
        }
        if (IndexJoueur == 2)
        {
            Object.Instantiate(PS2);
            GameObject.Find("particle_p2(Clone)").transform.parent = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)").transform;
            GameObject.Find("particle_p2(Clone)").transform.position = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)").transform.position;
            GameObject.Find("particle_p2(Clone)").transform.Translate(0, 10, Time.deltaTime);

        }
        if (IndexJoueur == 3)
        {
            Object.Instantiate(PS3);
            GameObject.Find("particle_p3(Clone)").transform.parent =  GameObject.Find("Joueur3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)").transform;
            GameObject.Find("particle_p3(Clone)").transform.position = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)").transform.position;
            GameObject.Find("particle_p3(Clone)").transform.Translate(0, 10, Time.deltaTime);
        }
       
        if (IndexJoueur == 4)
        {
            Object.Instantiate(PS4);
            GameObject.Find("particle_p4(Clone)").transform.parent = GameObject.Find("Joueur 4/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString() + "(Clone)").transform;
            GameObject.Find("particle_p4(Clone)").transform.position = GameObject.Find("Joueur 4/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString() + "(Clone)").transform.position;
            GameObject.Find("particle_p4(Clone)").transform.Translate(0, 10, Time.deltaTime);
        }
      
    }
}
