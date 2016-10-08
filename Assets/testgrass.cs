using UnityEngine;
using System.Collections;

public class testgrass : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter (Collider col)
    {
        if (col.tag=="Player") { 
        Destroy(gameObject);
        }
    }
}
