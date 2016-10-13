using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class GetInfo : MonoBehaviour {
	public int NbJoueur;
	public string NomMap;
	public int vaisseauJ1;
	public int vaisseauJ2;
	public int vaisseauJ3;
	public int vaisseauJ4;
	private GameObject Loading;
	// Use this for initialization
	void Start () {
		Loading = GameObject.Find ("A button");
		DontDestroyOnLoad(GameObject.Find("Info"));
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene().name == "EcranTitre3") {
			NbJoueur = Loading.GetComponent<LoadSelection> ().nombreJoueur;
			NomMap = Loading.GetComponent<LoadSelection> ().Map;
		}
	}
}
