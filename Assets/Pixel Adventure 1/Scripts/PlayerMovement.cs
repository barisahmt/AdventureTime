using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float dirX = 0f;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpSpeed = 3f;
    [SerializeField]private LayerMask jumpableground;

    private CapsuleCollider2D coll;                              
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    
    // Start is called before the first frame update
    private enum  ChracterAnim {idle , running , jumping , falling}
    void Start()
    {
        coll = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W)  &&  IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x , jumpSpeed);
        }
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        
        ChracterAnim state;
         
        if (dirX > 0f)
        {
            state = ChracterAnim.running;
            sr.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = ChracterAnim.running;
            sr.flipX = true;
        }
        else
        {
            state = ChracterAnim.idle;
        }

        if (rb.velocity.y > .2f)
        {
            state = ChracterAnim.jumping;
        }
        else if (rb.velocity.y < -.2f)
        {
            state = ChracterAnim.falling;
        }
        anim.SetInteger("state" ,(int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center , coll.bounds.size, 0f , Vector2.down,.1f,jumpableground);
     

    }
    
}
