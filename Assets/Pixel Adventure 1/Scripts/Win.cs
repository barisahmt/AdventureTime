using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{
    
    private enum FlagAnimation {idle , opening, waving}
    private Animator anim;

    private string Waving = "Checkpoint_Waving";
    private string Opening = "Checkpoint_Opening";
    
    
    

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SuccessLevel();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Nearly();
        }
    }

    private void SuccessLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Nearly()
    {
        anim.Play(Opening);
        anim.Play(Waving);
    }
}
