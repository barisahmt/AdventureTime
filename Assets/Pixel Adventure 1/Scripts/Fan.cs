using System;
using Unity.VisualScripting;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float fanstrong = 2f;
    private Rigidbody2D rb;
    [SerializeField]private Transform target_transform;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ddf");
           // collision.gameObject.GetComponent<Rigidbody2D>().MovePosition( new Vector2(collision.transform.position.x , target_transform.position.y));
            Mathf.Lerp(collision.transform.position.y , target_transform.transform.position.y , fanstrong);
        }
        
    }
    
    

    // Update is called once per frame
}
