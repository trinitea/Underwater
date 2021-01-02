using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsideShipTutorial : MonoBehaviour
{
    public Slider healthSlider;
    public bool hTextStart;
    public bool hTextReverse;
    public CanvasGroup healTextCG;
    public GameObject hStation;


    public GameObject waterPivot;
    public CanvasGroup repairTextCG;
    public GameObject rStation;
    public bool rTextReverse;


    public bool mTextStart;
    public bool mTextReverse;
    public CanvasGroup moveTextCG;


    //public bool cTextReverse;
    public CanvasGroup collectTextCG;
    public GameObject powerOrb0;
    public GameObject powerOrb1;
    public bool collecting;


    public GameObject farm;
    public CanvasGroup farmTextCG;
    public bool fTextStart;
    public bool fTutComplete;

    public CanvasGroup dashTextCG;
    public bool dTextStart;
    public bool dTextReverse;
    public Player player;


    public CanvasGroup oxygenTextCG;
    public bool oTextStart;
    public bool oTextReverse;


    public GameObject powerOrbChaseTrigger;
    public CanvasGroup stunTextCG;
    public bool sTextStart;
    public bool sTextReverse;
    public GameObject monster;
    public bool monsterNewPos;
    public CanvasGroup tutPauseScreenTextCG;
    public bool pauseStart;
    public bool pauseEnd;
    public float dist;
    public bool stunTutDone;


    public GameObject shipPowerTrigger;
    public Slider playerPower;
    public CanvasGroup givePowerTextCG;
    public bool gPTextStart;
    public bool gPTextReverse;
    public bool inside;

    public GameObject power;


    public CanvasGroup eWarningTextCG;
    public bool eWarningTextStart;
    public bool eWarningTextReverse = false;


    public bool tutorialFinished;
    public GameObject tutorialGroup;


    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            if (!enabled) return;

            if (healthSlider.value < 100f)
            {
                StartCoroutine("healTut");
            }

            inside = true;
            
        }
    }

    void OnTriggerExit2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            

            inside = false;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("moveTut");
        playerPower = power.GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        #region healing tut
        if (hTextStart)
        {
            healTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (hTextReverse)
        {
            healTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }

        if(hStation.GetComponent<healthStation>().keyPress == true)
        {
            hTextStart = false;
            hTextReverse = true;
        }
        #endregion

        #region repair tut
        if (waterPivot.GetComponent<WaterRising>().rising == true)
        {
            if(rTextReverse == false)
            {
                repairTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
            }
        }

        if (rStation.GetComponent<repairStation>().keyPress == true)
        {
            
            rTextReverse = true;
        }

        if (rTextReverse)
        {
            repairTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }
        #endregion

        #region movement tut
        if (mTextStart)
        {
            moveTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (mTextReverse)
        {
            moveTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }
        #endregion

        #region collect energy tut
        if(powerOrb0.GetComponent<PowerOrb>().collecting == true)
        {
            collectTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
            fTextStart = true;
        }
        #endregion

        #region farming tut

        if (!fTutComplete)
        {
            if (fTextStart)
            {
                farmTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
            }
        }
       

        if (farm.GetComponent<PowerFarmCoroutine>().alreadyStarted == true)
        {
            farmTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
            StartCoroutine("dashTut");
            fTutComplete = true;
            StartCoroutine("finishingTutorial");
        }
        #endregion

        #region dash tut
        if (dTextStart)
        {
            dashTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

     

        if (player.dashing)
        {
            //Debug.Log("dashing");
            dTextStart = false;
            dTextReverse = true;
            
        }

        if (dTextReverse)
        {
            dashTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
            oTextStart = true;
        }
        #endregion

        #region oxygen Tut
        if (oTextStart)
        {
            oxygenTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
            StartCoroutine("oxygenTut");
        }

        if (oTextReverse)
        {
            oxygenTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }
        #endregion

        #region stun Tut
        if (powerOrbChaseTrigger.GetComponent<PowerOrb>().collecting == true)
        {
                     
            
            monsterNewPos = true;
        }

        /*dist = Mathf.Abs(  monster.transform.position.y - player.transform.position.y);


        if(stunTutDone == false) {

            if (dist < 8)
            {
                //StartCoroutine("stunTut");
                pauseStart = true;
            }

        }
        



        if (pauseStart)
        {
            //tutPauseScreenTextCG.alpha += Mathf.SmoothStep(0, 50f, Time.deltaTime);
            tutPauseScreenTextCG.alpha = 1;
            stunTextCG.alpha = 1;
            Time.timeScale = 0.1f;
            
        }

        
        
        
            if (pauseEnd)
            {
                tutPauseScreenTextCG.alpha = 0;
                stunTextCG.alpha = 0;
                Time.timeScale = 1f;
                stunTutDone = true;
                pauseEnd = false;
                pauseStart = false;

                tutorialFinished = true;

            }

        if (tutorialFinished)
        {
            tutorialGroup.SetActive(false);
        }
        
           
        if(stunTutDone == false)
        {

            if (dist < 6)
            {
                pauseEnd = true;

            }

        }
        */


        /* if (sTextStart)
         {
             stunTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);

         }*/

        /* if(stunTextCG.alpha == 1)
          {
              powerOrbChaseTrigger.GetComponent<PowerOrb>().collecting = false;


          }*/



        if (monsterNewPos == true)
        {
            powerOrbChaseTrigger.GetComponent<PowerOrb>().collecting = false;
            monster.transform.position = new Vector3(1.5f, -80, 0);
            monsterNewPos = false;
        }



        #endregion

       
            if (inside & (playerPower.value >= shipPowerTrigger.GetComponent<ShipPowerTrigger>().powerDrain))
            {
                gPTextStart = true;
            }
     

        if (gPTextStart)
        {
            givePowerTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if(shipPowerTrigger.GetComponent<ShipPowerTrigger>().powerGiven== true)
        {
            gPTextReverse = true;
            gPTextStart = false;
        }

        if (gPTextReverse)
        {
            givePowerTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }


        #region energy warning Tut

        if(playerPower.value == 100)
        {
            eWarningTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
            StartCoroutine("energyWarningTut");
        }

        if (eWarningTextReverse)
        {
            eWarningTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }

        #endregion


        if (tutorialFinished)
        {
            tutorialGroup.SetActive(false);
        }

    }

    IEnumerator finishingTutorial()
    {
        yield return new WaitForSeconds(2);
        tutorialFinished = true;
        yield return null;

    }

    IEnumerator healTut()
    {
        yield return new WaitForSeconds(1);
        hTextStart = true;

        yield return null;
    }


    IEnumerator moveTut()
    {
        yield return new WaitForSeconds(3f);
        mTextStart = true;

        yield return new WaitForSeconds(3f);

        mTextStart = false;
        mTextReverse = true;
        yield return null;
    }

    IEnumerator dashTut()
    {
        yield return new WaitForSeconds(3f);
        dTextStart = true;
        yield return null;
    }

    IEnumerator oxygenTut()
    {
        yield return new WaitForSeconds(3f);
        oTextStart = false;
        oTextReverse = true;
        yield return null;
    }


    IEnumerator stunTut()
    {
        
        yield return new WaitForSeconds(1.2f);
        pauseEnd = true;
        yield return null;
    }


    IEnumerator energyWarningTut()
    {
        
        yield return new WaitForSeconds(3f);
        eWarningTextReverse = true;

        yield return null;
    }

}
