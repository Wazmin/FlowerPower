using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadingMap : MonoBehaviour {
    public UnityEngine.AudioSource vroum;
    public AudioClip ready;
    //bool qui devient vrai si tous les joueurs ont choisi leur vaisseau
    public bool allselected = false;
   //infos pour charger la bonne map avec le bon nombre de joueurs
    private string Map;
    public int nombreJoueur;

    public GameObject TextReady;
    //ces deux la servent plus, mais je garde espoir
    private float timer;
    private bool interrupteur = false;

    // Use this for initialization
    void Start () {
        //récup les informations
        nombreJoueur = GameObject.Find("Info").GetComponent<GetInfo>().NbJoueur;
        Map = GameObject.Find("Info").GetComponent<GetInfo>().NomMap;
        timer= Time.time;

    }

    // Update is called once per frame
    void Update() {
        //vérifier que tout le monde a sélectionné son vaisseau en fonction du nombre de joueur
        if (nombreJoueur == 1)
        {
            if (GameObject.Find("CanvasSelection").GetComponent<Selection>().V1selected == true) {
                interrupteur = true;
                allselected = true;

            }
        }
        if (nombreJoueur == 2)
        {
            if ((GameObject.Find("CanvasSelection").GetComponent<Selection>().V1selected == true)&& (GameObject.Find("CanvasSelection").GetComponent<Selection>().V2selected == true)) {
                allselected = true;
                interrupteur = true;
            }
        }
        if (nombreJoueur == 3)
        {
            if ((GameObject.Find("CanvasSelection").GetComponent<Selection>().V1selected == true) && (GameObject.Find("CanvasSelection").GetComponent<Selection>().V2selected == true) && (GameObject.Find("CanvasSelection").GetComponent<Selection>().V3selected == true)) {
                allselected = true;
                interrupteur = true;
            }
        }
        if (nombreJoueur == 4)
        {
            if ((GameObject.Find("CanvasSelection").GetComponent<Selection>().V1selected == true) && (GameObject.Find("CanvasSelection").GetComponent<Selection>().V2selected == true) && (GameObject.Find("CanvasSelection").GetComponent<Selection>().V3selected == true) && (GameObject.Find("CanvasSelection").GetComponent<Selection>().V1selected == true)) { 
                allselected = true;
                interrupteur = true;
            }
        }
        //une fois que tout le monde a sélectionné, READY s'affiche et NORMALEMENT, il faudrait appuyer sur A pour lancer la map, mais j'ai pas encore résolu le problème du timer. Il faudrait que je récupère celui du code de Selection...
        if (allselected == true) {
            TextReady.SetActive(true);
            if (Input.GetButtonDown("Boost_J1"))
            {
                Debug.Log(timer);
                Debug.Log(Time.time);
                Debug.Log(Time.time - timer);
                if (Time.time - timer > 0.5f) { 
                          if (Map == "Canyon")
                          {
                            vroum.PlayOneShot(ready, 2.0f);
                         // SceneManager.LoadScene("principale" + nombreJoueur.ToString() + "J");
                        SceneManager.LoadScene("1Jtest");
                    }
                           if (Map == "RCanyon")
                          {
                           vroum.PlayOneShot(ready, 2.0f);
                            SceneManager.LoadScene("Reverse" + nombreJoueur.ToString() + "J");
                            }
                }
            }
        }

    }
}