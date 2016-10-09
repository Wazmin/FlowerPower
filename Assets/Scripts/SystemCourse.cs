using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SystemCourse : MonoBehaviour {
    public int NBTOURSJEU = 5;
    public int nombreCheckPoint;
    public int nombreDeTours;
    public int nbJoueurs;
    public List<GameObject> goCheckpoint = new List<GameObject>();
    public GameObject[] vaisseauxJoueurs = new GameObject[4];
    List<int> ClassementFinal = new List<int>();
    private int[] tabCPprecedent;
    private int[] tabCPaAtteindre;
    private int[] tabNbTours;

    private int[,] classement;

    //event classement
    public delegate void MajClasssement(int numJoueur, int posJoueur);
    public static event MajClasssement OnChangeClassement;

    public delegate void MajNbTours(int numJoueur, int nbTourJoueur);
    public static event MajNbTours OnChangeNbTours;

    public delegate void MajCP(int numJoueur, int numCP);
    public static event MajCP OnChangeCP;


    private float timerMaj;
    private float ticRateMaj;

    void Awake()
    {
        tabCPprecedent = new int[nbJoueurs];
        tabCPaAtteindre = new int[nbJoueurs];
        tabNbTours = new int[nbJoueurs];
        classement = new int[nbJoueurs,3];
        timerMaj = Time.time;
    }

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < nbJoueurs; i++)
        {
            tabCPprecedent[i] = nombreCheckPoint;
            tabCPaAtteindre[i] = 1;
            tabNbTours[i] = 0;

        }
        Invoke("lol", 0.5f);

    }

    private void lol()
    {
        for (int i = 0; i < nbJoueurs; i++)
        {
            if (OnChangeNbTours != null)
            {
                OnChangeNbTours(i + 1, tabNbTours[i]);
            }
            if (OnChangeCP != null)
            {
                OnChangeCP(i + 1, tabCPaAtteindre[i]);
            }
        }
    }

    void Update()
    {
        if (Time.time - timerMaj > ticRateMaj)
        {
            //Debug.Log("Classement :");
            ClassementFinal.Clear();
            MajPosition();
            if (OnChangeClassement != null)
            {
                for(int i = 0; i < ClassementFinal.Count; i++)
                {
                    OnChangeClassement(ClassementFinal[i]+1, i+1);
                }   
            }
            //foreach (int i in ClassementFinal)
            //{
            //    Debug.Log((i+1).ToString());
            //}
            timerMaj = Time.time;
        }

      
    }
	
    public void CheckPointPasse(int _numJoueur, int _numCheckPoint)
    {
        if(isGoodWay(_numJoueur, _numCheckPoint))
        {
            if(tabCPaAtteindre[_numJoueur -1] == _numCheckPoint)
            {
                if(++tabCPaAtteindre[_numJoueur - 1] >= nombreCheckPoint)
                {
                    tabCPaAtteindre[_numJoueur - 1] = 1;
                    tabNbTours[_numJoueur - 1]++;

                    //ajout d'un tour
                    if (OnChangeNbTours != null)
                    {
                        OnChangeNbTours(_numJoueur, tabNbTours[_numJoueur - 1]);
                    }

                    // Debug.Log(tabNbTours[_numJoueur-1]+" tours effectué");
                }
                else
                {
                    //Debug.Log("CheckPoint atteint : "+ _numCheckPoint);
                }
                if (OnChangeCP != null)
                {
                    OnChangeCP(_numJoueur, tabCPaAtteindre[_numJoueur - 1]);
                }
            }
        }
        else
        {
           // Debug.Log("Mauvais sens! le CP a atteindre "+ tabCPaAtteindre[_numJoueur - 1]);
        }
        
    }

    private bool isGoodWay(int numJoueur, int numCheckPoint)
    {
        bool result;
        if(numCheckPoint == 1)
        {
            if(tabCPprecedent[numJoueur -1] == nombreCheckPoint)
            {
                //Debug.Log("CheckPoint");
                result= true;
            }
            else
            {
                //Debug.Log("Mauvais sens !");
                result= false;
            }
        }
        else 
        {
            if (tabCPprecedent[numJoueur - 1] == numCheckPoint -1)
            {
                //Debug.Log("CheckPoint");
                result= true;
            }
            else
            {
                //Debug.Log("Mauvais sens !");
                result= false;
            }
        }
       

        tabCPprecedent[numJoueur - 1] = numCheckPoint;
        return result;
    }

    private void MajPosition()
    {
        List<int> indiceJoueur = new List<int>();
        List<int> scoreJoueur = new List<int>();

        for (int i=0; i<nbJoueurs; i++)
        {
            indiceJoueur.Add(i);
            scoreJoueur.Add(tabNbTours[i] * nombreCheckPoint + tabCPaAtteindre[i]);
        }

        // on a une liste des joueurs avec leur scores
        // on classe
        List<int> indiceJoueur2 = new List<int>();
        List<int> scoreJoueur2 = new List<int>();

        while (indiceJoueur.Count > 0) {
            int tmpScoreMax = -1; int indiceMax = 0;

            for (int j = 0; j < scoreJoueur.Count; j++)
            {
                if (scoreJoueur[j] > tmpScoreMax)
                {
                    tmpScoreMax = scoreJoueur[j];
                    indiceMax = j;
                }
            }
            indiceJoueur2.Add(indiceJoueur[indiceMax]);
            scoreJoueur2.Add(scoreJoueur[indiceMax]);

            indiceJoueur.RemoveAt(indiceMax);
            scoreJoueur.RemoveAt(indiceMax);
            // j'ai le max de la liste

        }

        //j'ai une liste de joueur classé
        // y a t'il des joueurs a départager ?

        while (indiceJoueur2.Count > 0) {
            List<int> joueurADepartager = new List<int>();
            bool partage = false;
            List<int> indiceAShooter = new List<int>();

            int tac = 1;
            while(tac < indiceJoueur2.Count)
            {
                if (scoreJoueur2[0] == scoreJoueur2[tac]) // egalité
                {
                    if (!partage)
                    {
                        joueurADepartager.Add(indiceJoueur2[0]);
                        indiceAShooter.Add(0);
                        partage = true;
                    }
                    joueurADepartager.Add(indiceJoueur2[tac]);
                    indiceAShooter.Add(tac);
                }
                tac++;
            }

            // on shoot ceux dans la liste a départager
            indiceAShooter.Reverse();
            foreach(int i in indiceAShooter)
            {
                scoreJoueur2.RemoveAt(i);
                indiceJoueur2.RemoveAt(i);
            }

            if (joueurADepartager.Count > 0)
            {
                Classer(joueurADepartager, ClassementFinal);
            }
            else
            {
                ClassementFinal.Add(indiceJoueur2[0]);
                scoreJoueur2.RemoveAt(0);
                indiceJoueur2.RemoveAt(0);
            }

        }
    }

    // sous fonction de la fonction precedente
    private void Classer(List<int> _numJoueur, List<int> _classsementFinal)
    {
        List<int> classementTmp = new List<int>();
        float distanceMin = -1.0f; int indiceMin = -1;

        Transform tProchainCP = goCheckpoint[tabCPaAtteindre[_numJoueur[0]] - 1].GetComponent<Transform>();


        float[] distanceCP = new float[_numJoueur.Count]; 

        //on calcule les distance
        for(int i = 0; i < distanceCP.Length; i++)
        {
            distanceCP[i] = Vector3.Distance(tProchainCP.position, vaisseauxJoueurs[_numJoueur[i]].transform.position);
        }

        while (_numJoueur.Count > 0)
        {
            distanceMin = distanceCP[0];
            indiceMin = 0;
            for(int i = 0; i < _numJoueur.Count; i++)
            {
                if (distanceCP[i] < distanceMin)
                {
                    distanceMin = distanceCP[i];
                    indiceMin = i;
                }
            }
            classementTmp.Add(_numJoueur[indiceMin]);
            _numJoueur.RemoveAt(indiceMin);
        }
        //sortie ici classementTmp est remplis avec l'ordre des joueurs
        // je les ajoute au classement final
        foreach(int i in classementTmp)
        {
            _classsementFinal.Add(i);
        }
        
    }
}
