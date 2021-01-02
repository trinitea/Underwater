using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoEnd : MonoBehaviour
{

    public bool inside;
    public GameObject demoEndUI;

    void OnTriggerStay2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            if (!enabled) return;

            if (GameObject.FindWithTag("shiptwo").GetComponent<ShipPowerTrigger>().countdownFinished == true)
            {
                inside = true;
            }
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (inside)
        {
            
            
                Time.timeScale = 0f;
                demoEndUI.SetActive(true);

        }
        
    }
}
