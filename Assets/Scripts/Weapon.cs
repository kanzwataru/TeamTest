using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GameObject projectilePrefab;
	public float force = 300f;
	public float upForceMult = 1.5f;
	public float cooldownTime = 3f;

	float cooldownTimer = 0f;
	bool firing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update() {
		cooldownTimer = Mathf.Clamp(cooldownTimer + Time.deltaTime, 0f, cooldownTime);

		if(firing) {
			if(cooldownTimer >= cooldownTime) {
				cooldownTimer = 0.0f;
				FireProjectile();
			}
		}

		/* DEBUG */
		firing = Input.GetKey(KeyCode.Space);	
	}

	void FireProjectile() {
		var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
		projectile.AddRelativeForce(new Vector3(force,0,0));
	}
}
