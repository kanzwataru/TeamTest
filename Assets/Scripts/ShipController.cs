using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
    public bool playerTwo;

    private float horizMove;
    private bool flipShip = false;
    public float shipSpeed = 3f;
    
    private Transform flipNode;
    private Weapon weapon;

    private void Awake()
    {
        flipNode = this.transform.Find("FlipNode");
        weapon = flipNode.Find("Weapon").GetComponent<Weapon>();
    }

    private void FlipShip()
    {
        flipShip = !flipShip;
        flipNode.Rotate(new Vector3(0,180,0));
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        //Player One
        if (playerTwo == false)
        {
            horizMove = Input.GetAxis("Horizontal") * shipSpeed * Time.deltaTime;
            if(Input.GetKey(KeyCode.RightShift))
                weapon.Fire();
        }
        else //Player Two
        {
            horizMove = Input.GetAxis("Horizontal2") * shipSpeed * Time.deltaTime;
            if(Input.GetKey(KeyCode.LeftShift))
                weapon.Fire();
        }

        if (horizMove > 0 && flipShip == false)
        {
            FlipShip();
        }
        else if (horizMove < 0 && flipShip == true)
        {
            FlipShip();
        }
        transform.Translate(horizMove, 0, 0);

	}
}
