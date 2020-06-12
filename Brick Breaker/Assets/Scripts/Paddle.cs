using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Paddle : MonoBehaviour
{
    //configure parameters

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthUnits = 16;

    // Start is called before the first frame update
    void Start()
    {
        
    }
                                                //follow the mouse
    void Update()
    {
        //we are going to use this for our character movement because  we want to know where our character is every
        //movement every frame
        // Debug.Log(Input.mousePosition);
        //here is how we say what is the mouse position just  on the x postiion
        //we are going to take the position of the x in proportion to the screen width in case the screen size increased
        //this will give you a percentage 0.0 - 1.0
        // Debug.Log(Input.mousePosition.x / Screen.width * screenWidthUnits);

        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthUnits;

        //here is a compact way to store x and y coordenants vector 3 x,y, and z
        //vector 2 is just x and y
        Vector2 paddlePos = new Vector2 (transform.position.x, transform.position.y);
        //this is refering to the transform . position in the inspector just 
        //like the .text i was confused about was refering to the text in the inspector

        //the paddle is going to be stuck in a certain postion this way so we will reavaluate the x xoordinate
        //and use
        //mathf.clamp 
        //to limit the range
        //this is limiting the position of the paddle while also giving the corrdinants of the mouse
        //this is only effects the x value
                                //current pos, min, max
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
        
        //this is saying the transform. position is where paddlePos is

        
    }
}
