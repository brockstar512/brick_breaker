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
    // we are creating an array of the sounds for us to put into the UI
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;


    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //cached components references
    // we are creating a audio source datatype that is being declared as a my AudioSource
    AudioSource myAudioSource;
    Rigidbody2D ballPhysics;
    //best to grab a component at the start an cache it rather than constantly grabbing it 
    //each time it is called. if you are going to call it multiple times



    // Start is called before the first frame update
    void Start()
    {
        //this is the difference between the game object this script is attached to - the paddle variable position
        paddleToBallVector = transform.position - paddle1.transform.position;

        //at the start we are grabbing the components that are the sound effects
        myAudioSource = GetComponent<AudioSource>();
        //rather than having the computer grab the component every time the ball hits 
        //we are creating a variable that gets the component at the start of the game
        //then from there we are 

        ballPhysics = GetComponent<Rigidbody2D>();
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
            ballPhysics.velocity = new Vector2 (xPush, yPush);
                                //this is giving the ball a velocity in the x and y

            
        }
        
    }

        //sound effect
    private void OnCollisionEnter2D(Collision2D collision)
    {
    //grab the component - which component - what do you want to do with that component/what attribute
    Vector2 velocityTweak = new Vector2
        (UnityEngine.Random.Range(0f, randomFactor), 
        UnityEngine.Random.Range(0f, randomFactor));

    // if anything is within the audio circle of the component the sound will go off
    //so we need an if statement to make sure the sound doesnt go off in the beginning 
    //when the ball if on top of the paddle
        if(hasStarted){

            //this line below is creating an array called clip that equals a random indexed item in  the serialized field ballsound on eahc collision
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];//picking a random file to play
            // we are using one Shot instead of just play so the sounds don't overlap on eachother
            myAudioSource.PlayOneShot(clip);
        // imight need to uncheck the default box play on wake. that plays the sound anything the game plays on start
            ballPhysics.velocity += velocityTweak;
        }
    }
}



//sounds(mulitple sounds. object can only have one sound at a time)
//create a serialized field that is an array for sounds
//declare an audio sound variable
//grab the audio sound component at the start
//function that picks a random clip from the array every hit
//give that clip to the audio component every hit