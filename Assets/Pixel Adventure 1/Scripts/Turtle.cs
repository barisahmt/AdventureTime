using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    // Start is called before the first frame update

    private string TurtleIdleOn = "Turtle_Idle_On";
    private string TurtleIdleOff = "Turtle_Idle";
    private string TurtleSpikeOut = "Turtle_Spikes_Out";
    private string TurtleSpikeIn = "Turtle_Spikes_In";

    private float TurtleOff = 5f;
    private float TurtleOn = 5f;
    private float TurtleOut = 0.5f;
    private float TurtleIn = 0.5f;

    
    

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        
        StartCoroutine(TurtleAnimation(TurtleOut, TurtleOff ,TurtleIn ,TurtleOn));

        
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

   
    private IEnumerator TurtleAnimation (float duration1 , float duration2 , float duration3 , float duration4)
    {
        
        anim.Play(TurtleIdleOff);
        yield return new WaitForSeconds(duration2);
        this.gameObject.tag ="Deathly";
        anim.Play(TurtleSpikeOut);
        yield return new WaitForSeconds(duration3);
        anim.Play(TurtleIdleOn);
        yield return new WaitForSeconds(duration4);
        this.gameObject.tag = "Killable";
        anim.Play(TurtleSpikeIn);
        yield return new WaitForSeconds(duration1);
        
        StartCoroutine(TurtleAnimation(TurtleIn ,TurtleOff,TurtleOut,TurtleOn));

    }
}
