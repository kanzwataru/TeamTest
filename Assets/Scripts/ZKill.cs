using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZKill : MonoBehaviour {
	public float height = -30f;
	Transform xform;

	// Use this for initialization
	void Start () {
		xform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if(xform.position.y < height) {
			Destroy(gameObject);
		}
	}
}
