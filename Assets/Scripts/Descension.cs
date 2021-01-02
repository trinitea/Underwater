using System.Collections;

using UnityEngine;
using UnityEngine.UI;

using UnityEngine.Rendering.PostProcessing;

public class Descension : MonoBehaviour
{
    public GameObject shipPower;
    public Slider shipPowerSlider;
    private IEnumerator coroutine;
    public GameObject player;
    public GameObject ladder;
    public GameObject monster;
    public GameObject spawnPoint;
    public GameObject Descender;
    public bool instantiated;
    public bool blend;
    public bool freeze;

    public bool boop;
    //public Collider2D ladcoll;
    public Rigidbody2D playerRb;
    public GameObject newlocation;
    //public GameObject[] fplatform;
    public GameObject fPlatform1;
    public GameObject fPlatform2;
    public GameObject fPlatform3;
    public GameObject ship;
    public GameObject outsideshiptrigger;
    public GameObject CMvcamship;
    public GameObject CMvcamdescension;
    public GameObject CMvcamdescensionWide;
    public bool startcam;

    //public float maxSpeed = 50;
    public float smoothTime = 5;
    private Vector3 velocity = Vector3.zero;
    //private Vector3 velocity = Vector3.down;
    //public float t = 1000;

    [SerializeField] private GameObject clone;

    public PostProcessVolume volume;
    public PostProcessProfile profileSwitch;

    // Use this for initialization
    void Start()
    {
        

        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        
       
    }

    // Update is called once per frame
    void Update()
    {

        

        if (shipPowerSlider.value == 300)
        {
            StartCoroutine("Transform");
            shipPowerSlider.value = 299.99f;
            freeze = true;           

        }

        if (freeze == true)
        {
            player.GetComponent<PlayerInside>().enabled = false;
            player.GetComponent<Player>().enabled = false;

            ladder.GetComponent<Ladder>().enabled = false;
            ladder.GetComponent<Collider2D>().enabled = false;
            
            monster.GetComponent<Collider2D>().enabled = false;

            fPlatform1.GetComponent<DisableGround>().enabled = false;
            fPlatform2.GetComponent<DisableGround>().enabled = false;
            fPlatform3.GetComponent<DisableGround>().enabled = false;
            ship.GetComponent<InsideShipGravity>().enabled = false;

            Destroy(outsideshiptrigger);

            CMvcamship.SetActive(false);
            CMvcamdescension.SetActive(true);

            //fplatform[3].GetComponent<DisableGround>().enabled = false;

            //foreach (GameObject ground in fplatform)
            //{
            //fplatform[3].GetComponent<DisableGround>().enabled = false;
            //}


        }

        if (blend == true)
        {
            if (volume.weight <= 1)
            {
                volume.weight += Mathf.SmoothStep(0, 1, Time.deltaTime*2.5f );
            }
            StopCoroutine("Transform");
            clone.transform.position = Vector3.Lerp(clone.transform.position, player.transform.position, Time.deltaTime/4);
            
            StartCoroutine("Descend");
        }

        if (boop == true)
        {
            
            clone.transform.position= Vector3.SmoothDamp(clone.transform.position, newlocation.transform.position, ref velocity, smoothTime* Time.deltaTime*8);
            
        }

        if (startcam == true)
        {
            CMvcamdescension.SetActive(false);
            CMvcamdescensionWide.SetActive(true);
        }
        

    }

    IEnumerator Transform()
    {

        yield return new WaitForSeconds(1);

        Instantiate(Descender);
        clone = GameObject.FindWithTag("Descender");
        instantiated = true;
        volume.profile = profileSwitch;
        blend = true;
        Destroy(shipPower);

        yield return null;
    }

    IEnumerator Descend()
    {
        yield return new WaitForSeconds(15);
        
        blend = false;
        playerRb.isKinematic = true;
        player.transform.parent = clone.transform;

        boop = true;

        yield return new WaitForSeconds(1);
        startcam = true;
        yield return null;
            
    }

    //IEnumerator Wide()
    //{
        //yield return new WaitForSeconds(10);

        //CMvcamdescension.SetActive(false);
        //CMvcamdescensionWide.SetActive(true);

        

       // yield return null;
    //}
}
