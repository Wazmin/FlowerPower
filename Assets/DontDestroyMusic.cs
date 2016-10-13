using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections;

public class DontDestroyMusic : MonoBehaviour {
	private GameObject zik;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(GameObject.Find("MusiqueEcranTitre"));
	}
	
	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name != "EcranTitre3")
			{
				if(SceneManager.GetActiveScene ().name != "SelectionVaisseauTest") {
				Destroy(GameObject.Find("MusiqueEcranTitre"));
			}
		}
	}
}

