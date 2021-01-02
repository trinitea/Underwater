using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using  UnityEngine.PostProcessing;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;



public class Death : MonoBehaviour
{

    public GameObject health;
    public Slider healthSlider;
    //public Slider oxygenSlider;
    //public GameObject oxygen;
    public GameObject player;
    public GameObject monster;
    //public GameObject spawnpoint;
    //public bool respawn;

    private IEnumerator coroutine;



    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (healthSlider.value <= 0)
        {
            StartCoroutine("StartDeath");
            //respawn = true;

            //if (respawn == true)
            {
                
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //respawn = false;
                
                
            }
           
        }

    }

    IEnumerator StartDeath()
    {
        player.GetComponent<Player>().enabled = false;
        monster.GetComponent<Monster>().enabled = false;

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }

}



