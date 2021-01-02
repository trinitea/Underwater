using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInside : MonoBehaviour
{
    public Button saveButton;

    public GameObject playerTrail;
    private TrailRenderer trail;
    //public Material material;
     Renderer rend;

    public GameObject bubbles;

    public Slider oxygenSlider;
    public float oxygenLoss;
    public float oxygenGain;

    public bool losingOxygen;

    public float moveSpeed;
    public float jumpForce;
    public float thrust;
    private Rigidbody2D myRigidbody;


    public GameObject ground;
    public bool grounded;
    public LayerMask whatIsGround;
    private Collider2D myCollider;



    public PlatformEffector2D effector;
    //public float waitTime;

    

    // Use this for initialization

    void Awake()
    {
        trail = playerTrail.GetComponent<TrailRenderer>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        myCollider = GetComponent<Collider2D>();


        effector = ground.GetComponent<PlatformEffector2D>();


        StartCoroutine("FreezeCountDown");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        


        if (Input.GetKey(KeyCode.RightArrow))
        {

            {
                myRigidbody.velocity = new Vector2(thrust, myRigidbody.velocity.y);
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            {

                myRigidbody.velocity = new Vector2(-thrust, myRigidbody.velocity.y);
            }
        }



       


        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (grounded)

            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        
           


    }

    void Update()
    {
        


        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround);

        bubbles.SetActive(false);

        losingOxygen = false;

        myRigidbody.gravityScale = 2;
        myRigidbody.drag = 0;

        if (losingOxygen)
            oxygenSlider.value -= oxygenLoss * Time.deltaTime;
        else
            oxygenSlider.value += oxygenGain * Time.deltaTime;

    }

    

    void OnEnable()
    {
        //FindObjectOfType<AudioManager>().FadeOut("UnderwaterAmbience");

        
        trail.time = 0;

        if (saveButton != null)
        {
            saveButton.interactable = true;
        }
       
    }

    void OnDisable()
    {
        if (saveButton != null)
        {
            saveButton.interactable = false;
        }
        
    }

    IEnumerator FreezeCountDown()
    {
        
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(2.1f);
       
        gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        yield return null;
    }


}

