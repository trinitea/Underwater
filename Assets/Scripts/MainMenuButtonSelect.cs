using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtonSelect : MonoBehaviour
{

    public Button button1;
    public Button button2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            button2.Select();
            
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            button1.Select();
            
        }


    }
}
