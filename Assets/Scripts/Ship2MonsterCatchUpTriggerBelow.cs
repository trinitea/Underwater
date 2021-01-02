using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship2MonsterCatchUpTriggerBelow : MonoBehaviour
{

    public GameObject monster;
    public bool inside;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            if (monster.GetComponent<Monster>().startChase == true || monster.GetComponent<Monster>().restartChase == true)
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
        if (inside == true)
        {
            

            if (monster.transform.position.y < -642)
                {
                    monster.transform.position = new Vector3(1.5f, -642, 0);
                    inside = false;
                }
            
           

        }
    }
}

