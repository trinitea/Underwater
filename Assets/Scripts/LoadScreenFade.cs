using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenFade : MonoBehaviour
{
    public CanvasGroup fadeCG;
    public bool fade = false;
   
    // Start is called before the first frame update

    void Awake()
    {
        fade = true;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            fadeCG.alpha -= Mathf.SmoothStep(0, 10f, Time.deltaTime);
        }
        
    }
}
