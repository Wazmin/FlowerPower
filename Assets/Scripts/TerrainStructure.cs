using UnityEngine;
using System.Collections;

public class TerrainStructure : MonoBehaviour {
    public float largeur;
    public float longueur;
    public float rayonSphere;
    public GameObject maillon;
    private GameObject parentMaillage;
    private Vector3 posTmp;
    public float hauteurMin;

    //awake
    void Awake()
    {
        parentMaillage = GameObject.Find("Maillage");
    }

	// Use this for initialization
	void Start () {
        float i = 0.0f;
        float j = 0.0f;
        int nbMaillonsCrees = 0;

        //ajustement du rayon de la sphere
        SphereCollider _sCollider = maillon.GetComponent<SphereCollider>();
        _sCollider.radius = rayonSphere;

        while (i < longueur)
        {
            while (j < largeur)
            {
                posTmp = new Vector3(i, 0.0f, j);
                posTmp.y = Terrain.activeTerrain.SampleHeight(posTmp);
                posTmp.y += hauteurMin;
                GameObject g = (GameObject)Instantiate(maillon, posTmp, maillon.transform.rotation);
                g.transform.SetParent(parentMaillage.transform);
                //g.GetComponent<SphereCollider>().enabled = false;
                j += (rayonSphere*2);
                nbMaillonsCrees++;
            }
            j = 0.0f;
            i += (rayonSphere*2);
        }
        Debug.Log(nbMaillonsCrees + " maillons ont été créés");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
