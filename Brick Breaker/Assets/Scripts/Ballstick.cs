using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballstick : MonoBehaviour
{
    //config peremters
    [SerializeField] Paddle paddle1;
    //state
    Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        //this is the difference between the game object this script is attached to - the paddle variable position
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //glue things together... this is a variable that equals wherever the paddle equals on the x and y
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);
        //now for the ball
        //ball.position             =     the paddle coordinants + the difference of start paadle and start ball   
        //(because this script is attached to the ball)
        transform.position = paddlePos + paddleToBallVector;
        //right now there is a little lag between the ball moving with the paddle. We can fix that by
        //going to edit -> project settings -> script execution order-> 
    }
}
