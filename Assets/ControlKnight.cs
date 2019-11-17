using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlKnight : MonoBehaviour {


    public bool grounded = false;
    public GameObject groundCheck = null;
    float runSpeed = 4;
    float jumpForce = 400;

    Animator anim;


	// link to animator for animation control
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        Debug.DrawLine(transform.position, groundCheck.transform.position);

        if(Physics2D.Linecast(transform.position, groundCheck.transform.position))
        {
            grounded = true;

        } else  {
            grounded = false;
        }

        anim.SetBool("Grounded", grounded);
        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));

        float currentYVel = GetComponent<Rigidbody2D>().velocity.y;
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-runSpeed, currentYVel);
            transform.localScale = new Vector2(-1, transform.localScale.y);
        } else if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(runSpeed, currentYVel);
            transform.localScale = new Vector2(1, transform.localScale.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {

            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
            anim.SetTrigger("Jump");
        }



    }
}
