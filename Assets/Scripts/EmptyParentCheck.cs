using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyParentCheck : MonoBehaviour
{
    public GameObject[] children;
    public int i;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // how many children does top have?
        //GameObject go = GameObject.Find("top");
        // Debug.Log(go.name + " has " + go.transform.childCount + " children");

        // if (children[0]== null & children[1] == null & children[2] == null & children[3] == null & children[4] == null & children[5] == null & children[6] == null)
        // {
        //     gameObject.SetActive(false);
        // }




        if (children.Length < i + 1 || children[i] == null)
        {
            gameObject.SetActive(false);
        }


    }
}
