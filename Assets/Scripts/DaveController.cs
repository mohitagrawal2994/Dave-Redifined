using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaveController : MonoBehaviour {

    public float maxspeed = 10.0f;
    public float jumpforce = 500.0f;
    bool right = true;
    private Rigidbody2D rb;
    Animator anim;

    bool grounded;
    public Transform gcheck;
    float groundRadius = 0.2f;
    public LayerMask whatisground;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();                               //Gets The Rigidbody2D Component
        anim = GetComponent<Animator>();                                //Gets the Animator Component
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(gcheck.position, groundRadius, whatisground);
        anim.SetBool("Ground", grounded);

        float move = Input.GetAxis("Horizontal");                       //Gets The User Input For X Axis
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb.velocity = new Vector2(move * maxspeed, rb.velocity.y);      //Adds force to th object according to the input
        if (move > 0 && !right)                                         //Flips Player To Right 
            Flip();
        else if (move < 0 && right)                                     //Flips Player To Left
            Flip();
	}
    private void Update()
    {
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, jumpforce));
        }
    }
    void Flip()                                                         //Function to Flip The Animation
    {
        right = !right;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
