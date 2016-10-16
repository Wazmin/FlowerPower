using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
    public GameObject Vaisseau;
    public int indexjoueur;
    private GameObject Info;




	void Start() {
        Info = GameObject.Find("Info");
        if (indexjoueur == 1)
        {
            Vaisseau = GameObject.Find("Joueur 1/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ1.ToString() + "(Clone)");
            Vaisseau.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
        if (indexjoueur == 2)
        {
            Vaisseau = GameObject.Find("Joueur 2/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ2.ToString() + "(Clone)");
            Vaisseau.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
        if (indexjoueur == 3)
        {
            Vaisseau = GameObject.Find("Joueur 3/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ3.ToString() + "(Clone)");
            Vaisseau.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
        if (indexjoueur == 4)
        {
            Vaisseau = GameObject.Find("Joueur 4/Vaisseau" + Info.GetComponent<GetInfo>().vaisseauJ4.ToString() + "(Clone)");
            Vaisseau.transform.Rotate(0.0f, 0.0f, 180.0f, Space.Self);
        }
    }

	void Update() {
		
	}
}
