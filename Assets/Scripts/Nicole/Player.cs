using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rigid;
    public float moveSpeed, jumpHeight;

    // Movement items
    private Vector2 moveInput;

    public LayerMask isItTheGround;
    public Transform groundPoint;
    public bool isGrounded;

    public Animator animator;
    public SpriteRenderer sprite;

    private bool sdrawkcab;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Caluclate Movement and pally force
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        rigid.velocity = new Vector3(moveInput.x * moveSpeed, rigid.velocity.y, moveInput.y * moveSpeed);
        animator.SetFloat("moveSpeed", rigid.velocity.magnitude);

        // Handle Jumping
        RaycastHit hit;
        if (Physics.Raycast(groundPoint.position, Vector3.down, out hit, .7f, isItTheGround))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rigid.velocity += new Vector3(0f, jumpHeight, 0f);
        }

        animator.SetBool("onGround", isGrounded);

        // Flip Sprite when handling left input
        if(!sprite.flipX && moveInput.x < 0)
        {
            sprite.flipX = true;
        }
        else if(sprite.flipX && moveInput.x > 0)
        {
            sprite.flipX = false;
        }

        // Handle moving away from camera
        if(!sdrawkcab && moveInput.y > 0)
        {
            sdrawkcab = true;
        }
        else if (sdrawkcab && moveInput.y < 0)
        {
            sdrawkcab = false;
        }
        animator.SetBool("sdrawkcab", sdrawkcab);
    }
}
