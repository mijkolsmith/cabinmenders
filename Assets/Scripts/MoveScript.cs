using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    public bool crouch = false;
    bool canCrouch = false;
    public string horizontalString;
    string jumpString;
    string crouchString;

    private void Start()
    {
        horizontalString = transform.parent.name + " Horizontal";
        jumpString = transform.parent.name + " Jump";
        crouchString = transform.parent.name + " Crouch";
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Ground")
        {
            canCrouch = false;
        }
        else
        {
            canCrouch = true;
        }
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw(horizontalString) * runSpeed;
        if (Input.GetButtonDown(jumpString))
        {
            jump = true;
            gameObject.GetComponent<CharacterController2D>().anime.SetBool("isJumping", true);
        }
        if (Input.GetButtonDown(crouchString) && canCrouch)
        {
            crouch = true;
        }
        else if (Input.GetButtonUp(crouchString))
        {
            crouch = false;
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        gameObject.GetComponent<CharacterController2D>().anime.SetBool("isJumping", false);
    }
}
