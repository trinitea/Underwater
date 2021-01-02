using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Decoy : MonoBehaviour
{
    public GameObject player;
    public GameObject monster;
    public Slider powerSlider;
    public GameObject power;
    public float powerDrain;
    public GameObject DecoyPlayer;
    private IEnumerator coroutine;
    public bool countDown;
    public Collider2D DecoyColl;
    public Renderer rend;
    public PostProcessVolume volume;
    public bool blend;
    public bool reverseblend;

    public GameObject decoyPowerUp;

    public GameObject CMvcamVolume2;

    // Start is called before the first frame update
    void Start()
    {
        powerSlider = power.GetComponent<Slider>();
        DecoyColl = DecoyPlayer.GetComponent<Collider2D>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;

        if (decoyPowerUp.activeSelf == true)
        {
            StartCoroutine("enabled");
            blend = true;
        }

        if (decoyPowerUp.activeSelf == false)
        {
            GameObject.Find("decoyenabled").GetComponent<Renderer>().enabled = true;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Player>().enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.C) & powerSlider.value > 0)
            {
                DecoyColl.enabled = false;
                StopCoroutine("countdown");
                powerSlider.value -= powerDrain; 
                DecoyPlayer.SetActive(true);
                DecoyPlayer.transform.position = player.transform.position;
                
                countDown = true;

                if(monster.GetComponent<Monster>().startChase == true || monster.GetComponent<Monster>().restartChase == true)
                {
                    monster.GetComponent<Monster>().startChase = false;
                    monster.GetComponent<Monster>().restartChase = false;
                    monster.GetComponent<Monster>().decoyChase = true;
                }
            }
        }

        if (countDown == true)
        {
            StartCoroutine("countdown");
        }

        if (blend == true)
        {
            CMvcamVolume2.SetActive(true);
            if (volume.weight <= .4f)
            {
                volume.weight += Mathf.SmoothStep(0, .4f, Time.deltaTime );

            }
        }

        if (reverseblend == true)
        {
            if (volume.weight >= 0)
            {
                //volume.weight -= Mathf.SmoothStep(.2f, 0, Time.deltaTime/5 );
                volume.weight -= Time.deltaTime;
            }

            if (volume.weight <= 0)
            {
                CMvcamVolume2.SetActive(false);
            }
        }




    }

    IEnumerator countdown()
    {
        yield return new WaitForSeconds(.75f);
        DecoyColl.enabled = true ;

        yield return new WaitForSeconds(5);
        DecoyPlayer.SetActive(false);
        monster.GetComponent<Monster>().startChase = true;
        monster.GetComponent<Monster>().restartChase = true;
        monster.GetComponent<Monster>().decoyChase = false;
        countDown = false;
        yield return null;
    }

    IEnumerator enabled()
    {
        Debug.Log("running");
        yield return new WaitForSeconds(5);
        GameObject.Find("decoyenabled").GetComponent<Renderer>().enabled = true;

        yield return new WaitForSeconds(2.5f);
        blend = false;
        reverseblend = true;
        yield return null;
    }
}
