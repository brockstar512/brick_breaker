using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballstick : MonoBehaviour
{
    //config peremters
            //this is data type Paddle cause its referencing a script
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        //this is the difference between the game object this script is attached to - the paddle variable position
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //this without an edgecase is making the ball locked every update so we need to create a boolian
      if(!hasStarted)
      {
        LockBallToPaddle();
        BallLaunchOnClick();
      }
    }
    private void LockBallToPaddle()
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
    private void BallLaunchOnClick()
    {           //if the left mouse button is clicked
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            //in order to launch ball we need access to its rigid body component
            //rigid body is what has the ball respond to gravity and physics 
            //this kind of component is a little more tricky to get ahold of.
            GetComponent<Rigidbody2D>().velocity = new Vector2 (xPush, yPush);
                                //this is giving the ball a velocity in the x and y

            
        }
        
    }
}
