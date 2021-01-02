using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement01 : MonoBehaviour
{
    public GameObject child;
    public GameObject player;

    public float distance;
    public float speed;

   public enum OccilationFuntion { Sine, Cosine }

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if(gameObject.tag == "vertical")
        {
            StartCoroutine(verticalOscillate(OccilationFuntion.Sine, distance));
        }

        if (gameObject.tag == "horizontal")
        {
            StartCoroutine(horizontalOscillate(OccilationFuntion.Sine, distance));
        }

        //StartCoroutine("Oscillate");
    }

    // Update is called once per frame
    void Update()
    {
        if(child.GetComponent<enemy01>().stop == true)
        {
           // Debug.Log("stop");
            StopAllCoroutines();
           // StartCoroutine("restart");
            
        }
    }

    private IEnumerator verticalOscillate(OccilationFuntion method, float scalar)
    {
        while (true)
        {
            if (method == OccilationFuntion.Sine)
            {
                transform.position = new Vector3(0, Mathf.Sin(Time.time * speed) * scalar, 0);
            }
            else if (method == OccilationFuntion.Cosine)
            {
                transform.position = new Vector3(0, Mathf.Cos(Time.time * speed) * scalar, 0);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator horizontalOscillate(OccilationFuntion method, float scalar)
    {
        while (true)
        {
            if (method == OccilationFuntion.Sine)
            {
                transform.position = new Vector3(Mathf.Sin(Time.time * speed) * scalar, 0, 0);
            }
            else if (method == OccilationFuntion.Cosine)
            {
                transform.position = new Vector3(Mathf.Cos(Time.time * speed) * scalar, 0, 0);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    /*IEnumerator restart()
    {
        yield return new WaitForSeconds(.2f);
        StartCoroutine(Oscillate(OccilationFuntion.Sine, distance));
        // Vector3 dir = (transform.position - player.transform.position).normalized;
        //transform.position = player.transform.position * -1;
        yield return null;
    }*/



}
