using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerOrb : MonoBehaviour
{
    public ParticleSystem circlePulse;
    public GameObject circlePulseObject;
    public Rigidbody2D playerRb;
    public GameObject power;
    public GameObject player;
    public Slider powerSlider;
    public float powerGain;

    public float counter;
    public bool collecting;
    public float waitTime;

    public bool keypress;
    private bool inside;
    public bool countdown;

    public GameObject monster;


    public GameObject mainGameManager;

    
    
    

    

    void OnTriggerStay2D(Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.tag == "Player" )
        {
            inside = true;

            if (keypress == true)
            {
                counter++;
                transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
                keypress = false;
                countdown = true;

            }

            if (countdown == true)
            {
                waitTime -= Time.deltaTime;
            }

            if (counter == 7)
            {
                collecting = true;
            }



            if (waitTime <= 0)
            {
                waitTime = 2;
                counter = 0;
                collecting = false;
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                countdown = false;
            }



            if (collecting)
            {
                circlePulseObject.transform.position = player.transform.position;
                circlePulse.Play();

                if (gameObject.tag == "YesChase")
                {
                    GameObject.FindWithTag("Monster").GetComponent<Monster>().startChase = true;
                    GameObject.FindWithTag("Monster").GetComponent<Monster>().restartChase = true;
                }

                if (gameObject.tag == "NoChase")
                {
                    GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = false;
                }
                else
                {
                    GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = true;
                }    
                
                powerSlider.value += powerGain;
                //Destroy(gameObject);
                gameObject.SetActive(false);

                if(powerSlider.value >= 100)
                {
                    mainGameManager.GetComponent<UIcolourFlash>().powerFillFlash = true;
                    

                }

            }
        }

    }

    void OnTriggerExit2D(Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.tag == "Player")
        {
            
            countdown = true;
            waitTime = 2;
            counter = 0;
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }




    // Use this for initialization
    void Start()
    {
        circlePulseObject = GameObject.Find("circle_pulse_particle");
        circlePulse = circlePulseObject.GetComponent<ParticleSystem>();

        player = GameObject.Find("player");
        playerRb = player.GetComponent<Rigidbody2D>();
        power = GameObject.Find("power");
        powerSlider = GameObject.Find("power").GetComponent<Slider>();

        counter = 0;
        powerSlider = power.GetComponent<Slider>();
        waitTime = 2;

        //playerSpeed = GameObject.FindWithTag("Player").GetComponent<Monster>().thrust;


        mainGameManager = GameObject.FindGameObjectWithTag("mainGameManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftAlt) && inside )
        {
            keypress = true;
           
        }

       // if (inside == true)
        {
           // playerRb.drag = 2;
            //GameObject.FindWithTag("Player").GetComponent<Player>().thrust = 2;
        }
       // if (inside == false)
        {
           // playerRb.drag = 1;
           // GameObject.FindWithTag("Player").GetComponent<Player>().thrust = 3;
        }


    }
}
