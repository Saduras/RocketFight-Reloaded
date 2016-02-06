using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour {

    const string HORIZONTAL_AXIS = "LX";
    const string VERTICAL_AXIS = "LY";

    public Player player = Player.P1;
    public float speed = 10f;
    public float controlLossVelocity = 2f;

    Rigidbody _rigidbody;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        var movementInput = new Vector3(Input.GetAxis(player.ToString() + HORIZONTAL_AXIS), 0f, Input.GetAxis(player.ToString() + VERTICAL_AXIS));
        var controlledMovement = movementInput * speed;

        var controlFactor = 1 - Mathf.Clamp(_rigidbody.velocity.magnitude, 0f, controlLossVelocity) / controlLossVelocity;
        var totalMovement = controlledMovement * controlFactor + _rigidbody.velocity;

        _rigidbody.MovePosition(_rigidbody.position + totalMovement * Time.deltaTime);

        Debug.DrawRay(this.transform.position, _rigidbody.velocity, Color.red);
	}
}
