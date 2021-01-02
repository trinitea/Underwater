using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2Trigger : MonoBehaviour{

    public GameObject monster;
    public GameObject CMvcamEnterShip2;
    public GameObject CMvcamDescension;
    public GameObject CMvcamWater;
    public GameObject CMvcamShip;


    public bool inside;

    public GameObject ship1;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {

            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("exit");          
            inside = false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (inside == true)
        {
            
            //CMvcamEnterShip2.SetActive(true);
           // CMvcamDescension.SetActive(false);           
            ship1.SetActive(false);

           
            
        }

       /* if (inside == false)
        {
            CMvcamEnterShip2.SetActive(false);
        }*/
    }
}
