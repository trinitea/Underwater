using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerFarmCoroutine : MonoBehaviour {

    public bool restart;
    public bool instantiated; 
    public bool inside;
    public bool alreadyStarted;
    private IEnumerator coroutine;
    public GameObject powerorb;
    public Material[] material;
    Renderer rend;

    public Slider powerSlider;
    public GameObject power;
    public float powerDrain;

    public bool startCountDown;
    public float countDown;

    public float counter;
    public bool startBlink;
    public float disappearCount;

   

    void OnTriggerStay2D(Collider2D Collider2D)
    {
        if (Collider2D.gameObject.tag == "Player")
        {
            if (instantiated == false)
            {
                inside = true;
            }
        }

        
    }

    void OnTriggerExit2D(Collider2D Collider2D)
    {
        if (Collider2D.gameObject.tag == "Player")
        {
            inside = false;
        }

        if (Collider2D.gameObject.tag == "FarmOrb")
        {
           instantiated = false;
           rend.sharedMaterial = material[0];

           startCountDown = true;

            if (counter == 3)
            {
                //InvokeRepeating("Blink", 0.0f, 0.01f);
                //StartCoroutine("CountDown");
                startBlink = true;
            }

           
        }


    }


        // Use this for initialization
    void Start () {

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        countDown = .7f;
        restart = true;

        

    }
	
	// Update is called once per frame
	void Update () {    

        if (inside && Input.GetKeyDown(KeyCode.LeftAlt) & powerDrain <= powerSlider.value & alreadyStarted == false & restart==true)
        {
            restart = false;
            if (gameObject.tag == "TutorialFarm")
            {
            StartCoroutine("spawningFast");
            }
            else
            StartCoroutine("spawning");
            
        }


        if (instantiated == true)
        {
            StopCoroutine("spawningFast");
            StopCoroutine("spawning");
            alreadyStarted = false;
            

        }

        if (startCountDown == true)
        {
            countDown -= Time.deltaTime;

            if (countDown <= 0)
            {
                restart = true;
                countDown = .7f;
                startCountDown = false;
            }

        }

        if(startBlink == true)
        {
            InvokeRepeating("Blink", 0.0f, 0.01f);
        }

        
        
    }

    IEnumerator spawning()
    {
        if (counter == 0)
        {
          rend.sharedMaterial = material[1];
        }

        if (counter == 1)
        {
            rend.sharedMaterial = material[2];
        }

        if (counter == 2)
        {
            rend.sharedMaterial = material[3];
        }


        powerSlider.value -= powerDrain;
        alreadyStarted = true;

        if(gameObject.tag == "DamagedFarm")
        {
            counter++;
        }
        
        

        yield return new WaitForSeconds(35);
        Instantiate(powerorb, transform.position, transform.rotation);
        instantiated = true;
        inside = false;
        yield return null;

    }

    IEnumerator spawningFast()
    {
        if (counter == 0)
        {
            rend.sharedMaterial = material[1];
        }

        if (counter == 1)
        {
            rend.sharedMaterial = material[2];
        }

        if (counter == 2)
        {
            rend.sharedMaterial = material[3];
        }


        powerSlider.value -= powerDrain;
        alreadyStarted = true;

        if (gameObject.tag == "DamagedFarm")
        {
            counter++;
        }



        yield return new WaitForSeconds(12);
        Instantiate(powerorb, transform.position, transform.rotation);
        instantiated = true;
        inside = false;
        yield return null;

    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        yield return null;
    }

    void Blink()
    {

        gameObject.SetActive(!gameObject.activeSelf);

        disappearCount++;

        if (disappearCount >= 200)
        {
            Destroy(gameObject);
        }
    }

    


}
