using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmPowerOrb : MonoBehaviour
{
    public ParticleSystem circlePulse;
    public GameObject circlePulseObject;
    public GameObject power;
    public GameObject player;
    //public Collider2D playerColl;
    public Slider powerSlider;
    public float powerGain;

    public float counter;
    public bool collecting;
    public float waitTime;

    public bool keypress;
    private bool inside;
    public bool countdown;

    public GameObject monster;

    public float disappearCount;
    public bool startDisappearCount;

    public Collider2D childCollider;
    public Collider2D monsterCollider;

    public bool startC;

    public GameObject shp0Trigger;
    public GameObject shp00Trigger;

    

    ///Orb Collection
    void OnTriggerStay2D(Collider2D BoxCollider2D)
    {



        if (BoxCollider2D.gameObject.tag == "Player")
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




                /*if (shp00Trigger != null)
                {
                    if (shp00Trigger.activeSelf == false)
                    {
                        GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = true;
                    }
                }
                else*/
                    GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = true;



                /*if (shp0Trigger != null)
                {
                    if (shp0Trigger.activeSelf == false)
                    {
                        GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = true;
                    }
                }
                else
                    GameObject.FindWithTag("Monster").GetComponent<Monster>().chanceToChase = true;*/



                transform.Translate(Vector3.up * 5);
                gameObject.GetComponent<Renderer>().enabled = false;
                powerSlider.value += powerGain;

                startDisappearCount = true;


            }


        }

    }

    ///Orb Reset of not Collected
    void OnTriggerExit2D(Collider2D BoxCollider2D)
    {
        if (BoxCollider2D.gameObject.tag == "Player")
        {
            countdown = true;
            waitTime = 2;
            transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
        }
    }




    // Use this for initialization
    void Start()
    {
        circlePulseObject = GameObject.Find("circle_pulse_particle");
        circlePulse = circlePulseObject.GetComponent<ParticleSystem>();
        player = GameObject.Find("player");
        //playerColl = player.GetComponent<BoxCollider2D>();
        power = GameObject.Find("power");
        powerSlider = GameObject.Find("power").GetComponent<Slider>();

        counter = 0;
        powerSlider = power.GetComponent<Slider>();
        waitTime = 2;

        disappearCount = .01f;

        childCollider = gameObject.GetComponentInChildren<Collider2D>();


        shp0Trigger = GameObject.FindGameObjectWithTag("shipzero");
        shp00Trigger = GameObject.FindGameObjectWithTag("shipzerozero");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftAlt) && inside)
        {
            keypress = true;

        }

        if (startDisappearCount == true)
        {
            disappearCount -= Time.deltaTime;

            if (disappearCount <= 0)
            {
                Destroy(gameObject);
            }
        }

    }



}
        

