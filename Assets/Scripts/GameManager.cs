using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int nbJoueur;
    public int nombreCheckPoint;
    private bool jeuActif = false;
    private bool partieFinie;
    public VehiculeMovements vaisseauJ1;
    public VehiculeMovements vaisseauJ2;
    public VehiculeMovements vaisseauJ3;
    public VehiculeMovements vaisseauJ4;

    public List<int> classementJoueur;
    public AudioSource AS;
    public AudioClip bipInter;
    public AudioClip bipFinal;
    public AudioSource ASmusique;
    public AudioClip MusiqueFin;
    // timer
    public bool decompteActif;
    public int nbDecomte;
    private float timerDecomte;
    private float ticDecompte = 1.0f;
    // Events
    public delegate void MajCompteur(string s);
    public static event MajCompteur OnChangeCompteur;

    public delegate void MajFinJoueur(int numJoueur, string s);
    public static event MajFinJoueur OnFinJoueur;

    //event classement
    public delegate void MajClasssement(int numJoueur, int posJoueur);
    public static event MajClasssement OnChangeClassement;

    public delegate void MajFinPartie();
    public static event MajFinPartie OnFinPartie;

    // Use this for initialization
    void Start () {
        nbJoueur = GameObject.Find("SystemCourse").GetComponent<SystemCourse>().nbJoueurs;
        nombreCheckPoint = GameObject.Find("SystemCourse").GetComponent<SystemCourse>().nombreCheckPoint;
        timerDecomte = Time.time;

        ActiverVaisseaux(false);

        Invoke("lol",1.0f);
        classementJoueur = new List<int>();
        partieFinie = false;
    }

    void lol()
    {
        if (OnChangeCompteur != null)
        {
            OnChangeCompteur(nbDecomte.ToString());
        }
        decompteActif = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (decompteActif && nbDecomte > 0)
        {
            Decomte();
        }
        else if(!decompteActif && nbDecomte <= 0 && Time.time - timerDecomte > ticDecompte)
        {
            if (OnChangeCompteur != null)
            {
                OnChangeCompteur("");
            }
            decompteActif = true;
        }

        if (partieFinie)
        {
            if (Input.GetButtonDown("Boost_J1"))
            {
                SceneManager.LoadScene("title");
            }
        }

	}

    public void Decomte()
    {
        if(Time.time - timerDecomte > ticDecompte)
        {
            nbDecomte--;
            timerDecomte = Time.time;
            //prevoir ui
            
            if (nbDecomte <= 0)
            {
                AS.PlayOneShot(bipFinal);
                decompteActif = false;
                // prevoir UI
                ActiverVaisseaux(true);
            }
            else
            {
                AS.PlayOneShot(bipInter);
            }

            if (OnChangeCompteur != null)
            {
                OnChangeCompteur(nbDecomte.ToString());
            }
        }
        
    }

    private void ActiverVaisseaux(bool activer)
    {
        vaisseauJ1.Activate(activer);
        if (nbJoueur > 1)
        {
            vaisseauJ2.Activate(activer);
        }
        if (nbJoueur > 2)
        {
            vaisseauJ3.Activate(activer);
        }
        if (nbJoueur > 3)
        {
            vaisseauJ4.Activate(activer);
        }
       
    }


    public void FinJoueur(int numJoueur)
    {
        if (OnFinJoueur != null)
        {
            OnFinJoueur(numJoueur,"Finish");
        }
        classementJoueur.Add(numJoueur);

        if(numJoueur == 1)
        {
            vaisseauJ1.Activate(false);
        }
        else if (numJoueur == 2)
        {
            vaisseauJ2.Activate(false);
        }
        else if (numJoueur == 3)
        {
            vaisseauJ3.Activate(false);
        }
        else if (numJoueur == 4)
        {
            vaisseauJ4.Activate(false);
        }
    }


    public void FinPartie()
    {
        ActiverVaisseaux(false);
        ASmusique.Stop();
        ASmusique.clip = MusiqueFin;
        ASmusique.Play();
        for(int i = 0; i < nbJoueur; i++)
        {
            if (OnChangeCompteur != null)
            {
                OnChangeCompteur("FIN PARTIE");
            }
        }
        Invoke("RelancerPremiereScene", 3.0f);
        if (OnFinPartie != null)
        {
            OnFinPartie();
        }
    }

    private void RelancerPremiereScene()
    {
        //SceneManager.LoadScene("title");
       
        partieFinie = true;
    }

    public void PosJoueurFini()
    {
        int pos = 1;
        foreach(int numJoueur in classementJoueur)
        {
            if (OnChangeClassement != null)
            {
                OnChangeClassement(numJoueur,pos++);
            }
        }
    }


}
