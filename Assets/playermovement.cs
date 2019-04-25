using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playermovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 800f;

    float horizontalMove = 0f;
    float verticalMove;
    bool jump = false;
    bool crouch = false;
    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
        Jump();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

      
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 50f), ForceMode2D.Impulse);
        }
    }
}
