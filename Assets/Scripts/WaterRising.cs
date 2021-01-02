using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRising : MonoBehaviour {

    public GameObject shipPivot;
    public bool rising;

    public Collider2D monsterCollider;
    public Collider2D wallCollider;
    //public GameObject wall;

    // Use this for initialization
    void Start () {

        wallCollider = GameObject.FindGameObjectWithTag("Wall").GetComponent<Collider2D>();
        monsterCollider = GameObject.FindGameObjectWithTag("Monster").GetComponent<Collider2D>();
       // wallCollider = wall.GetComponent<Collider2D>();

    }
	
	// Update is called once per frame
	void Update () {

        if (rising & transform.localScale.y < 70.16291f & shipPivot.transform.localScale.y > 0.3729153f)
        {
            
            shipPivot.transform.localScale += new Vector3(0, (-0.00200000f / 3),Time.deltaTime);
        }


        /* if (monsterCollider.IsTouching(wallCollider))
         {

             rising = true;
            
         }*/


       /* if (Input.GetKeyDown(KeyCode.H))
        {

            rising = true;
        }*/






    }

    
}
