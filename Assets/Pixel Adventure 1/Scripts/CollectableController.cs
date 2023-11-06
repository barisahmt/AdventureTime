using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    [SerializeField] private Text watermelonText;
    private int watermelons = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Watermelon"))
        {
            Destroy(collision.gameObject);
            watermelons++;
            watermelonText.text = "Watermelons:" + watermelons;
        }
    }
}
