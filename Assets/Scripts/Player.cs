using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class Player : MonoBehaviour
{
    public Button saveButton;

    public GameObject bubbles;
    public ParticleSystem bubblesPS;
    public ParticleSystem.EmissionModule bubblesEmit;
    public ParticleSystem.ShapeModule bubblesShape;

    public GameObject playerTrail;
    private TrailRenderer trail;
    public Material[] material;
    Renderer rend;



    public float dashspeed;
    public float thrust;
    private Rigidbody2D myRigidbody;

    public bool dashing = false;
    public Slider powerSlider;
    public GameObject power;
    public Slider oxygenSlider;
    public GameObject oxygen;

    public float powerDrain;
    public float oxygenLoss;
    public float oxygenGain;
    public float newOxyVal;


    public bool losingOxygen;

    //private int direction;

    public GameObject ground;
    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;
    public PlatformEffector2D effector;
    public float jumpForce;

    public float duration;
    public float elapsedTime = Mathf.Infinity;


    private IEnumerator coroutine;
    private bool CanDash = true;


    public bool startDash;

    public Monster monster;

    public GameObject powerSliderBG;

    public GameObject mainGameManager;

    [Header("dash shake")]

    public CinemachineVirtualCamera camWater;
    private CinemachineBasicMultiChannelPerlin camWaterNoise;
    public bool stunShake;
    public float stunShaking = .1f;
    public float shaking = .3f;


    




    public bool up;
    public bool down;
    public bool left;
    public bool right;
    public bool diagonal;
    public bool upLeft;

    //public Vector2 direction;
    public Vector2 direction;

    public GameObject radiationField;

    


    void Start()
    {
        

        bubblesPS = bubbles.GetComponent<ParticleSystem>();
        bubblesEmit = bubblesPS.emission;
        bubblesShape = bubblesPS.shape;

        trail = playerTrail.GetComponent<TrailRenderer>();


        myRigidbody = GetComponent<Rigidbody2D>();
        

        powerSlider = power.GetComponent<Slider>();
        oxygenSlider = oxygen.GetComponent<Slider>();


        myCollider = GetComponent<Collider2D>();
        effector = ground.GetComponent<PlatformEffector2D>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;


        camWaterNoise = camWater.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();

       
    }

    // Update is called once per frame


    void FixedUpdate()
    {
        //direction based movement
        if (dashing)
        { 
           // myRigidbody.AddForce(direction * dashspeed/3, ForceMode2D.Impulse);
            myRigidbody.velocity = direction * dashspeed*1.2f;
        }
        else
             myRigidbody.AddForce(direction* thrust/4.65f, ForceMode2D.Impulse);           
             myRigidbody.AddForce(direction * -thrust * 8.5f, ForceMode2D.Force);
        

         /*if (left)
         {

             if (dashing)
             {
                 myRigidbody.velocity = new Vector2(-dashspeed, myRigidbody.velocity.y);

             }
             else
             {
                 myRigidbody.AddForce(new Vector2(-thrust / 4.75f, 0), ForceMode2D.Impulse);
                 myRigidbody.AddForce(new Vector2(thrust * 8.5f, 0), ForceMode2D.Force);
             }           


         }






         if (right)
         {

             if (dashing)
             {

                 myRigidbody.velocity = new Vector2(dashspeed, myRigidbody.velocity.y);
             }
             else
             {
                 myRigidbody.AddForce(new Vector2(thrust/4.75f, 0), ForceMode2D.Impulse);
                 myRigidbody.AddForce(new Vector2(-thrust * 8.5f, 0), ForceMode2D.Force);
             }


         }


         if (up && left)
         {
             if (dashing)
             {

                 myRigidbody.velocity = new Vector2(-dashspeed, dashspeed);


             }
         }


         if (up)
         {

             if (dashing)
             {

                 myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, dashspeed);


             }

             else
             {
                 myRigidbody.AddForce(new Vector2(0,thrust /4.75f), ForceMode2D.Impulse);
                 myRigidbody.AddForce(new Vector2(0,-thrust * 8.5f), ForceMode2D.Force);

             }




         }



         if (down)
         {

             if (dashing)
             {
                 myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, -dashspeed);
             }

             else
             {

                 myRigidbody.AddForce(new Vector2(0, -thrust/4.75f), ForceMode2D.Impulse);
                 myRigidbody.AddForce(new Vector2(0, thrust * 8.5f), ForceMode2D.Force);
             }


         }*/
    }

    void Update()
    {
       //direction based movement
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        
        



        if (Input.GetKey(KeyCode.UpArrow))
            {
            
                up = true;
            }
        
        

        if (Input.GetKeyUp(KeyCode.UpArrow) )
        {
            up = false;
           //upLeft = false;
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            down = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            down = false;
        }

        
            if (Input.GetKey(KeyCode.LeftArrow) )
            {
           
            left = true;
            }
        
        

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left = false;
            //upLeft = false;
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            right = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            right = false;
        }




        if (Input.GetKeyDown(KeyCode.Space) & powerSlider.value > 0 /*& (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow)))))*/)
        {
            if( direction.x != 0 || direction.y != 0/*direction.x > 0 || direction.x < 0 || direction.y > 0 || direction.y < 0 /*left|| right ||up || down || upLeft */)
            {
                if (CanDash) elapsedTime = 0f;
            }
           
        }


       /* if (Input.GetKeyDown(KeyCode.Space) & powerSlider.value > 0 & upLeft)
        {
            
                if (CanDash) elapsedTime = 0f;
            

        }*/



        /*if (!Input.anyKey)
        {
            dashing = false;
        }*/ //removing this fixed the power sometimes completely draining on one dash;

        newOxyVal = oxygenSlider.value + oxygenGain;

       

        if (elapsedTime < duration)
            {

                if (!dashing)
                {

                    CanDash = false;
                    powerSlider.value -= powerDrain;

                    oxygenSlider.value += oxygenGain;
                    StartCoroutine("dragCount");
                    if (monster)
                    {
                        monster.TriggerPlayerDash();
                    }
                    dashing = true;
                    stunShake = true;
                    FindObjectOfType<AudioManager>().Play("Dash");

                    if (up & left || up & right || down & left || down & right)
                    {
                        //gameObject.transform.localScale = new Vector3(0.55f, 1.25f, 1);//stretch
                        diagonal = true;
                    }

                    if (up || down)
                    {
                        gameObject.transform.localScale = new Vector3(0.55f, 1.25f, 1);//stretch
                    }

                    if (left & diagonal == false || right & diagonal == false)
                    {
                        gameObject.transform.localScale = new Vector3(0.95f, .85f, 1);//stretch
                    }

                }

                //Debug.Log("during dash");
                elapsedTime += Time.deltaTime;

                mainGameManager.GetComponent<UIcolourFlash>().oxygenColourFlash = true;
            }

        

       
        if (elapsedTime > duration)
        {
            gameObject.transform.localScale = new Vector3(0.6375f, 1, 1);//normal size
            diagonal = false;
            
            if (dashing) 
            {
                if (up || down)
                {
                    gameObject.transform.localScale = new Vector3(0.7f, .85f, 1); //squash
                }

                if (left || right)
                {
                    gameObject.transform.localScale = new Vector3(0.55f, 1.15f, 1);//stretch
                }

                dashing = false;
                elapsedTime = Mathf.Infinity;
                StartCoroutine("DashCoolDown");
                
            }
        }

        if(!dashing)
        {
            mainGameManager.GetComponent<UIcolourFlash>().oxygenColourFlash = false ;
            
        }

       

        if (elapsedTime >= duration)
        {
            elapsedTime = Mathf.Infinity;
            

        }

        if (dashing)
        {

            
            
            bubblesPS.playbackSpeed = 10;
            bubblesEmit.rate = 10;
            bubblesShape.angle = 60;

            rend.sharedMaterial = material[1];

            trail.time = .5f;



            if (Input.GetKey(KeyCode.LeftArrow))
            {
                bubbles.transform.Rotate(0, 90, 90);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                bubbles.transform.Rotate(180, 90, 90);
            }




        }
        else // !dashing
        if (CanDash)
        {
            
            {
                if (powerSlider.value <= 0)
                {
                    rend.sharedMaterial = material[2];
                }
                else // powerSlider.value > 0
                {
                    rend.sharedMaterial = material[0];
                }
            }

        }

        if (!dashing)
        {
          
            bubblesPS.playbackSpeed = 1;
            bubblesEmit.rate = 4;
            bubblesShape.angle = 16;
            bubbles.transform.Rotate(90, 90, 90);
           
            trail.time = 0;

            
        }

        myRigidbody.gravityScale = 0.1f;


        bubbles.SetActive(true);

        losingOxygen = true;

        if (losingOxygen)
            oxygenSlider.value -= oxygenLoss * Time.deltaTime;
        else
            oxygenSlider.value += oxygenGain * Time.deltaTime;


        #region dash shake

        if (stunShake == true)
        {
            stunShaking -= Time.deltaTime;
            if (shaking >= 0)
            {
                camWaterNoise.m_AmplitudeGain = 9;
                camWaterNoise.m_FrequencyGain = 8;
                
            }

            if (stunShaking <= 0)
            {
                camWaterNoise.m_AmplitudeGain = 0;
                camWaterNoise.m_FrequencyGain = 0;
                
                stunShake = false;
                stunShaking = .1f;
            }
        }
        #endregion
    }


    IEnumerator dragCount()
    {
        myRigidbody.drag = 12;
        yield return new WaitForSeconds(.5f);
        myRigidbody.drag = 1;
       
    }

    IEnumerator DashCoolDown()
    {
        //Debug.Log("dash cooldown");
        rend.sharedMaterial = material[3];
        yield return new WaitForSeconds(.45f);

        if (powerSlider.value <= 0)
        {
            rend.sharedMaterial = material[2];
            
        }
        else // powerSlider.value > 0
        {
            rend.sharedMaterial = material[0];
        }
        CanDash = true;
    }

    void OnEnable()
    {
        CanDash = true;
        //FindObjectOfType<AudioManager>().Play("UnderwaterAmbience");

       
    }

    void OnDisable()
    {
        //FindObjectOfType<AudioManager>().StopPlaying("UnderwaterAmbience");
        gameObject.transform.localScale = new Vector3(0.6375f, 1, 1); //if mid-dash will enter the ship as normal size
        dashing = false;
        elapsedTime = Mathf.Infinity;

        up = false;
        down = false;
        left = false;
        right = false;
        diagonal = false;

        if (powerSlider.value <= 0)
        {
            rend.sharedMaterial = material[2];
        }
        else // powerSlider.value > 0
        {
            rend.sharedMaterial = material[0];
        }
    }

   



}