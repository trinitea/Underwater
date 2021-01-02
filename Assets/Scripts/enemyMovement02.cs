using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement02 : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        //StartCoroutine("wandering");
        randomSpot = Random.Range(0, moveSpots.Length);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        


        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
        }
        
    }

   /* IEnumerator wandering()
    {
        while (true)
        {
            //randomSpot = randomSpot.Range(0, moveSpots.Length);
            Vector3 dir = (randomSpot.transform.position - rb.transform.position).normalized;
            rb.MovePosition(rb.transform.position + dir * (speed) * Time.fixedDeltaTime);
        }

        yield return new WaitForEndOfFrame();
    }*/
}
