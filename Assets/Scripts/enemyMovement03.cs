using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class enemyMovement03 : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
    float distanceTraveled;
    
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Z)/*gameObject.GetComponent<enemy01>().stop == true*/)
        {
            stop = true;

        }

        if(stop == false)
        {
            distanceTraveled += speed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTraveled);
        }
        
    }
}
