using UnityEngine;
using System.Collections;

public class Maillon : MonoBehaviour {
    public MeshRenderer herbe;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        herbe.enabled = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            herbe.enabled = false;
        }
    }
}
