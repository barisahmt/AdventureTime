using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    
    public Animator animator; 
    string FireOn = "Fire_On";
    string FireOff = "Fire_Off";

    private int fireOn = 2;
    private int fireoff = 7;
    
    
    void Start()
    {
        
        animator = GetComponent<Animator>();
        StartCoroutine(FireAnimate(fireOn , fireoff));
    }
    private IEnumerator FireAnimate(float duration , float duration2)
    {
   
        yield return new WaitForSeconds(duration);
        this.gameObject.tag = "Untagged";
        animator.Play(FireOff);
        yield return new WaitForSeconds(duration2);
        this.gameObject.tag ="Deathly";
        animator.Play(FireOn); 
        StartCoroutine(FireAnimate(fireOn , fireoff));
    }
}