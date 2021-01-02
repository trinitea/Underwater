using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    //public float gravity;

    public float speed;
    public GameObject player;
    private Rigidbody2D myRigidbody;

    void OnTriggerStay2D (Collider2D Collider2D)
    {
        if (!enabled) return;

        if (player.GetComponent<PlayerInside>().enabled == true)
        {
            if (Collider2D.gameObject.tag == "Player" && Input.GetKey(KeyCode.UpArrow))
            {
                myRigidbody.velocity = new Vector2(0, speed);
            }
            else if (Collider2D.gameObject.tag == "Player" && Input.GetKey(KeyCode.DownArrow))
            {
                myRigidbody.velocity = new Vector2(0, -speed);
            }

            //if in water & not moving player doesn't slide down ladder
            //else if (player.GetComponent<Player>().enabled == true)
            //{
            //    myRigidbody.velocity = new Vector2(0, 0);

           // }

            ////if not in water & not moving player doesn't slide down ladder
            else //if (player.GetComponent<PlayerInside>().enabled == true)
            {
                myRigidbody.velocity = new Vector2(0, 0.4f);
            }
        }

           
    }

	// Use this for initialization
	void Start () {

        
        myRigidbody = player.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {


        

    }
}
