﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyPowerUpTrigger : MonoBehaviour
{
    public bool inside;
    public float disappearCount;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D Collider2D)
    {
        inside = true;
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
            InvokeRepeating("Blink", 0.0f, 0.01f);
            player.GetComponent<Decoy>().enabled = true;
        }

        
            
        
           
    }

    void Blink()
    {

        gameObject.SetActive(!gameObject.activeSelf);

        disappearCount++;

        if (disappearCount >= 400)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
