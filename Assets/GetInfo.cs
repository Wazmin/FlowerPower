using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class GetInfo : MonoBehaviour
{
    //Variables servant à charger la bonne scène dans l'écrand de selection des vaisseaux
    public int NbJoueur;
    public string NomMap;
    public int Nbtour;
    //variables d'index des vaisseaux selon le joueur
    public int vaisseauJ1;
    public int vaisseauJ2;
    public int vaisseauJ3;
    public int vaisseauJ4;
    private GameObject Loading;
    // Use this for initialization
    void Start()
    {
        //je vais chercher les infos dans le script LoadSelection qui est sur l'objet A button. C'est un peu faire un détour pour rien, mais au moins GetInfo ne contient QUE les informations.
        if (SceneManager.GetActiveScene().name == "EcranTitre3")
        {
            Loading = GameObject.Find("A button");
            DontDestroyOnLoad(GameObject.Find("Info"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "EcranTitre3")
        {
            NbJoueur = Loading.GetComponent<LoadSelection>().nombreJoueur;
            NomMap = Loading.GetComponent<LoadSelection>().Map;
            Nbtour = Loading.GetComponent<LoadSelection>().NombreTour;
        }
    }
}
