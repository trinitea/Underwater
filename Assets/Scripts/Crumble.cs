using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crumble : MonoBehaviour
{
    private Rigidbody2D rb;
    private IEnumerator coroutine;


    void OnCollisionEnter2D(Collision2D Collider)
    {
        if (Collider.gameObject.tag == "Monster" || Collider.gameObject.tag == "Crumbling")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine("Destroy");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
