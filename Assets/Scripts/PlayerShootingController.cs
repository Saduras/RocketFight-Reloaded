using UnityEngine;
using System.Collections;

public class PlayerShootingController : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform projectileSpawningPoint;

    public float fireCooldown = 0.2f;

    float timeSinceLastShoot = 0f;
	
	// Update is called once per frame
	void Update () {
        var lookInput = new Vector3(Input.GetAxis("RX"), 0f, Input.GetAxis("RY"));

        transform.LookAt(transform.position + lookInput * 100f);

        var fireInput = Input.GetAxis("Fire") < -0.5f;
        timeSinceLastShoot += Time.deltaTime;

        if (fireInput && timeSinceLastShoot > fireCooldown) {
            timeSinceLastShoot = 0f;
            var projectile = Instantiate(projectilePrefab, projectileSpawningPoint.position, transform.localRotation);
        }
    }
}
