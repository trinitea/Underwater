using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDarken : MonoBehaviour
{

    public float dist;
    //public GameObject center;
    public GameObject player;
    public CanvasGroup dCanvas;

    public Image radiationSlider;
   
    public bool rPoisoning;

    public  bool inside;
    public  bool outside;

    public Slider healthSlider;
    public RectTransform healthSliderRT;
    public GameObject healthSliderFill;

    

    public bool Poisoned;

    Renderer rend;
    public Material playerRadMat;
    public GameObject powerSliderFill;
    public GameObject powerSliderBG;

    public GameObject healStation;

    void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")

        {

            inside = true;
            outside = false;

        }

    }


    void OnTriggerExit2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")

        {

            inside = false;

           
            outside = true;

       

        }

    }


    // Start is called before the first frame update
    void Start()
    {
        //healthSliderRT = healthSlider.GetComponent<RectTransform>();
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

        /* dist = Mathf.Abs(player.transform.position.x - center.transform.position.x);


         if(dist < 35 )
         {

             dCanvas.alpha -= Mathf.SmoothStep(0, 10, Time.deltaTime);
             rPoisoning = false;
         }





         if (dist > 25)
         {

             dCanvas.alpha += Mathf.SmoothStep(0, 6, Time.deltaTime);
             StartCoroutine("poisonCountdown");

         }*/


        if (inside)
        {
            rPoisoning = true;
            
            
        }
       /* else
        {
            
            rPoisoning = false;
            //dCanvas.alpha -= Mathf.SmoothStep(0, 10, Time.deltaTime);
        }*/


        

        if (rPoisoning)
        {
            dCanvas.alpha += Mathf.SmoothStep(0, 6, Time.deltaTime);
            radiationSlider.fillAmount += Time.deltaTime/15;

           
            //healthSliderRT.localScale = new Vector3(3.53128f, 2, 3.07016f);
            //healthSlider.maxValue -= Time.deltaTime / 25;
        }

        /*if(rPoisoning == false)
        {
            dCanvas.alpha -= Mathf.SmoothStep(0, 10, Time.deltaTime);
            
        }*/

        if (outside)
        {
            rPoisoning = false;
            dCanvas.alpha -= Mathf.SmoothStep(0, 10, Time.deltaTime);
           // GameObject.Find("radiationColour").GetComponent<Renderer>().enabled = false;
            healthSliderFill.GetComponent<Image>().color = new Color32(236, 112, 114, 255);

            StartCoroutine("outsideBoolReset");
        }

       if(inside)
        {
            if(GameObject.Find("superpowerglow").GetComponent<Renderer>().enabled == false)
            {
                Poisoned = true;
            }

            if (GameObject.Find("superpowerglow").GetComponent<Renderer>().enabled == true)
            {
                Poisoned = false;
            }


            if (Poisoned)
            {
                healthSlider.value -= 40 * Time.deltaTime;
               // GameObject.Find("radiationColour").GetComponent<Renderer>().enabled = true;
                healthSliderFill.GetComponent<Image>().color = new Color32(217, 142, 60, 255);
                // powerSliderBG.GetComponent<Image>().color = new Color32(217, 196, 60, 255);
                // powerSliderFill.GetComponent<Image>().color = new Color32(217, 142, 60, 255);
                //StartCoroutine("poisoned");
                // healthSliderRT.localScale -= new Vector3(0, .005f, Time.deltaTime);

                /*  if (Input.GetKeyDown(KeyCode.Space) & (Input.GetKey(KeyCode.DownArrow) || (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.RightArrow))))))
                  {
                      FindObjectOfType<AudioManager>().Play("NoDash");
                  }*/

                //StartCoroutine("healCountdown");
            }
            


        }


       /* if ((healStation.GetComponent<healthStation>().heal == true))
        {
            radiationSlider.fillAmount = 0;
            Poisoned = false;
        }*/
    }


    /* IEnumerator poisonCountdown()
     {
         yield return new WaitForSeconds(.5f);
         rPoisoning = true;
         yield return null;
     }*/


    IEnumerator healCountdown()
    {
        yield return new WaitForSeconds(5);
        radiationSlider.fillAmount = 0;
        Poisoned = false;
        GameObject.Find("radiationColour").GetComponent<Renderer>().enabled = false;
        powerSliderBG.GetComponent<Image>().color = new Color32(232, 255, 235, 255);
        powerSliderFill.GetComponent<Image>().color = new Color32(181, 255, 174, 255);
        yield return null;
    }


    IEnumerator poisoned()
    {
        yield return new WaitForSeconds(1);
        healthSliderRT.localScale = new Vector3(3.53128f, 2.5f, 3.07016f);

        yield return new WaitForSeconds(1);
        healthSliderRT.localScale = new Vector3(3.53128f, 2f, 3.07016f);

        yield return new WaitForSeconds(1);
        healthSliderRT.localScale = new Vector3(3.53128f, 1.5f, 3.07016f);

        yield return new WaitForSeconds(1);
        healthSliderRT.localScale = new Vector3(3.53128f, 1f, 3.07016f);

        yield return new WaitForSeconds(1);
        healthSliderRT.localScale = new Vector3(3.53128f, 0.5f, 3.07016f);

        yield return new WaitForSeconds(1);
        healthSliderRT.localScale = new Vector3(3.53128f, 0, 3.07016f);

        yield return null;

    }

    IEnumerator outsideBoolReset()
    {
        yield return new WaitForSeconds(.5f);

        if (dCanvas.alpha <= 0)
        {
            outside = false;
        }

        yield return null;
        
    }
}
