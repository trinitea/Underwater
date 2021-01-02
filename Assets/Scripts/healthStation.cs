using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class healthStation : MonoBehaviour {

    public GameObject player;
    public GameObject health;
    public float healthGain;
    public Slider healthSlider;
    public bool gainingHealth;
    public Slider powerSlider;
    public GameObject power;
    public float powerDrain;
    public bool inside;

    public PostProcessVolume volume;

    
    Renderer rend;
    public Material[] material;
    public bool keyPress;


    public bool boop;
    public GameObject mainGameManager;

    public bool heal;




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
            heal = false;
        }
    }

    // Use this for initialization
    void Start () {

        powerSlider = power.GetComponent<Slider>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {


        if(keyPress & inside)
        {
            heal = true;
        }

        if (inside & powerDrain <= powerSlider.value & healthSlider.value <100)
        {
            if (keyPress)
            {
                healthSlider.value += healthGain;
                powerSlider.value -= powerDrain;

                volume.weight -= .3f;

                if (healthSlider.value >=55)
                {
                    volume.weight = 0;
                }

                       
            }
           

        }


        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                if (powerSlider.value < powerDrain)
                {
                    mainGameManager.GetComponent<UIcolourFlash>().healLowPower = true;
                }


                StartCoroutine("colourFlash");
                keyPress = true;
            }
            else
            {
                keyPress = false;
                mainGameManager.GetComponent<UIcolourFlash>().healLowPower = false;
            }
            
        }
            
       



    }

    IEnumerator colourFlash()
    {
        
        rend.sharedMaterial = material[1];
        
        yield return new WaitForSeconds(.1f);
        rend.sharedMaterial = material[0];
       
        yield return null;
    }

   
}
