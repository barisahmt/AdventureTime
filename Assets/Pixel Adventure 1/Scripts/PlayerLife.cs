using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb2;

    

     void Start()
    {
        anim = GetComponent<Animator>();
        rb2 = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Deathly"))
        {
            Die();
        }
        
      
    }
  
    

    private void Die()
    {
        anim.SetTrigger("death");
        StartCoroutine(Restart());
      
    }
    private void Born()
    {
        
        anim.SetTrigger("born");
    }
    private IEnumerator Restart()
    {
        rb2.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
     
    }

}