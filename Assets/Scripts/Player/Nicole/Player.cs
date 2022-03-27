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
    public bool canRotate;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.I))
        {
            this.transform.Rotate(0f, 72f, 0f);
            CameraMovement.instance.Rotate(true);
        }
        if(Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.P))
        {
            this.transform.Rotate(0f, -72f, 0f);
        }

        // Caluclate Movement and pally force
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        moveInput.Normalize();

        Vector3 localVel = Vector3.ClampMagnitude(new Vector3(moveInput.x, rigid.velocity.y, moveInput.y), 1) * moveSpeed;

        //Vector3 forWard = transform.forward * moveSpeed * moveInput.y;
        //Vector3 rightWard = transform.right * moveSpeed * moveInput.x;

        // rigid.velocity = forWard + rightWard;
        //rigid.velocity = transform.TransformDirection(localVel);
        // rigid.AddRelativeForce(moveInput.x * moveSpeed, rigid.velocity.y, moveInput.y * moveSpeed);
        //new Vector3(moveInput.x * moveSpeed, rigid.velocity.y, moveInput.y * moveSpeed);
        //velocity = transform.forward * moveInput.x * moveSpeed;
        //animator.SetFloat("moveSpeed", rigid.velocity.magnitude);


        // rigid.AddRelativeForce(moveInput.x * moveSpeed, rigid.velocity.y, moveInput.y * moveSpeed);
        //velocity = transform.forward * moveInput.x * moveSpeed;
        Vector3 forward = moveInput.y * transform.forward * moveSpeed;
        Vector3 falling = new Vector3(0, rigid.velocity.y, 0);
        Vector3 leftRight = moveInput.x * transform.right * moveSpeed;


        rigid.velocity = forward + falling + leftRight;
        //new Vector3(moveInput.x * moveSpeed, rigid.velocity.y, moveInput.y * moveSpeed);
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

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigid.velocity += new Vector3(0f, jumpHeight, 0f);
        }

        animator.SetBool("onGround", isGrounded);

        // Flip Sprite when handling left input
        if (!sprite.flipX && moveInput.x < 0)
        {
            sprite.flipX = true;
        }
        else if (sprite.flipX && moveInput.x > 0)
        {
            sprite.flipX = false;
        }
        
        // Handle moving away from camera
        if (!sdrawkcab && moveInput.y > 0)
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
