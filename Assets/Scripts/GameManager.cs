using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int nbJoueur;
    public int nombreCheckPoint;
    private bool jeuActif = false;
    public VehiculeMovements vaisseauJ1;
    public VehiculeMovements vaisseauJ2;
    public VehiculeMovements vaisseauJ3;
    public VehiculeMovements vaisseauJ4;

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


    // Use this for initialization
    void Start () {
        nbJoueur = GameObject.Find("SystemCourse").GetComponent<SystemCourse>().nbJoueurs;
        nombreCheckPoint = GameObject.Find("SystemCourse").GetComponent<SystemCourse>().nombreCheckPoint;
        timerDecomte = Time.time;

        ActiverVaisseaux(false);

        Invoke("lol",1.0f);
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
                decompteActif = false;
                // prevoir UI
                ActiverVaisseaux(true);
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
        for(int i = 0; i < nbJoueur; i++)
        {
            if (OnChangeCompteur != null)
            {
                OnChangeCompteur("FIN PARTIE");
            }
        }

    }
}
