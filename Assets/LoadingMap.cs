using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class LoadingMap : MonoBehaviour {
    public UnityEngine.AudioSource vroum;
    public AudioClip ready;
    public bool allselected = false;
    private string Map;
    public int nombreJoueur;
    public GameObject TextReady;
    private float timer;
    private bool interrupteur = false;

    // Use this for initialization
    void Start () {
        nombreJoueur = GameObject.Find("Info").GetComponent<GetInfo>().NbJoueur;
        Map = GameObject.Find("Info").GetComponent<GetInfo>().NomMap;
        timer= Time.time;

    }

    // Update is called once per frame
    void Update() {

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
                          SceneManager.LoadScene("principale" + nombreJoueur.ToString() + "J");
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