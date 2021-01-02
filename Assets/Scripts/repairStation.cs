using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class repairStation : MonoBehaviour {

    public GameObject player;
    public GameObject shipPivot;
    public GameObject waterPivot;

    public Slider powerSlider;
    public GameObject power;
    public float powerDrain;

    public bool inside;

    private bool falling;


    public Collider2D monsterCollider;
    public Collider2D wallCollider;

    public bool testbool;


    Renderer rend;
    public Material[] material;

    public GameObject mainGameManager;
    public bool keyPress;


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
        }
    }

    // Use this for initialization
    void Start () {

        wallCollider = GameObject.FindGameObjectWithTag("Wall").GetComponent<Collider2D>();
        monsterCollider = GameObject.FindGameObjectWithTag("Monster").GetComponent<Collider2D>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;

    }

    // Update is called once per frame
    void Update () {

        if (inside & powerDrain <= powerSlider.value   & shipPivot.transform.localScale.y < 1)
        {
            if (keyPress)
            {
                testbool = true;
                falling = true;

                //waterPivot.GetComponent<WaterRising>().enabled = false;
                waterPivot.GetComponent<WaterRising>().rising = false;

                powerSlider.value -= powerDrain;
            }

        }


        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                if (powerSlider.value < powerDrain)
                {
                    mainGameManager.GetComponent<UIcolourFlash>().repairLowPower = true;
                }


                StartCoroutine("colourFlash");
                keyPress = true;
            }
            else
            {
                keyPress = false;
                mainGameManager.GetComponent<UIcolourFlash>().repairLowPower = false;
            }

        }



        if (falling  & shipPivot.transform.localScale.y < 1)
        {
            
            
            shipPivot.transform.localScale += new Vector3(0, 0.00090099f, Time.deltaTime);

            
        }

        if(shipPivot.transform.localScale.y >= 1)
        {
            falling = false;
        }


       /* if (monsterCollider.IsTouching(wallCollider))
        {
            waterPivot.GetComponent<WaterRising>().enabled = true;
            falling = false;
        }*/
        
        

    }


    IEnumerator colourFlash()
    {

        rend.sharedMaterial = material[1];

        yield return new WaitForSeconds(.1f);
        rend.sharedMaterial = material[0];

        yield return null;
    }

}
