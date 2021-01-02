using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMonsterChase : MonoBehaviour
{
    public GameObject powerOrb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (powerOrb != null)
        {
            if (powerOrb.activeSelf == true)
            {
                GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = false;
            }
        }
    }
}
