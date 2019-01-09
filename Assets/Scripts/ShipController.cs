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

    public GameObject gameControllerObj;
    private GameController gameController;

    private void Awake()
    {
        flipNode = this.transform.Find("FlipNode");
        weapon = flipNode.Find("Weapon").GetComponent<Weapon>();
        gameController = gameControllerObj.GetComponent<GameController>();
    }

    private void FlipShip()
    {
        flipShip = !flipShip;
        flipNode.Rotate(new Vector3(0,180,0));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cannonball")
        {
            //this player was hit
            gameController.PlayerHit(playerTwo); //pass bool of which player was hit
            Destroy(other.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        //Player One
        if (playerTwo)
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

        if (horizMove > 0 && !flipShip)
        {
            FlipShip();
        }
        else if (horizMove < 0 && flipShip)
        {
            FlipShip();
        }
        transform.Translate(horizMove, 0, 0);

	}
}
