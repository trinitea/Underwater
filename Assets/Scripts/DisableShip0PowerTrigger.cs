using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableShip0PowerTrigger : MonoBehaviour
{
    public GameObject ship0PwrTrigger;
    public GameObject player;
    public GameObject monster;
    public GameObject shp;


    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            if (!enabled) return;
            ship0PwrTrigger.SetActive(false);
            shp.SetActive(false);
            
            player.GetComponent<Player>().thrust = 3;
            player.GetComponent<Player>().dashspeed = 25;
            GameObject.Find("superpowerglow").GetComponent<Renderer>().enabled = false;
            //monster.SetActive(true);

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
