using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 10f;

    Vector2 moveInput;
    Rigidbody2D playerRB;
    SpriteRenderer playerSprite;
    CapsuleCollider2D myCapsule;

    Animator myAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
        myCapsule = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Run();
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        FlipPlayer(moveInput.x);
    }

    void OnJump(InputValue value){

        if(!myCapsule.IsTouchingLayers(LayerMask.GetMask("Ground"))){
            return;
        }

        if(value.isPressed){
            playerRB.velocity += new Vector2(0f, jumpSpeed);
        }


    }

    private void FlipPlayer(float moveValue)
    {
        if (moveValue < 0f)
        {
            playerSprite.flipX = true;
            myAnimator.SetBool("isRunning", true);
        }
        else if (moveValue > 0)
        {
            playerSprite.flipX = false;
            myAnimator.SetBool("isRunning", true);
        }
        else
        {
            myAnimator.SetBool("isRunning", false);
        }
    }

    void Run(){

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, playerRB.velocity.y);
        playerRB.velocity = playerVelocity;

    }
}
