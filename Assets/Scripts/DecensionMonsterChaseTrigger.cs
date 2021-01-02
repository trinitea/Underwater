using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecensionMonsterChaseTrigger : MonoBehaviour
{
    public bool inside;
    public GameObject shpPTrigger;


    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
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
        if (inside)
        {
            if (shpPTrigger.GetComponent<ShipPowerTrigger>().superDashBoost == true)
            {
                GameObject.Find("monster").GetComponent<Monster>().speed = 10f;
                GameObject.Find("monster").GetComponent<Monster>().startChase = true;
                GameObject.Find("monster").GetComponent<Monster>().restartChase = true;
            }


        }
        


    }
}
