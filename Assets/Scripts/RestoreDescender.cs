using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class RestoreDescender : MonoBehaviour
{
    public GameObject clone;
    public PostProcessVolume volume;
    public bool inside;
    private Vector3 velocity = Vector3.zero;
    public float smoothTime;
    public GameObject newPos;
    public bool blend;
    public float blendCountDown;
    public GameObject shipPower;
    public GameObject eye;
    public GameObject shipPTrigger;
    public GameObject shipPColl;
    public GameObject CMvcamVolume;

    public Slider shipPowerSlider;



    public GameObject CMvcamship;
    public GameObject CMvcamDes;


    public GameObject demoEndTrigger;

    void OnTriggerStay2D(Collider2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            if (!enabled) return;
            inside = true;
            clone.transform.parent = null;
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        shipPowerSlider = shipPower.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        clone = GameObject.FindWithTag("Descender");

        if (inside==true)
        {
            
            blend = true;
            
        }

        if (blend == true)
        {
            if (volume.weight >= 0)
            {
                //volume.weight -= Mathf.SmoothStep(1, 0, Time.deltaTime);
                volume.weight -= Time.deltaTime/4;
            }

            clone.transform.position = Vector3.SmoothDamp(clone.transform.position, newPos.transform.position, ref velocity, smoothTime);
            clone.transform.localScale += new Vector3(0.006f, 0.003f, 0.003f);

            blendCountDown -= Time.deltaTime;

            CMvcamDes.SetActive(false);
            CMvcamship.SetActive(true);
        }

        if (blendCountDown <= 0)
        {
            demoEndTrigger.SetActive(true);

            Destroy(clone);
            shipPower.SetActive(true);
            eye.SetActive(true);
            shipPower.transform.position = newPos.transform.position;
            eye.transform.position = newPos.transform.position;
            shipPowerSlider.value = 0;

            CMvcamVolume.SetActive(false);

            shipPColl.SetActive(true);
            shipPTrigger.GetComponent<ShipPowerTrigger>().enabled = true;
            blend = false;
            blendCountDown = 10.5f;


            

            Destroy(gameObject);
        }
    }
}
