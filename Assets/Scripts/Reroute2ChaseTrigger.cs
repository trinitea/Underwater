using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reroute2ChaseTrigger : MonoBehaviour
{
    public bool inside;

    void OnTriggerEnter2D(Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.tag == "Player")
        {
            inside = true;
        }
    }

    void OnTriggerExit2D(Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.tag == "Player")
        {
            if (GameObject.FindWithTag("Monster").GetComponent<Monster>().startChase == false & GameObject.FindWithTag("Monster").GetComponent<Monster>().restartChase == false)
            {
                inside = false;
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
        if(inside == true)
        {
            if (GameObject.FindWithTag("Monster").GetComponent<Monster>().rerouteleave2 == true)
            {
                GameObject.FindWithTag("Monster").GetComponent<Monster>().startChase = true;
                GameObject.FindWithTag("Monster").GetComponent<Monster>().restartChase = true;
                GameObject.FindWithTag("Monster").GetComponent<Monster>().rerouteleave2 = false;
                GameObject.FindWithTag("Monster").GetComponent<Monster>().reroute2 = false;
            }
        }
        
    }
}
