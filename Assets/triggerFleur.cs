using UnityEngine;
using System.Collections;

public class triggerFleur : MonoBehaviour {


	public bool bleu;
	public bool rouge;
	public bool jaune;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			if (bleu == true) {
				other.SendMessage ("BleuIn");
			}

			if (rouge == true) {
				other.SendMessage ("RougeIn");
			}

			if (jaune == true) {
				other.SendMessage ("JauneIn");
			}
				

		}
	}

	void OnTriggerExit(Collider other) {
		if (other.tag == "Player") {
			if (bleu == true) {
				other.SendMessage ("BleuOut");
			}

			if (rouge == true) {
				other.SendMessage ("RougeOut");
			}

			if (jaune == true) {
				other.SendMessage ("JauneOut");
			}


		}
	}


	void Update () {
	
	}
}
