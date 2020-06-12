using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
                //we need to call this function and we'll do that by the button so when we click the button the next screen will appear
                //in order to do that we will take the scene object that has this script on it and drag it to the on click function on on the unity UI

    public void LoadNextScene()
    {                               
        //we are using a buildt in method in scene manager from scene management
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //we are using a buildt in function to get the current scene
        //then we are getting the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        //we don't care about what scene we're on. we just want to get to the first scene
        SceneManager.LoadScene(0);
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
