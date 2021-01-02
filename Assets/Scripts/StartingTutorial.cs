using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class StartingTutorial : MonoBehaviour
{
    public GameObject CMvcamwater;
    public GameObject CMvcamship;
    public PostProcessVolume darkFade;
    public bool fade;


    public GameObject movementText;
    public CanvasGroup movementCG;
    public bool mTextStart;
    public bool mTextReverse;

    public bool oxygenNoDecrease = true;
    public Slider oxygenSlider;
    public GameObject oxygen;
    public CanvasGroup oxygenCG;
    public bool showOxygen;
    public GameObject oxygenText;
    public CanvasGroup oxygenTextCG;
    public bool oTextStart;
    public bool oTextReverse;

    public bool hTextStart;
    public bool hTextReverse;
    public GameObject health;
    public CanvasGroup healthCG;
    public CanvasGroup healthTextCG;

    public GameObject power;
    public CanvasGroup powerCG;

    public GameObject shipPowerCollider;

    public GameObject player;

    public GameObject shipPower;

    // Start is called before the first frame update
    void Start()
    {
        CMvcamwater.SetActive(true);
        StartCoroutine("fadeCountdown");
        movementCG = movementText.GetComponent<CanvasGroup>();

        oxygenSlider = oxygen.GetComponent<Slider>();
        oxygenCG = oxygen.GetComponent<CanvasGroup>();
        oxygenCG.alpha = 0;
        oxygenTextCG = oxygenText.GetComponent<CanvasGroup>();

        healthCG = health.GetComponent<CanvasGroup>();
        healthCG.alpha = 0;

        powerCG = power.GetComponent<CanvasGroup>();
        powerCG.alpha = 0;


        shipPowerCollider.SetActive(false);

        player.transform.position = new Vector3(0, 250, -0.5f);

        shipPower.GetComponent<ShipPowerTrigger>().broken = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygenNoDecrease)
        {
            oxygenSlider.value += 100 * Time.deltaTime;
        }

        if (fade)
        {
             darkFade.weight -= Mathf.SmoothStep(0, .8f, Time.deltaTime);
           
        }

        if (mTextStart)
        {
            movementCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (mTextReverse)
        {
            movementCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }

        if (showOxygen)
        {
            oxygenCG.alpha += Mathf.SmoothStep(0, 3.5f, Time.deltaTime);

            //oxygenSlider.value -= Mathf.SmoothStep(0, 10f, Time.deltaTime);
        }



        if (oTextStart)
        {
            oxygenTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (oTextReverse)
        {
            oxygenTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }

        if(oxygenSlider.value <= 1)
        {
            healthCG.alpha += Mathf.SmoothStep(0, 3.5f, Time.deltaTime);
            StartCoroutine("hTextCountdown");
        }

        if (hTextStart)
        {
            healthTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (hTextReverse)
        {
            healthTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }
    }

    IEnumerator fadeCountdown()
    {
        yield return new WaitForSeconds(2);
        fade = true;
        oxygenSlider.value = 90;      
        oxygenNoDecrease = false;

        yield return new WaitForSeconds(5);
        mTextStart = true;
        
        yield return new WaitForSeconds(3);
        mTextStart = false;
        mTextReverse = true;
       
       
        yield return new WaitForSeconds(3);
        
        showOxygen = true;
        yield return new WaitForSeconds(2);
        oTextStart = true;
        yield return new WaitForSeconds(3);
        oTextStart = false;
        oTextReverse = true;

        yield return null;
    }

    IEnumerator hTextCountdown()
    {
        yield return new WaitForSeconds(3);
        hTextStart = true;
        yield return new WaitForSeconds(5);
        hTextStart = false;
        hTextReverse = true;

        yield return null;
    }
}
