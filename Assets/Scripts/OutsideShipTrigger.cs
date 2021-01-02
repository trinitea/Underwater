using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutsideShipTrigger : MonoBehaviour {

    public GameObject player;
    private Rigidbody2D myRigidbody;

    public GameObject CMvcamwater;
    public GameObject CMvcamship;

    private IEnumerator coroutine;

    public bool insideWater;

    /*public CanvasGroup shpExtCanvas;
    public GameObject waterTrigger;*/

    



    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            
            player.GetComponent<Player>().enabled = true;
            player.GetComponent<PlayerInside>().enabled = false;

            CMvcamwater.SetActive(true);
            CMvcamship.SetActive(false);
          //  insideWater = true;
            
        }
    }

  

    void OnTriggerExit2D(Collider2D Collider)
   {
        if (Collider.gameObject.tag == "Player")
        {
            StartCoroutine("dragCount");
            player.GetComponent<Player>().enabled = true;
            
            CMvcamwater.SetActive(true);
           CMvcamship.SetActive(false);

           // StartCoroutine("delay");

            
        }
    }

    // Use this for initialization
    void Start () {

        myRigidbody = player.GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {

       /* if (waterTrigger != null || shpExtCanvas != null)
        {
            if (insideWater)
            {
                shpExtCanvas.alpha += Mathf.SmoothStep(0, 20, Time.deltaTime);


                waterTrigger.GetComponent<WaterTrigger>().insideShip = false;
            }
        }*/
        
        

    }

    IEnumerator dragCount()
    {
        myRigidbody.drag = 3;
        
        yield return new WaitForSeconds(.5f);

        myRigidbody.drag = 1;
        

        yield return null;
    }

    IEnumerator delay()
    {

    yield return new WaitForSeconds(1f);
    insideWater = false;

        yield return null;
    }

   
}
