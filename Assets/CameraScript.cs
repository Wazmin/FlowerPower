using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	//public GameObject CameraPos;
	public Transform target;
	public Transform lookatTarget;
	public float speed;
	public float distance;
	public float maxDistance;
	public float DampMultiplier;


	void Start () {
	
	}
	

	void FixedUpdate () {
		distance = Vector3.Distance(target.position, transform.position);
		//print (distance);
		transform.position = Vector3.MoveTowards (transform.position, target.position, Time.deltaTime * (speed + (Mathf.Clamp(distance - maxDistance, 0, 30))* DampMultiplier) );
		transform.LookAt (lookatTarget);

	}
}
