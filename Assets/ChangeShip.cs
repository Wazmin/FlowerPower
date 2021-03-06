﻿using UnityEngine;
using System.Collections;

public class ChangeShip : MonoBehaviour {
    //on spécifie le joueur pour savoir quelle variable utiliser
    public GameObject joueur;
    //pour simplifier les get component
    private GameObject Info;
    public GameObject vehicule;
    public Camera Camdujoueur;
    //On stocke les animations à dispatcher et les viewpoints à mettre sur la caméra
    public Animator ANLucas;
    public Animator ANYu;
    public Animator ANFelix;
    public Animator ANMax;
    public Transform TargetLucas, VtargetLucas, TargetYu, VtargetYu, TargetFelix, VtargetFelix, TargetMax, VtargetMax;
    //Les quatre objets à activer contenant les vaisseaux.
    public GameObject V1, V2, V3, V4;
    //Les fichiers audio à dispatcher selon le vaisseau
    public AudioClip mot1, mot2, mot3, mot4;
    public AudioClip boost1, boost2, boost3, boost4;
    public AudioClip rela1, rela2, rela3, rela4;
    public AudioSource sourcemoteur;
    //l'index du vaisseau, qu'on récupérérera en fonction du game object joueur
    private int indexvaisseau;
	// Use this for initialization
	void Awake () {
        RecupIndex();
        activevaisseau();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //récupérer l'index selon le joueur


    void RecupIndex()
    {
        Info = GameObject.Find("Info");

        if (joueur.name == "JOUEUR1")
        {
            indexvaisseau = Info.GetComponent<GetInfo>().vaisseauJ1;
        }
        if (joueur.name == "JOUEUR2")
        {
            indexvaisseau = Info.GetComponent<GetInfo>().vaisseauJ2;
        }
        if (joueur.name == "JOUEUR3")
        {
            indexvaisseau = Info.GetComponent<GetInfo>().vaisseauJ3;
        }
        if (joueur.name == "JOUEUR4")
        {
            indexvaisseau = Info.GetComponent<GetInfo>().vaisseauJ4;
        }
    }

    //activer le bon vaisseau
    void activevaisseau()
    {
        if (indexvaisseau == 1)
        {
            V1.SetActive(true);
        }
        if (indexvaisseau == 2)
        {
            V2.SetActive(true);
        }
        if (indexvaisseau == 3)
        {
            V3.SetActive(true);
        }
        if (indexvaisseau == 4)
        {
            V4.SetActive(true);
        }
    }
    //répartir les bons objets au bon endroit.
   
}
