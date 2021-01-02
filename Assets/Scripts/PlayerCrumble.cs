using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrumble : MonoBehaviour
{
    private Rigidbody2D rb;
    public Rigidbody2D rb2;
    public GameObject rb2Object;
    private IEnumerator coroutine;

    void OnCollisionEnter2D(Collision2D Collider)
    {
        if (Collider.gameObject.tag == "Player")
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb2.bodyType = RigidbodyType2D.Dynamic;
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
        yield return new WaitForSeconds(10);
        //Destroy(gameObject);
        //Destroy(rb2Object);
        gameObject.SetActive(false);
        rb2Object.SetActive(false);
    }
}

