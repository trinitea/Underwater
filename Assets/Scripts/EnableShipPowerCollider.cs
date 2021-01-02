using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShipPowerCollider : MonoBehaviour
{
    public GameObject shipPowerCollider;


    public bool hTextStart;
    public bool hTextReverse;
    public CanvasGroup healTextCG;



    void OnTriggerEnter2D(Collider2D playerCollider)
    {
        if (playerCollider.gameObject.tag == "Player")
        {
            if(!enabled) return;
            shipPowerCollider.SetActive(true);

            StartCoroutine("healTut");

        }
    }

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hTextStart)
        {
            healTextCG.alpha += Mathf.SmoothStep(0, 25f, Time.deltaTime);
        }

        if (hTextReverse)
        {
            healTextCG.alpha -= Mathf.SmoothStep(0, 35f, Time.deltaTime);
        }
    }


    IEnumerator healTut()
    {
        yield return new WaitForSeconds(1);
        hTextStart = true;

        yield return new WaitForSeconds(10);
        hTextStart = false;
        hTextReverse = true;

        yield return null;
    }


}
