using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator animator; 
    string FireOn = "Fire_On";
    string fireOff = "Fire_Off";
    
    void Start()
    {
        
        animator = GetComponent<Animator>();
        StartCoroutine(FireAnimate(2 , 7));
    }
    private IEnumerator FireAnimate(float duration , float duration2)
    {
   
        yield return new WaitForSeconds(duration);
        this.gameObject.tag = "Untagged";
        animator.Play(fireOff);
        yield return new WaitForSeconds(duration2);
        this.gameObject.tag ="Deathly";
        animator.Play((FireOn));
        StartCoroutine(FireAnimate(5 , 7));
    }
}