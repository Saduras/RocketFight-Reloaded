using UnityEngine;

public class RocketMotor : MonoBehaviour {

    public Rigidbody rocketRigidbody;
    public float speed = 10f;
	
	// Update is called once per frame
	void LateUpdate () {
        rocketRigidbody.AddForce(transform.forward * speed, ForceMode.Acceleration);
	}
}
