/*
 * @author
 * @date
 *
 * @brief
 *
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody; 

    [SerializeField] private float playerSpeed = 5.0f; 
    [SerializeField] private float moveLimiter = 0.7f;

    private Vector2 moveDirection; 

    // Start is called before the first frame update
    void Start()
    {
        //grab the RigidBody2D component for movement
        rigidBody = GetComponent<Rigidbody2D>(); 

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY);//.normalized;
    }

    void FixedUpdate()
    {
        // if moving diagonally, limit speed to 70% of actual speed
        // for realistic moving
        // only needed on keyboard, not for controller
        if(moveDirection.x != 0 && moveDirection.y != 0)
        {
            moveDirection.x *= moveLimiter;
            moveDirection.y *= moveLimiter;
        }

        //move the player
        rigidBody.velocity = new Vector2(moveDirection.x * playerSpeed, moveDirection.y * playerSpeed); 
    }
}
