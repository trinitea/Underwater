using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaterTrigger : MonoBehaviour {




    public GameObject CMvcamship;
    public GameObject CMvcamwater;
    public GameObject CMvcamDes;
    public GameObject CMvcamEnterShip2;


  
  /*  public bool insideShip;


    public CanvasGroup shpExtCanvas;
    public OutsideShipTrigger outsideShpTrigger;*/


    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            //Debug.Log("inside");
             CMvcamship.SetActive(true);
             CMvcamwater.SetActive(false);
             CMvcamDes.SetActive(false);
            CMvcamEnterShip2.SetActive(false);
            //insideShip = true;


        }
    }

    void OnTriggerStay2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            
            CMvcamship.SetActive(true);
            CMvcamwater.SetActive(false);
            CMvcamDes.SetActive(false);
            CMvcamEnterShip2.SetActive(false);
           // insideShip = true;
        }
    }







    



    // Use this for initialization
    void Start () {

     

    }
	
	// Update is called once per frame
	void Update () {

      /*  if (outsideShpTrigger != null || shpExtCanvas != null)
        {
            Debug.Log("trigger");
            if (insideShip)
            {
                Debug.Log("inside ship");
                shpExtCanvas.alpha -= Mathf.SmoothStep(0, 20, Time.deltaTime);
                outsideShpTrigger.insideWater = false;
            }
        }*/
        
        
       

    }
}
