using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

    public bool playerTwo;

    private float horizMove;
    private bool flipShip = false;
    public float shipSpeed = 3f;
    private Transform sprite;

    private void Awake()
    {
        sprite = this.transform.GetChild(0);
    }

    private void FlipShip()
    {
        flipShip = !flipShip;
        sprite.Rotate(new Vector3(0,0,180));
    }
	
	// Update is called once per frame
	void Update () {

        //Player One
        if (playerTwo == false)
        {
            horizMove = Input.GetAxis("Horizontal") * shipSpeed * Time.deltaTime;
        }
        else //Player Two
        {
            horizMove = Input.GetAxis("Horizontal2") * shipSpeed * Time.deltaTime;
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
