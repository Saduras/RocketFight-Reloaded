using UnityEngine;

public class PlayerShootingController : MonoBehaviour {

    const string HORIZONTAL_AXIS = "RX";
    const string VERTICAL_AXIS = "RY";
    const string FIRE = "Fire";

    public Player player;
    public GameObject projectilePrefab;
    public Transform projectileSpawningPoint;

    public float fireCooldown = 0.2f;

    float timeSinceLastShoot = 0f;
	
	// Update is called once per frame
	void Update () {
        var lookInput = new Vector3(Input.GetAxis(player.ToString() + HORIZONTAL_AXIS), 0f, Input.GetAxis(player.ToString() + VERTICAL_AXIS));

        transform.LookAt(transform.position + lookInput * 100f);

        // Use 5th axis on the controller. Negative value stands for right trigger pressed.
        var fireInput = Input.GetAxis(player.ToString() + FIRE) < -0.5f;
        timeSinceLastShoot += Time.deltaTime;

        if (fireInput && timeSinceLastShoot > fireCooldown) {
            timeSinceLastShoot = 0f;
            var projectile = Instantiate(projectilePrefab, projectileSpawningPoint.position, transform.localRotation);
        }
    }
}
