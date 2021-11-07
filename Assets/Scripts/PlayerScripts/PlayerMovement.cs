using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    private Rigidbody2D myBody;
    public float jumpForce = 2f;
    // Start is called before the first frame update
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }
     
    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }
    
    void move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
        }
        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
        }
        
    }//move
    public void platformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
