using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueDisableControls : MonoBehaviour
{
    public GameObject player;
    public GameObject shipGravity;
    public GameObject groundPlatform;
    public GameObject bubbles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.GetComponent<PlayerInside>().enabled = false;
        shipGravity.GetComponent<InsideShipGravity>().enabled = false;
        groundPlatform.GetComponent<DisableGround>().enabled = false;
        bubbles.SetActive(false);
    }

    void OnDisable()
    {
        shipGravity.GetComponent<InsideShipGravity>().enabled = true;
        groundPlatform.GetComponent<DisableGround>().enabled = true;
        bubbles.SetActive(true);
    }
}
