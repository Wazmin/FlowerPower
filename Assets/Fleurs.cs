using UnityEngine;
using System.Collections;

public class Fleurs : MonoBehaviour {

	public GameObject PartB;
	public GameObject PartR;
	public GameObject PartJ;

	int b;
	int r;
	int j;


	void Start () {
		PartB.GetComponent<ParticleSystem>().Stop();
		PartR.GetComponent<ParticleSystem>().Stop();
		PartJ.GetComponent<ParticleSystem>().Stop();
	}

	// Use this for initialization
	void BleuIn () {
		b++;
		PartB.GetComponent<ParticleSystem>().Play();
	}

	void BleuOut () {
		b--;
		if (b == 0){
			PartB.GetComponent<ParticleSystem>().Stop();
		}

	}

	void RougeIn () {
		r++;
		PartR.GetComponent<ParticleSystem>().Play();
	}

	void RougeOut () {
		r--;
		if (b == 0) {
			PartR.GetComponent<ParticleSystem> ().Stop ();
		}
	}
 

	void JauneIn () {
		j++;
		PartJ.GetComponent<ParticleSystem>().Play();
	}

	void JauneOut () {
		j--;
		if (b == 0) {
			PartJ.GetComponent<ParticleSystem> ().Stop ();
		}
	}

	/*
	void Update () {
	
	}*/
}
