using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour {

    const string HORIZONTAL_AXIS = "LX";
    const string VERTICAL_AXIS = "LY";

    public Player player = Player.P1;
    public float speed = 10f;

    Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var movementInput = new Vector3(Input.GetAxis(player.ToString() + HORIZONTAL_AXIS), 0f, Input.GetAxis(player.ToString() + VERTICAL_AXIS));

        _rigidbody.MovePosition(_rigidbody.position + movementInput * speed * Time.deltaTime);
	}
}
