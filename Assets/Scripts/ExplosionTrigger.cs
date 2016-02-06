using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class ExplosionTrigger : MonoBehaviour {

    public GameObject explosionPrefab;
    public GameObject meshParent;
    public float destructionDelay = 1f;

    bool _triggered;
    float _destructionTime;

    void Start()
    {
        _triggered = false;
        _destructionTime = float.MaxValue;
    }

    void Update()
    {
        if(_destructionTime < Time.time) 
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (_triggered)
            return;

        _triggered = true;
        _destructionTime = Time.time + destructionDelay;
        meshParent.SetActive(false);

        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
