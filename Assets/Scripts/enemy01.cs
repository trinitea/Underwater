using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using PathCreation;
using UnityEngine.UI;

public class enemy01 : MonoBehaviour
{
    public GameObject player;
    public Collider2D playerCollider;
    public Collider2D enemyCollider;

    public Rigidbody2D playerRb;

    public Material[] material;
    Renderer rend;

    public bool knockback;

    public bool freezeControls;
    public bool stop;
    public GameObject parent;

    public bool stunShake;
    public CinemachineVirtualCamera camWater;
    private CinemachineBasicMultiChannelPerlin camWaterNoise;
    public float stunShaking = .8f;

    public bool dragAnimate;

    public GameObject playerHitMesh;

    public Rigidbody2D rb;

    public Slider playerHealth;
    public float healthLoss;
    public bool invincible;

    ///movement
    public PathCreator pathCreator;
    public float speed;
    float distanceTraveled;

    public bool backOff;
    public bool blend;

    private Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<Collider2D>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        camWaterNoise = camWater.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

        rb = gameObject.GetComponent<Rigidbody2D>();
    }

     void FixedUpdate()
    {
        if (knockback)
        {
            
            Vector2 difference = (playerRb.transform.position - gameObject.transform.position);

            if (stop == true)
            {
                difference = difference.normalized * 8f;
            }
            else
                difference = difference.normalized * 8f;

           
            playerRb.velocity = difference;

           

        }

        

        if (backOff)
        {
            Vector2 difference2 = (gameObject.transform.position - playerRb.transform.position);

            
             difference2 = difference2.normalized * 2f;


            rb.velocity = difference2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            distanceTraveled += speed * Time.deltaTime;
            
            transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        }


        if (blend)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, lastPosition, Time.deltaTime*6);

            if (transform.position == lastPosition)
            {
                blend = false;
                stop = false;
            }

        }



        if (enemyCollider.IsTouching(playerCollider))
        {
           
            stunShake = true;
            

            if(GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().dashing== true)
            {
                rend.sharedMaterial = material[0];
                InvokeRepeating("Blink", 0.1f, 0.03f);
                
                knockback = true;

               
                stop = true;
                stunShake = true;
                StartCoroutine("destroyCountdown");
               
                StartCoroutine("deathColourFlash");
                

            }

            if (GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().dashing == false)
            {
                StartCoroutine("colourFlash");
                //playerRb.drag = 13;
                backOff = true;
                knockback = true;
                stop = true;
                // freezeControls = true;
                Invoke("storePosition", 0);

                if (!invincible)
                {
                    playerHealth.value -= healthLoss;
                    StartCoroutine("invincibility");
                }
                
            }

               

        }
        /* else
             rend.sharedMaterial = material[1];*/


        if (freezeControls)
        {
            player.GetComponent<Player>().enabled = false;
            //playerRb.drag = 13;
            //Debug.Log("boop");
        }

        

        if (stunShake == true)
        {
            stunShaking -= Time.deltaTime;
            if (stunShaking >= 0)
            {
                camWaterNoise.m_AmplitudeGain = 8;
                camWaterNoise.m_FrequencyGain = 7;
               
            }

            if (stunShaking <= 0)
            {
                camWaterNoise.m_AmplitudeGain = 0;
                camWaterNoise.m_FrequencyGain = 0;
               
                stunShake = false;
                stunShaking = .8f;
                
            }
        }

        if (dragAnimate)
        {
            playerRb.drag = Mathf.Lerp(700f, 1f, Time.deltaTime * 50);
        }

        
    }

    IEnumerator dragCountdown()
    {
        yield return new WaitForSeconds(.05f);

        playerRb.drag = 700;
        yield return new WaitForSeconds(.05f);

        dragAnimate = true;
        

        
        yield return null;
    }

    public IEnumerator colourFlash()
    {
        rend.sharedMaterial = material[0];
        playerHitMesh.SetActive(true);

        yield return new WaitForSeconds(.3f);

        rend.sharedMaterial = material[1];
        playerHitMesh.SetActive(false);




        yield return new WaitForSeconds(.5f);
        player.GetComponent<Player>().enabled = true;
        playerRb.drag = 1;
        knockback = false;
        freezeControls = false;
        backOff = false;
        blend = true;
        //stop = false;

        yield return null;
    }

    public IEnumerator invincibility()
    {
        invincible = true;
        yield return new WaitForSeconds(1);
        invincible = false;
        yield return null;
    }

    public IEnumerator deathColourFlash()
    {
        rend.sharedMaterial = material[0];
        playerHitMesh.SetActive(true);

        yield return new WaitForSeconds(.3f);

        rend.sharedMaterial = material[1];
        playerHitMesh.SetActive(false);



        yield return new WaitForSeconds(.5f);
        player.GetComponent<Player>().enabled = true;
        playerRb.drag = 1;
        knockback = false;
        freezeControls = false;
        

        yield return null;
    }

    IEnumerator destroyCountdown()
    {
        invincible = true;
        //Debug.Log("destroy");
        yield return new WaitForSeconds(.5f);
       
        freezeControls = false;
        player.GetComponent<Player>().enabled = true;
        knockback = false;
        playerRb.drag = 1;
        yield return new WaitForSeconds(1f);
        CancelInvoke("Blink");

       
        
        gameObject.SetActive(false);
        parent.SetActive(false);
    }

    void Blink()
    {
        int state = Random.Range(0, 2);

        if (state == 1)
            rend.enabled = false;
        else
            rend.enabled = true;

    }

    void storePosition()
    {
        //Debug.Log("store value");
        lastPosition = transform.position;
    }


}
