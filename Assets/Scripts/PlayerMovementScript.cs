using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;

    Vector2 moveInput;
    Rigidbody2D playerRB;
    SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Run();
        
    }

    void OnMove(InputValue value){
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);

         if(moveInput.x < 0f){
            playerSprite.flipX = true;
        }else if(moveInput.x > 0){
            playerSprite.flipX = false;
        }
    }

    void Run(){
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, playerRB.velocity.y);
        playerRB.velocity = playerVelocity;
    }
}
