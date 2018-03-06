using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villian1Movement : MonoBehaviour {

    public float enemyspeed = -2.0f;
    private Rigidbody2D rb;
    private Animator anim;
    bool left = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        rb.velocity = new Vector2(enemyspeed, 0.0f);
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("End Of Boundary"))
            Flip();
    }
    void Flip()
    {
        left = !left;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        enemyspeed *= -1;
    }
}
