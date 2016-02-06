using UnityEngine;

public class RocketMotor : MonoBehaviour {

    public Rigidbody rocketRigidbody;
    public float startVelocity = 15f;
    public float acceleration = 10f;
    public float selfDestructionTime = 5f;

    float _liveTime = 0f;

    void Start()
    {
        rocketRigidbody.velocity = transform.forward * startVelocity;
    }

    void Update()
    {
        _liveTime += Time.deltaTime;

        if (_liveTime > selfDestructionTime)
            Destroy(this.gameObject);
    }

    void LateUpdate () {
        if(rocketRigidbody)
            rocketRigidbody.AddForce(transform.forward * acceleration, ForceMode.Acceleration);
	}
}
