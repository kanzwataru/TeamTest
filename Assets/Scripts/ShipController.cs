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
    private int degree = 1;
    public float adjustDegree = 60;

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

    private void PlayerAdjustAngle()
    {
        if (playerTwo) //Player Two (ARROWS)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                if (degree < 2)
                {
                    gameController.PlayerAngleChange(2, 1, degree); //add one arrow
                    weapon.force += adjustDegree;
                    degree++;
                }
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                if (degree > 0)
                {
                    gameController.PlayerAngleChange(2, -1, degree); //remove one arrow
                    weapon.force -= adjustDegree;
                    degree--;
                }
            }
        }
        else //Player One (WASD)
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                if (degree < 2)
                {
                    gameController.PlayerAngleChange(1, 1, degree); //add one arrow
                    weapon.force += adjustDegree;
                    degree++;
                }
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                if (degree > 0)
                {
                    gameController.PlayerAngleChange(1, -1, degree); //remove one arrow
                    weapon.force -= adjustDegree;
                    degree--;
                }
            }
        }
    }

    private void Update()
    {
        //Adjusting shooting angle
        PlayerAdjustAngle();
    }

    void FixedUpdate () {
        
        //Moving

        if (playerTwo) //Player Two (ARROWS)
        {
            horizMove = Input.GetAxis("Horizontal") * shipSpeed * Time.deltaTime;
            if(Input.GetKey(KeyCode.RightShift))
                weapon.Fire(); //Fire cube
        }
        else //Player One (WASD)
        {
            horizMove = Input.GetAxis("Horizontal2") * shipSpeed * Time.deltaTime;
            if(Input.GetKey(KeyCode.LeftShift))
                weapon.Fire(); //Fire cube
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
