using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoinEnter : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    [SerializeField] private float speed = 2f;

    private int currentIndex = 0;
    void Update()
    {
       
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Vector2.Distance(waypoints[currentIndex].transform.position , transform.position) <.1f)
            {
                currentIndex++;
                if (currentIndex >= waypoints.Length)
                {
                    currentIndex = 0;
                }
            }
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
