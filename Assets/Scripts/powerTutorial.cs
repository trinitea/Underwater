using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerTutorial : MonoBehaviour
{

    public GameObject power;
    public CanvasGroup powerCG;
    public bool pFade;


    public bool cETextStart;
    public bool cETextReverse;
    public CanvasGroup collectEnergyTextCG;

    public bool dTextStart;
    public bool dTextReverse;
    public CanvasGroup dashTextCG;

    public bool rOTextStart;
    public bool rOTextReverse;
    public CanvasGroup restoreOxygenTextCG;

    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            if (!enabled) return;
            pFade = true;
            StartCoroutine("powerTut");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        powerCG = power.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pFade)
        {

            powerCG.alpha += Mathf.SmoothStep(0, 3.5f, Time.deltaTime);

        }

        if (cETextStart)
        {
            collectEnergyTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (cETextReverse)
        {
            collectEnergyTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }




        if (dTextStart)
        {
            dashTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (dTextReverse)
        {
            dashTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }


        if (rOTextStart)
        {
            restoreOxygenTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (rOTextReverse)
        {
            restoreOxygenTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }
    }


    IEnumerator powerTut()
    {
       
       // yield return new WaitForSeconds(4);
        cETextStart = true;

        yield return new WaitForSeconds(5);
        cETextStart = false;
        cETextReverse = true;
       
        yield return new WaitForSeconds(2);

        dTextStart = true;
        yield return new WaitForSeconds(4);
        dTextStart = false;
        dTextReverse = true;

        yield return new WaitForSeconds(2);

        rOTextStart = true;
        yield return new WaitForSeconds(5);
        rOTextStart = false;
        rOTextReverse = true;

        yield return null;
    }
}
