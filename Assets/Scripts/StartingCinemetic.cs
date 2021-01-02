using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingCinemetic : MonoBehaviour
{
    public float delay = 0f;
    //public Animator splashAnim;
    //public GameObject tempPlayer;
    //public bool finished;
    // Start is called before the first frame update
    void Start()
    {
        //splashAnim = GetComponent<Animator>();
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !Animator.IsInTransition(0))
        {
            finished = true;
        }

        if (splashAnim.IsPlaying("temp_player_anim"))
        {
            Debug.Log("~ the animation is still playing");
            return;
        }
        else
        {
            Debug.Log("~ not playing, proceed normally...");
        }*/
    }
}
