using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2MonsterCatchUpTrigger : MonoBehaviour
{
    public GameObject monster;
    public GameObject shipPowerTrigger1;
    
    public bool inside;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {

            inside = true;
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
            if (shipPowerTrigger1.activeSelf)
            {
                shipPowerTrigger1.GetComponent<ShipPowerTrigger>().countDown = 0;
            }
                

            if (monster.transform.position.y > -550)
            {
                monster.transform.position = new Vector3(1.5f, -550, 0);
                Destroy(gameObject);
            }

        }
    }
}
