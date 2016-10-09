using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float rotationSpeed;
	public Vector3 rotationAxis;

	private Transform myTransform;

	void Awake() {
		myTransform = transform;
	}

	void Update() {
		myTransform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.Self);
	}
}
