using UnityEngine;
using System.Collections;

public class CheckPoint : MonoBehaviour {
    private SystemCourse SC;
    public int numCheckPoint;

    void Start()
    {
        SC = GameObject.Find("SystemCourse").GetComponent<SystemCourse>();
        if (SC == null)
        {
            Debug.LogError("Systeme Course non trouve");
        }
    }

    //Passage d'un check point
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int numJoueur =
                other.GetComponent<VehiculeMovements>().numJoueur;
            SC.CheckPointPasse(numJoueur, numCheckPoint);
        }
    }

}
