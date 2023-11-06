using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
   

    [SerializeField] private float rotateSpeed = 5f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0 , 0 ,   360* rotateSpeed * Time.deltaTime);
    }
}