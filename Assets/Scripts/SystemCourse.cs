using UnityEngine;
using System.Collections;

public class SystemCourse : MonoBehaviour {
    public int nombreCheckPoint;
    public int nombreDeTours;
    public int nbJoueurs;
    private int[] tabCPprecedent;
    private int[] tabCPaAtteindre;
    private int[] tabNbTours;

    void Awake()
    {
        tabCPprecedent = new int[nbJoueurs];
        tabCPaAtteindre = new int[nbJoueurs];
        tabNbTours = new int[nbJoueurs];
    }

	// Use this for initialization
	void Start () {
	    for(int i = 0; i < nbJoueurs; i++)
        {
            tabCPprecedent[i] = nombreCheckPoint;
            tabCPaAtteindre[i] = 1;
            tabNbTours[i] = 0;
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
                    Debug.Log(tabNbTours[_numJoueur-1]+" tours effectué");
                }else
                {
                    Debug.Log("CheckPoint atteint : "+ _numCheckPoint);
                }
            }
        }
        else
        {
            Debug.Log("Mauvais sens! le CP a atteindre "+ tabCPaAtteindre[_numJoueur - 1]);
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
}
