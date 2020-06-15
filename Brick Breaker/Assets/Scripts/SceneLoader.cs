using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadNextScene()
    {                            
        //A lot of these are just built in methods

        //SceneManager is just the unity engine that deals with the scenes
        //GetActiveScene() gets the current active scene
        //buildIndex returns the current targeted scenes index

        //we are using a buildt in method in scene manager from scene management
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //we are using a buildt in function to get the current scene


        //then we are getting the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
        //we are loading the current scene + 1
    }

    public void LoadStartScene()
    {
     
        //this just uses the buildt in scene manager to load the first scene
        //we don't care about what scene we're on. we just want to get to the first scene
        SceneManager.LoadScene(0);
        
        //when the load start scene is loaded reset the game status score 
        FindObjectOfType<GameStatus>().ResetGame();
    }


    //this is a method that will allow us to quit.
    public void QuitScene()
    {
       Application.Quit();
    }
    //we can call Application.Quit() from a key press or 
    //from conditions met in our code, it doesn't have to be a button press.

}

//we go to file build setting and drag the scenes we want in the propper order
//we send in the scripted object not the literal script. from the scriptable object we choose the script then function
