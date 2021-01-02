using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class ShipPowerTrigger : MonoBehaviour
{

    public GameObject player;

    public float shipPowerGain;
    public Slider shipPowerSlider;

    public Slider powerSlider;
    public GameObject power;
    public float powerDrain;
    public bool inside;

    public bool dashBoost;
    public bool startCountDown;
    public float countDown;


    
    public Material[] material;

    public GameObject mainGameManager;
    public bool keyPress;

    public bool broken;
    public ParticleSystem sparks;


    public bool powerGiven;

    /////

    private Rigidbody2D playerRb;
    public bool superDashBoost;
    public GameObject ship;
    public GameObject shipPower;

    public GameObject eye;

    public GameObject fPlatform1;
    public bool freeze;
    public bool blend;
    [SerializeField] private GameObject clone;
    public PostProcessVolume volume;
    public PostProcessVolume desVolume;
    public PostProcessProfile profileDesSwitch;
    public PostProcessProfile profileHealthSwitch;
    private IEnumerator coroutine;
    public GameObject Descender;
    public float smoothTime;
    private Vector3 velocity = Vector3.zero;
    public float blendCountDown;
    public GameObject shipGrp;
    public float blinkTime;
    public bool startBlink;
    public float Counter;
    public bool startBlinkCount;
    public Renderer rend;
    public GameObject CMvcamDescensionWide;
    public GameObject CMvcamship;
    public GameObject CMvcamEnterShip2;
    public GameObject CMvcamwater;
    public GameObject ship2;
    public GameObject ship1;
    public GameObject ship0;


    public GameObject CMvcamVolume;

    public GameObject newPos;
    public bool changeCloneStartPos;
    public bool countdownFinished;

    public GameObject cloneStartPos;

    public float currentFillRequirement;
    public Renderer cloneRend;
    public GameObject energySprite;

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
            powerGiven = false;
        }
    }

    // Use this for initialization
    void Start()
    {

        powerSlider = power.GetComponent<Slider>();
        shipPowerSlider = shipPower.GetComponent<Slider>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        playerRb= player.GetComponent<Rigidbody2D>();

        //InvokeRepeating("brokenFlicker", 0.1f, 0.03f);

        if (gameObject.tag == "shipzerozero")
        {
            
            broken = true;
        }

    }

    // Update is called once per frame
    void Update()
    {

        shipPowerSlider.maxValue = currentFillRequirement;

        if (gameObject.tag == "shipzerozero")
        {
            currentFillRequirement = 180;
            
        }

        if (gameObject.tag == "shipzero")
        {
            currentFillRequirement = 210;
        }

        if (gameObject.tag == "shipone")
        {
            currentFillRequirement = 360;
        }

        if (gameObject.tag == "shiptwo")
        {
            currentFillRequirement = 540;
        }


        if (inside & powerDrain <= powerSlider.value & shipPowerSlider.value < (currentFillRequirement - 0.01f) & superDashBoost == false)
        {
            if (broken == false)
            {
                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    shipPowerSlider.value += shipPowerGain;
                    powerSlider.value -= powerDrain;


                    if ((gameObject.tag == "shipone") || (gameObject.tag == "shiptwo"))
                    {
                        dashBoost = true;
                    }

                    powerGiven = true;






                    countDown = 40;

                    if (broken)
                    {
                        dashBoost = false;
                        sparks.Play();
                    }
                }
            }
                

        }

       /* if(shipPowerSlider.value >= 60)
        {
            broken = false;
        }*/




        if (inside & broken == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                if (powerSlider.value < powerDrain)
                {
                    mainGameManager.GetComponent<UIcolourFlash>().powerBoostLowPower = true;
                }


                StartCoroutine("colourFlash");
                keyPress = true;
            }
            else
            {
                keyPress = false;
                mainGameManager.GetComponent<UIcolourFlash>().powerBoostLowPower = false;
            }

        }


        if (dashBoost == true)
        {
            player.GetComponent<Player>().dashspeed = 40;
            player.GetComponent<Player>().thrust = 5.5f;
            startCountDown = true;
            GameObject.Find("powerglow").GetComponent<Renderer>().enabled = true;
        }

        if (startCountDown == true)
        {
            countDown -= Time.deltaTime;
        }

        if (countDown <= 0)
        {
            player.GetComponent<Player>().dashspeed = 25;
            player.GetComponent<Player>().thrust = 3;
            dashBoost = false;
            superDashBoost = false;
            startCountDown = false;
            countDown = 40;
            GameObject.Find("powerglow").GetComponent<Renderer>().enabled = false;
            GameObject.Find("superpowerglow").GetComponent<Renderer>().enabled = false;
        }

        

        ////////decension power up

        if (shipPowerSlider.value == currentFillRequirement)
        {
            StartCoroutine("Transform");
            shipPowerSlider.value = currentFillRequirement - 0.01f;
            freeze = true;
            superDashBoost = true;
            dashBoost = false;

            if (GameObject.FindWithTag("shiptwo"))
            {
                changeCloneStartPos = true;
            }
        }

        if (superDashBoost == true)
        {
            player.GetComponent<Player>().dashspeed = 45;
            player.GetComponent<Player>().thrust = 7.5f;
            startCountDown = true;
            GameObject.Find("superpowerglow").GetComponent<Renderer>().enabled = true;
        }

        if (freeze == true)
        {
            countDown = 50;


            player.GetComponent<Player>().enabled = false;
            player.GetComponent<PlayerInside>().enabled = false;
            fPlatform1.GetComponent<DisableGround>().enabled = false;

            if (GameObject.FindWithTag("shiptwo"))
            {
                ship.GetComponent<InsideShipGravity>().enabled = false;
            }
                

        }

        /*if(changeCloneStartPos == true)
        {
            clone.transform.position = newPos.transform.position;
        }*/

        if (blend == true)
        {

            changeCloneStartPos = false;


            CMvcamVolume.SetActive(true);

            if (volume.weight <= 1)
            {
                volume.weight += Mathf.SmoothStep(0, 1, Time.deltaTime*1.5f);

            }
            StopCoroutine("Transform");



           


            clone.transform.position = Vector3.SmoothDamp(clone.transform.position, player.transform.position, ref velocity, smoothTime);
            clone.transform.localScale -= new Vector3(0.006f, 0.003f, 0.003f);
            blendCountDown -= Time.deltaTime;

            
        }

        if (blendCountDown <= 0)
        {
            blend = false;
           // freeze = false;

            //cloneRend = clone.GetComponent<Renderer>();
            //cloneRend.sharedMaterial = material[2];

            clone.transform.parent = player.transform;
            blendCountDown = 11;
            
            startBlink = true;


        }
        
        if(startBlink == true)
        {
            if (gameObject.tag == "shiptwo")
            {
                InvokeRepeating("Blink", 0.0f, 0.01f);
            }
                
            startBlink = false;

            if (gameObject.tag == "shipzerozero")
            {
                StartCoroutine("CountDownShip00");
            }


            if (gameObject.tag == "shipzero")
            {
                StartCoroutine("CountDownShip0");
            }


            if (gameObject.tag == "shipone")
            {
                StartCoroutine("CountDownShip1");
            }

            if (gameObject.tag == "shiptwo")
            {
                StartCoroutine("CountDownShip2");
            }


        }



        ///pause for end of demo 
        /*if (countdownFinished)
        {
            if (GameObject.FindWithTag("shiptwo"))
            {
                Time.timeScale = 0f;
            }
        }*/
        
            
       


    }

    IEnumerator colourFlash()
    {

        rend.sharedMaterial = material[1];

        yield return new WaitForSeconds(.1f);
        rend.sharedMaterial = material[0];

        yield return null;
    }

    IEnumerator Transform()
    {

        yield return new WaitForSeconds(1);

        Instantiate(Descender);
        clone = GameObject.FindWithTag("Descender");
        clone.transform.position = cloneStartPos.transform.position;

        

        blend = true;
        shipPower.SetActive(false);
        eye.SetActive(false);

        

        yield return null;
    }


    IEnumerator CountDownShip00()
    {
        //Debug.Log("countdown started");
        yield return new WaitForSeconds(1.7f);
        CancelInvoke("Blink");
        rend.enabled = false;
        energySprite.SetActive(false);
        //shipGrp.SetActive(false);


        CMvcamship.SetActive(false);
        CMvcamEnterShip2.SetActive(false);
        CMvcamwater.SetActive(false);
        CMvcamDescensionWide.SetActive(true);
        desVolume.isGlobal = true;


        /*player.GetComponent<PlayerInside>().enabled = false;
        player.GetComponent<Player>().enabled = true;
        playerRb.drag = 1;
        playerRb.gravityScale = .1f;*/


        yield return new WaitForSeconds(.1f);
        

        countdownFinished = true;



        ship0.SetActive(true);

        player.GetComponent<PlayerInside>().enabled = true;
        fPlatform1.GetComponent<DisableGround>().enabled = true;


        freeze = false;

        cloneRend = clone.GetComponent<Renderer>();
        cloneRend.sharedMaterial = material[2];



        yield return null;
    }


    IEnumerator CountDownShip0()
    {
        //Debug.Log("countdown started");
        yield return new WaitForSeconds(1.7f);
        CancelInvoke("Blink");
        rend.enabled = false;
        //shipGrp.SetActive(false);


        CMvcamship.SetActive(false);
        CMvcamEnterShip2.SetActive(false);
        CMvcamwater.SetActive(false);
        CMvcamDescensionWide.SetActive(true);
        desVolume.isGlobal = true;


        player.GetComponent<PlayerInside>().enabled = false;
        player.GetComponent<Player>().enabled = true;
        playerRb.drag = 1;
        playerRb.gravityScale = .1f;


        yield return new WaitForSeconds(.1f);
        

        countdownFinished = true;



        ship1.SetActive(true);

        player.GetComponent<PlayerInside>().enabled = true;
        fPlatform1.GetComponent<DisableGround>().enabled = true;


        freeze = false;

        cloneRend = clone.GetComponent<Renderer>();
        cloneRend.sharedMaterial = material[2];

        yield return null;
    }

    IEnumerator CountDownShip1()
    {
        //Debug.Log("countdown started");
        yield return new WaitForSeconds(1.7f);
        CancelInvoke("Blink"); 
        rend.enabled = false;
        //shipGrp.SetActive(false);

       
        CMvcamship.SetActive(false);
        CMvcamEnterShip2.SetActive(false);
        CMvcamwater.SetActive(false);
        CMvcamDescensionWide.SetActive(true);
        desVolume.isGlobal = true;

        
        player.GetComponent<PlayerInside>().enabled = false;
        player.GetComponent<Player>().enabled = true;
        playerRb.drag = 1;
        playerRb.gravityScale = .1f;
        

        yield return new WaitForSeconds(.1f);
      /*  GameObject.Find("monster").GetComponent<Monster>().speed = 10f;
        GameObject.Find("monster").GetComponent<Monster>().startChase = true;
        GameObject.Find("monster").GetComponent<Monster>().restartChase = true;*/

        countdownFinished = true;



        ship2.SetActive(true);

        player.GetComponent<PlayerInside>().enabled = true;
        fPlatform1.GetComponent<DisableGround>().enabled = true;


        freeze = false;

        cloneRend = clone.GetComponent<Renderer>();
        cloneRend.sharedMaterial = material[2];



        yield return null;
    }


    IEnumerator CountDownShip2()
    {
        //Debug.Log("countdown started");
        yield return new WaitForSeconds(1.7f);
        CancelInvoke("Blink");
        rend.enabled = false;
        shipGrp.SetActive(false);


        CMvcamship.SetActive(false);
        CMvcamEnterShip2.SetActive(false);
        CMvcamwater.SetActive(false);
        CMvcamDescensionWide.SetActive(true);
        desVolume.isGlobal = true;


        player.GetComponent<PlayerInside>().enabled = false;
        player.GetComponent<Player>().enabled = true;
        playerRb.drag = 1;
        playerRb.gravityScale = .1f;


        yield return new WaitForSeconds(4);
        GameObject.Find("monster").GetComponent<Monster>().speed = 10f;
        GameObject.Find("monster").GetComponent<Monster>().startChase = true;
        GameObject.Find("monster").GetComponent<Monster>().restartChase = true;

        countdownFinished = true;



        //ship2.SetActive(true);



        yield return null;
    }

    void Blink()
    {
        shipGrp.SetActive(!shipGrp.activeSelf);
        
    }

    void brokenFlicker()
    {
        int state = Random.Range(0, 2);

        if (state == 1)
            rend.sharedMaterial = material[1];
        else
            rend.sharedMaterial = material[0];

    }
}


