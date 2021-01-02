using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGround : MonoBehaviour {

    public PlatformEffector2D effector;
    public float waitTime;
    //public bool falling;
  
    //public GameObject player;



    //public bool grounded;
    //public LayerMask whatIsGround;

    //private Collider2D myCollider;







    // Use this for initialization
    void Start () {

        waitTime = 0.1f;
       
        effector = GetComponent<PlatformEffector2D>();
        //platformtrigger = GetComponent<Collider2D>();

        //myCollider = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if ( waitTime < 0.0f)
        {

            effector.rotationalOffset = 0f;
            waitTime = 0.1f;
        }

        if (Input.GetKey(KeyCode.DownArrow) && waitTime > 0.0f)
        {
           
            {
                effector.rotationalOffset = 180f;

            }
            
        }


        if (effector.rotationalOffset >= 180f)
        {
            waitTime -= Time.time;
        }
    }
}
