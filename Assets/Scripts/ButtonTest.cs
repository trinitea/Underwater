using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonTest : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public bool selected;

    // Start is called before the first frame update
    void Start()
    {

       
    }


    public void Awake()
    {
        //selected = true;
    }

    void OnDisable()
    {
        selected = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(selected == false)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                button2.Select();
                selected = true;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                button1.Select();
                selected = true;
            }
        }
       


    }


}
