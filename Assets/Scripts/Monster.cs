using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using Cinemachine;

public class Monster : MonoBehaviour
{

    #region Variables
    private IEnumerator coroutine;

    public bool chase;
    public bool stopBashing;


    public GameObject waterPivot;

    [Header("Chasing")]
    public bool chanceToChase;
    public bool startChase;
    public bool restartChase;
    public float speed;
    private Transform target;
    //public GameObject powerorb2;
    private Rigidbody2D rb;
    public Rigidbody2D playerRb;
    public float thrust;
    public GameObject player;
    private bool coroutineStarted;
    public ParticleSystem rectPulse;
    public ParticleSystem rectPulseSharp;





    [Header("Damage")]
    public Slider healthSlider;
    private GameObject health;
    public float healthLoss;
    public PostProcessVolume volume;



    [Header("Collide")]
    private Collider2D monsterCollider;
    public Collider2D playerCollider;
    public Collider2D wallCollider;
    public Collider2D wallCollider2;
    public bool backOffCountDown;
    public float backOffCount = 1f;
    public CinemachineVirtualCamera camShip;
    private CinemachineBasicMultiChannelPerlin camShipNoise;
    public bool shipShake;
    public float shipShaking = .8f;

    [Header("Monster Stun")]

    public bool playerInside;
    public bool playerWasDashing = false;

    public Material[] material;
    Renderer rend;
    public bool startChaseCountDown;
    public float chaseCountDown;
    public CinemachineVirtualCamera camWater;
    private CinemachineBasicMultiChannelPerlin camWaterNoise;
    public CinemachineVirtualCamera camDes;
    private CinemachineBasicMultiChannelPerlin camDesNoise;
    public bool stunShake;
    public float stunShaking = .1f;

    [Header("Knockback Player")]
    public bool knockback;
    public float knockTime;
    public float waitTime;
    public bool countDown;
    //public bool pause;
    public float counter;
    public Slider powerSlider;
    public GameObject power;




    //public bool testBool;
    [Header("Descension Chase")]
    public bool startBashCountDown;
    public float bashCountDown;
    public float bashCounter = 0;

    public bool wall2;
    public bool leave = false;
    public bool leave2 = false;
    public bool leave3 = false;
    public bool leave4 = false;
    public GameObject leavingTarget;
    public GameObject leavingTarget2;
    public GameObject leavingTarget3;
    public GameObject leavingTarget4;

    public CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin camNoise;
    public bool shake;
    public float shaking = .3f;

    public Rigidbody2D cp1;
    public Rigidbody2D cp2;
    public Rigidbody2D cp3;

    [Header("Chasing Decoy")]

    public bool decoyChase;
    public GameObject DecoyPlayer;

    [Header("Waypoint Pathfind")]

    public bool reroute1;
    public bool rerouteleave1;
    public GameObject Rwaypoint1;
    public GameObject rerouteTrigger1;
    public bool reroute2;
    public bool rerouteleave2;
    public GameObject Rwaypoint2;
    public GameObject rerouteTrigger2;
    public bool CaveWallBash;
    public Transform caveWall;
    public float distance;
    public bool WallBashReroute;

    public GameObject ClosestWP;

    public GameObject FindClosestWaypoint()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("WBwaypoint");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = player.transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

    //[Header("Lunging")]

    //public RaycastHit rayHit;

    //public float jumpDist ;
    //public float distance;



    #endregion




    //Monster Stun
    void OnTriggerEnter2D(Collider2D Collider)
        {
            if (Collider.gameObject.tag == "Player")
            {
                playerInside = true;
            }
        }

    void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            playerInside = false;
        }
    }

    


    //Monster Wall and Wall2 Collision




    void OnCollisionStay2D(Collision2D Colliding)
    {
        if (Colliding.gameObject.tag == "Wall2")
        {
            if (stopBashing == false)
            {
                Debug.Log("touching");
                //coroutineStarted = true;
                //StopCoroutine("chasing");
                startChase = false;
                reroute1 = false;
                reroute2 = false;

                if (restartChase == true)
                {
                    restartChase = false;
                }

                startBashCountDown = true;

                wall2 = true;
            }
           
        }
        if (Colliding.gameObject.tag == "Wall")
        {
            //coroutineStarted = true;
            //StopCoroutine("chasing");
            startChase = false;
            WallBashReroute = false;

            if (restartChase == true)
            {
                restartChase = false;
               
            }
            Debug.Log("rising");
            waterPivot.GetComponent<WaterRising>().rising = true;

            shipShake = true;

        }

        if (Colliding.gameObject.tag == "RerouteCollide1")
        {
            Debug.Log("touching");
            //coroutineStarted = true;
            //StopCoroutine("chasing");
            startChase = false;

            if (restartChase == true)
            {
                restartChase = false;
            }

            startBashCountDown = true;

            reroute1 = true;
        }

        if (Colliding.gameObject.tag == "RerouteCollide2")
        {
            Debug.Log("touching");
            //coroutineStarted = true;
            //StopCoroutine("chasing");
            startChase = false;

            if (restartChase == true)
            {
                restartChase = false;
            }

            startBashCountDown = true;

            reroute2 = true;
        }

        if (Colliding.gameObject.tag == "CaveWallBash")
        {
            
            //coroutineStarted = true;
            //StopCoroutine("chasing");
            startChase = false;

            if (restartChase == true)
            {
                restartChase = false;
            }

            WallBashReroute = true;
        }

    }


    // Use this for initialization
    void Start()
    {
        

        caveWall = GameObject.FindGameObjectWithTag("CaveWallBash").GetComponent<Transform>();

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        monsterCollider = GetComponent<Collider2D>();
        wallCollider = GameObject.FindGameObjectWithTag("Wall").GetComponent<Collider2D>();
        wallCollider2 = GameObject.FindGameObjectWithTag("Wall2").GetComponent<Collider2D>();

        waitTime = 0.3f;

        coroutineStarted = false;
        chaseCountDown = 1.5f;

        powerSlider = power.GetComponent<Slider>();

        bashCountDown = .2f;


        camNoise = cam.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        camWaterNoise = camWater.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        camShipNoise = camShip.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        camDesNoise = camDes.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;



    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (chase == true)
        {
            Vector3 dir = (target.transform.position - rb.transform.position).normalized;
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);
        }

        



        #region Knockback Player Physics and Camera
        if (knockback)
        {
            //monster moving away from you when it hits you
            Vector3 dir = (rb.transform.position - target.transform.position).normalized;
            rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);


            playerRb.drag = 8;

            Vector2 difference = (playerRb.transform.position - rb.transform.position);
            
            difference = difference.normalized * thrust;
           
            playerRb.AddForce(difference, ForceMode2D.Impulse);
            camWaterNoise.m_AmplitudeGain = 12;
            camWaterNoise.m_FrequencyGain = 12;
            camDesNoise.m_AmplitudeGain = 12;
            camDesNoise.m_FrequencyGain = 12;


            if (waitTime <= 0)
            {
                playerRb.drag = 1;
                knockback = false;
                player.GetComponent<Player>().enabled = true;
                waitTime = 0.3f;
                countDown = false;
                camWaterNoise.m_AmplitudeGain = 0;
                camWaterNoise.m_FrequencyGain = 0;
                camDesNoise.m_AmplitudeGain = 0;
                camDesNoise.m_FrequencyGain = 0;

            }


        }
        #endregion

       

    }



    void Update()
    {
        waterPivot = GameObject.FindGameObjectWithTag("WaterPivot");


        //Counts how many times monster is stunned, not currently used for anything 
        if (counter == 3)
        {
            counter = 0;
        }

        #region stun
        
        if (playerInside)
        {
            if (player.GetComponent<Player>().dashing && !playerWasDashing)
            {
                playerWasDashing = false;
                counter++;
                //coroutineStarted = true;
                //StopCoroutine("chasing");
                startChaseCountDown = true;
                startChase = false;
                restartChase = false;
                StartCoroutine("backoff");
                stunShake = true;
            }

        }
        
        #endregion

        #region Begin Chasing
        if (chanceToChase == true)
        {
            if(startChase==true || restartChase == true)
            {
                rectPulseSharp.Play();
            }
            else
            {
                rectPulse.Play();
            }
            
            chanceToChase = false;

            if (Random.value > 0.6f)
            {
                rectPulseSharp.Play();

                StartCoroutine("chaseDelay");
                
            }
        }

        if (startChase == true || restartChase==true)
        {
            chase = true;
        }

        if (startChase == false & restartChase == false)
        {
            chase = false;
        }

        //if (startChase == true && coroutineStarted == false)

        //{
        //StartCoroutine("chasing");

        //}

        if (startChase == false & restartChase == false)
        {
            rend.sharedMaterial = material[0];
        }

        if (startChase == true || restartChase == true)
        {
            if(startChaseCountDown == true)
            {
                rend.sharedMaterial = material[3];
            }
            if (startChaseCountDown == false)
            {
                rend.sharedMaterial = material[2];
            }
                
        }



        #endregion

        #region  Stun Camera Shake
        if (stunShake == true)
        {
            stunShaking -= Time.deltaTime;
            if (shaking >= 0)
            {
                camWaterNoise.m_AmplitudeGain = 25;
                camWaterNoise.m_FrequencyGain = 24;
                camDesNoise.m_AmplitudeGain = 25;
                camDesNoise.m_FrequencyGain = 24;
                //Time.timeScale = 0.7f;
            }

            if (stunShaking <= 0)
            {
                camWaterNoise.m_AmplitudeGain = 0;
                camWaterNoise.m_FrequencyGain = 0;
                camDesNoise.m_AmplitudeGain = 0;
                camDesNoise.m_FrequencyGain = 0;
                stunShake = false;
                stunShaking = .1f;
                //Time.timeScale = 1f;
            }
        }

        #endregion

        #region Restart Chase after Monster Stunned
        if (startChaseCountDown == true)
        {
            chaseCountDown -= Time.deltaTime;
            rend.sharedMaterial = material[1];

        }

        if (chaseCountDown <= 0)
        {

            chaseCountDown = 1.5f;
            startChaseCountDown = false;
            restartChase = true;
            StopCoroutine("backoff");

            if(startChaseCountDown == false)
            {
                rend.sharedMaterial = material[2];
            }

            if (startChaseCountDown == true)
            {
                rend.sharedMaterial = material[3];
            }

        }

        if (restartChase == true)
        {
            //StartCoroutine("chasing");
            chase = true;
        }
        #endregion

        #region Regular Wall collision camera Shake
        if (shipShake == true)
        {
            shipShaking -= Time.deltaTime;
            if (shipShaking >= 0)
            {
                camShipNoise.m_AmplitudeGain = 4;
                camShipNoise.m_FrequencyGain = 2;
            }

            if (shipShaking <= 0)
            {
                camShipNoise.m_AmplitudeGain = 0;
                camShipNoise.m_FrequencyGain = 0;
                shipShake = false;
                shipShaking = .8f;
            }
        }
        #endregion

        #region Wall2 collision camera shake
        if (shake == true)
        {
            shaking -= Time.deltaTime;
            if (shaking >= 0)
            {
                camNoise.m_AmplitudeGain = 3;
                camNoise.m_FrequencyGain = 3;
            }

            if (shaking <= 0)
            {
                camNoise.m_AmplitudeGain = 0;
                camNoise.m_FrequencyGain = 0;
                shake = false;
                shaking = .3f;
            }
        }

        #endregion

        #region Bashing against Wall2

        if (startBashCountDown == true)
        {
            bashCountDown -= Time.deltaTime;
            StartCoroutine("backoff");
            

            if (wall2 == true)
            {
                shake = true;
            }
           


            if (bashCountDown <= 0)
            {
                restartChase = true;
                startChase = true;

                startBashCountDown = false;
                bashCounter++;
                //wall2 = false;
                

                if (bashCounter == 0)
                {
                    bashCountDown = .2f;
                }

                if (bashCounter == 1)
                {
                   bashCountDown = .15f;
                }

                if (bashCounter == 2)
                {
                    bashCountDown = .1f;
                }

                if (bashCounter == 3)
                {
                   bashCountDown = .05f;
                }

                if (bashCounter == 4)
                {
                    bashCountDown = .2f;
                }

                if (bashCounter == 5)
                {
                    bashCountDown = .3f;
                }


                if (bashCounter == 16)
                {
                   bashCountDown = .5f;
                }

                if (bashCounter == 18)
                {
                    cp3.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }

                if (bashCounter == 19)
                {
                    cp1.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }

                if (bashCounter == 20)
                {
                    cp2.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                }
            }

        }

        if (wall2 == true)
        {
            if (bashCounter >= 20)
            {
                bashCounter = 0;
                startBashCountDown = false;

                //coroutineStarted = true;
               // StopCoroutine("chasing");
                startChase = false;
                restartChase = false;

                leave = true;
                stopBashing = true;
            }
        }

        if (reroute1 == true || reroute2==true)
        {
            if (bashCounter >= 12)
            {
                bashCounter = 0;
                startBashCountDown = false;

                //coroutineStarted = true;
                //StopCoroutine("chasing");
                startChase = false;
                restartChase = false;
                

                if (reroute1 == true)
                {
                    rerouteleave1 = true;
                    rerouteTrigger1.GetComponent<Reroute1ChaseTrigger>().inside = false;
                }

                if (reroute2 == true)
                {
                    rerouteleave2 = true;
                    rerouteTrigger2.GetComponent<Reroute2ChaseTrigger>().inside = false;
                }


            }
        }

        

        #endregion

        #region Damage, Knockback and Back away from player
        if (monsterCollider.IsTouching(playerCollider))
        {

            if(player.GetComponent<Player>().dashing== true)
            {
                rend.sharedMaterial = material[3];
                startChaseCountDown = true;
                //playerInside = true;
                StartCoroutine("superbackoff");

            }

            if (player.GetComponent<Player>().dashing == false)
            {
                healthSlider.value -= healthLoss;
                StartCoroutine("backoff");
            }

                
            knockback = true;
            player.GetComponent<Player>().enabled = false;
            countDown = true;
            
            startChase = false;
            restartChase = false;
            backOffCountDown = true;

            if (healthSlider.value <= 55)
            {
                if (volume.weight < 1)
                {
                    volume.weight += .2f;
                }

            }


            if (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.LeftArrow)))))
            {
                thrust = 2;
            }
            else thrust = .6f;


        }

        if (backOffCountDown)
        {
            backOffCount -= Time.deltaTime;
        }

        if (backOffCount <= 0)
        {
            backOffCount = 1f;
            backOffCountDown = false;
            StopCoroutine("backoff");
            startChase = true;
            restartChase = true;
        }

        if (countDown)
        {
            waitTime -= Time.deltaTime;
        }
        #endregion

        #region Leave after bashing against Wall2
        if (leave == true)
        {
            StartCoroutine("leaving");
            startChase = false;
            restartChase = false;

        }

        if (leave2)
        {
            StartCoroutine("leaving2");
        }

        if (leave3)
        {
            StartCoroutine("leaving3");
        }

        if (leave4)
        {
            StartCoroutine("leaving4");
        }

        if (rerouteleave1 == true)
        {
            StartCoroutine("rerouting1");
            rend.sharedMaterial = material[2];
        }

        if (rerouteleave2 == true)
        {
            StartCoroutine("rerouting2");
            rend.sharedMaterial = material[2];
        }

        if (WallBashReroute == true)
        {
            ClosestWP = FindClosestWaypoint();
            StartCoroutine("WallRerouting");
            rend.sharedMaterial = material[2];
        }

        #endregion

        #region Lunge (not in use)
        //distance = Vector3.Distance(transform.position, target.position);

        //  if(distance > 17)
        {
            //      rend.sharedMaterial = material[0];
        }
        //  if (distance < 17)
        {
            //     rend.sharedMaterial = material[2];

            //    if (distance < 15)
            {
                //       rend.sharedMaterial = material[3];

            }


            // if (distance < 9)
            {

                //   rend.sharedMaterial = material[1];
                //   speed = 20;


            }
        }
        #endregion

        #region Decoy
        if (decoyChase == true)
        {
            StartCoroutine("decoyChasing");
        }

        if (startChase == true || restartChase == true)
        {
            if (DecoyPlayer.activeSelf == true)
            {
                decoyChase = true;
                startChase = false;
                restartChase = false;
            }
        }
        #endregion

        

    }
    #region Monster Movement Coroutines

    public void TriggerPlayerDash()
    {
        /*if (playerInside)
        {
            playerWasDashing = false;
            counter++;
            //coroutineStarted = true;
            //StopCoroutine("chasing");
            startChaseCountDown = true;
            startChase = false;
            restartChase = false;
            StartCoroutine("backoff");
            stunShake = true;
        }*/
    }

    #region Chasing and Backing Off

    IEnumerator chaseDelay()
    {
        yield return new WaitForSeconds(1.5f);
        restartChase = true;
        startChase = true;
        
        
        rend.sharedMaterial = material[2];
        yield return null;
    }

    //IEnumerator chasing()
   // {
   //     Debug.Log("chase");
   //     Vector3 dir = (target.transform.position - rb.transform.position).normalized;
   //     rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);      
   //     yield return null;
   // }

    IEnumerator backoff()
    {
        Debug.Log("backoff");
        rend.sharedMaterial = material[2];
        Vector3 dir = (rb.transform.position - target.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);

        yield return null;
    }


    IEnumerator superbackoff()
    {
        Debug.Log("superbackoff");
        rend.sharedMaterial = material[3];
        Vector3 dir = (rb.transform.position - target.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir * speed*20 * Time.fixedDeltaTime);

        yield return null;
    }

    IEnumerator decoyChasing()
    {

        Vector3 dir = (DecoyPlayer.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir * speed * Time.fixedDeltaTime);

        yield return null;
    }




    #endregion

    #region Leaving after bashing Against Wall2
    IEnumerator leaving()
    {
        // Debug.Log("leaving");
        yield return new WaitForSeconds(.8f);

        Vector3 dir = (leavingTarget.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir * (speed / 2) * Time.fixedDeltaTime);

        if (Vector2.Distance(rb.transform.position, leavingTarget.transform.position) < .1f)
        {
            //Debug.Log("leave2");
            leave = false;
            leave2 = true;
        }

        yield return null;
    }

    IEnumerator leaving2()
    {
        


        StopCoroutine("leaving");
        Vector3 dir2 = (leavingTarget2.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir2 * (speed / 2) * Time.fixedDeltaTime);


        if (Vector2.Distance(rb.transform.position, leavingTarget2.transform.position) < .1f)
        {
            Debug.Log("leave3");
            leave2 = false;
            leave3 = true;
        }
      
        yield return null;
    }

    IEnumerator leaving3()
    {    
        StopCoroutine("leaving2");
        Vector3 dir2 = (leavingTarget3.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir2 * (speed / 2) * Time.fixedDeltaTime);


        if (Vector2.Distance(rb.transform.position, leavingTarget3.transform.position) < .1f)
        {
            
            leave3 = false;
            leave4 = true;

        }       
        yield return null;
    }

    IEnumerator leaving4()
    {
        //Debug.Log("finished");
        StopCoroutine("leaving3");
        Vector3 dir2 = (leavingTarget4.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir2 * (speed / 2) * Time.fixedDeltaTime);


        if (Vector2.Distance(rb.transform.position, leavingTarget4.transform.position) < .1f)
        {
            //Debug.Log("finished");
            speed = 6;
            leave4 = false;
            wall2 = false;
        }
        yield return null;
    }

    IEnumerator rerouting1()
    {
        yield return new WaitForSeconds(1.5f);

        Vector3 dir2 = (Rwaypoint1.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir2 * (speed) * Time.fixedDeltaTime);

        if (Vector2.Distance(rb.transform.position, Rwaypoint1.transform.position) < .1f)
        {
            rerouteleave1 = false;
            reroute1 = false;
        }

        yield return null;
    }

    IEnumerator rerouting2()
    {
        yield return new WaitForSeconds(1.5f);

        Vector3 dir2 = (Rwaypoint2.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir2 * (speed ) * Time.fixedDeltaTime);

        if (Vector2.Distance(rb.transform.position, Rwaypoint2.transform.position) < .1f)
        {
            rerouteleave2 = false;
            reroute2 = false;
            
            
        }

        yield return null;
    }

    IEnumerator WallRerouting()
    {

        Vector3 dir2 = (ClosestWP.transform.position - rb.transform.position).normalized;
        rb.MovePosition(rb.transform.position + dir2 * speed  * Time.fixedDeltaTime);

         if (Vector2.Distance(rb.transform.position, ClosestWP.transform.position) < .1f)
        {
            WallBashReroute = false;
            startChase = true;
            restartChase = true;
        }
          
        yield return null;
    }

    #endregion



    #endregion





}



