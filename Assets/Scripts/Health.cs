using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Health : MonoBehaviour {

    public Slider healthSlider;
    public Slider oxygenSlider;
    private GameObject oxygen;
   private GameObject health;

    public float healthLoss;
    public bool losingHealth;
    public bool vStart;

    public PostProcessVolume volume;
    

    



    // Use this for initialization
    void Start () {

        
    }
	
	// Update is called once per frame
	void Update () {

       

            if (oxygenSlider.value == 0f)
        {
            healthSlider.value -= healthLoss * Time.deltaTime;
            losingHealth = true;
        }
            



        if (losingHealth == true & healthSlider.value <= 55 & healthSlider.value >= 0)
        {
            vStart = true;

            if(vStart == true)
            {
                if  (volume.weight < 1)
                {
                    volume.weight += Time.deltaTime / 15;
                }
                      
            }

        }

        

        if (healthSlider.value <= 0)
        {
            vStart = false;
        }

        if (oxygenSlider.value >= 0f)
        {
            vStart = false;
            losingHealth = false;
        }

        

    }
}
