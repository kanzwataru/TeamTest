using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject projectilePrefab;
	public float force = 500f;
	public float upForceMult = 1.5f;
	public float cooldownTime = 3f;

	float cooldownTimer = 0f;
	bool firing = false;
    Vector3 shootPos;
	
	void Update() {
		cooldownTimer = Mathf.Clamp(cooldownTimer + Time.deltaTime, 0f, cooldownTime);

		if(firing) {
			if(cooldownTimer >= cooldownTime) {
				cooldownTimer = 0.0f;
				FireProjectile();
			}
		}

		firing = false;
	}

	void FireProjectile() {
        shootPos = new Vector3(transform.position.x, transform.position.y + 0.75f, transform.position.z);
        var projectile = Instantiate(projectilePrefab, shootPos, transform.rotation).GetComponent<Rigidbody>();
		projectile.AddRelativeForce(new Vector3(force, 0, 0));
	}

	public void Fire() {
		firing = true;
	}
}
