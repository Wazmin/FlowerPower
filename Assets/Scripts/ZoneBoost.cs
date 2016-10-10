using UnityEngine;
using System.Collections;

public class ZoneBoost : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<VehiculeMovements>().ZoneBoost(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<VehiculeMovements>().ZoneBoost(false);
        }
    }
}
