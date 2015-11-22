using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public float speed = 10f;

    Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        var movementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        var lookInput = new Vector3(Input.GetAxis("RX"), 0f, Input.GetAxis("RY"));

        _rigidbody.AddForce(movementInput * speed, ForceMode.Force);
        transform.LookAt(transform.position + lookInput * 100f);
	}
}
