using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInZone : MonoBehaviour
{
    public bool inside;
    public bool outside;
    public CanvasGroup fadeCanvas;



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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            fadeCanvas.alpha -= Mathf.SmoothStep(0, 20, Time.deltaTime);
        }
        else
        {
            fadeCanvas.alpha += Mathf.SmoothStep(0, 20, Time.deltaTime);
        }
    }
}
