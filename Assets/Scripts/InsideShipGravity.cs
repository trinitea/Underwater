using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InsideShipGravity : MonoBehaviour
{
   

    public GameObject player;
    public Rigidbody2D myRigidbody;

    

    

    //public GameObject CMvcamwater;
    //public GameObject CMvcamship;
   
    


    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")

        {

           

            player.GetComponent<Player>().enabled = false;
            player.GetComponent<PlayerInside>().enabled = true;

            //CMvcamwater.SetActive(false);
            //CMvcamship.SetActive(true);


            FindObjectOfType<AudioManager>().Loud("UnderwaterAmbience");
            

        }

       

        
    }

    void OnTriggerStay2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")

        {
            if (!enabled) return;
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<PlayerInside>().enabled = true;

            //CMvcamwater.SetActive(false);
            //CMvcamship.SetActive(true);

            


        }

       

    }

    void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")

        {

            if (!enabled) return;
            player.GetComponent<Player>().enabled = true;
            player.GetComponent<PlayerInside>().enabled = false;

            //CMvcamwater.SetActive(true);
            //CMvcamship.SetActive(false);


            FindObjectOfType<AudioManager>().Quiet("UnderwaterAmbience");
            


        }

         

    }


    // Use this for initialization
    void Start()
    {
        
       

        

    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
}
