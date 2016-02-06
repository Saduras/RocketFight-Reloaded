using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ExplosionForce : MonoBehaviour {

    public float force = 10f;
    public ForceMode forceMode = ForceMode.Force;
    public float selfDestructionTime = 2f;

    float _radius;
    List<Collider> _hitObjects;
    float _liveTime;

	void Start () {
        _radius = (GetComponent<Collider>() as SphereCollider).radius;
        _liveTime = 0f;
        _hitObjects = new List<Collider>();
    }

    void Update() {
        _liveTime += Time.deltaTime;

        if (_liveTime > selfDestructionTime)
            Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        // Don't hit the same object twice
        if (_hitObjects.Contains(other))
            return;

        _hitObjects.Add(other);

        // Apply force to hit object
        var rigidbody = other.GetComponent<Rigidbody>();
        if(rigidbody != null) {
            var directedForce = (rigidbody.transform.position - this.transform.position).normalized * force;
            rigidbody.AddForce(directedForce, forceMode);
        }
    }
}
