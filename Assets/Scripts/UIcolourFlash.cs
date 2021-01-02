using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcolourFlash : MonoBehaviour
{
    public bool dashing;
    public Slider powerSlider;
    public GameObject powerSliderBG;
    public GameObject player;
   
    public bool healLowPower;
    public bool repairLowPower;
    public bool powerBoostLowPower;

    public GameObject oxygenSliderFill;
    public bool oxygenColourFlash;

    public GameObject powerSliderFill;
    public bool powerFillFlash;


    // Start is called before the first frame update
    void Start()
    {
        dashing = player.GetComponent<Player>().dashing;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & dashing == false & powerSlider.value <= 0)
        {
            StartCoroutine("lpColourFlash");
            FindObjectOfType<AudioManager>().Play("NoDash");
        }

        if (oxygenColourFlash)
        {
            StartCoroutine("ofColourFlash");
            //Debug.Log("colour flash");
        }

        if(healLowPower == true)
        {
            StartCoroutine("lpColourFlash");
            
        }

        if (repairLowPower == true)
        {
            StartCoroutine("lpColourFlash");

        }

        if (powerBoostLowPower == true)
        {
            StartCoroutine("lpColourFlash");

        }

        if (powerFillFlash)
        {
            StartCoroutine("pfFlash");
        }


    }

    IEnumerator lpColourFlash()
    {
        powerSliderBG.GetComponent<Image>().color = new Color32(255, 255, 225, 180);
        yield return new WaitForSeconds(.1f);
        powerSliderBG.GetComponent<Image>().color = new Color32(232, 255, 235, 255);

        yield return null;
    }

    IEnumerator ofColourFlash()
    {
        oxygenSliderFill.GetComponent<Image>().color = new Color32(161, 210, 238, 255);
        yield return new WaitForSeconds(.1f);
        oxygenSliderFill.GetComponent<Image>().color = new Color32(161, 238, 217, 255);

        yield return null;
    }

    IEnumerator pfFlash()
    {
        powerSliderFill.GetComponent<Image>().color = new Color32(255, 255, 90, 255);
        yield return new WaitForSeconds(.1f);
        powerSliderFill.GetComponent<Image>().color = new Color32(181, 255, 174, 255);
        yield return new WaitForSeconds(.1f);
        powerSliderFill.GetComponent<Image>().color = new Color32(255, 255, 90, 255);
        yield return new WaitForSeconds(.05f);
        powerSliderFill.GetComponent<Image>().color = new Color32(181, 255, 174, 255);
        powerFillFlash = false;

        yield return null;
    }


}
