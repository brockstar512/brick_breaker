using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks;//serialize to help us to debug

    //cached reference
    SceneLoader sceneloader;
    
    private void Start() {
        //looking for the class called Scene Loader... public class SceneLoader : MonoBehaviour
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <=0 )
        {
            //getting this function from the called class public class SceneLoader : MonoBehaviour
            sceneloader.LoadNextScene();
        }
    }
}
