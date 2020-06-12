using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision) {
        //this function basically means..
        //when a trigger event happens in relation to the LoseCollider this will happen
        //what we want to do is load the game over scene if it is triggered
        
        SceneManager.LoadScene("Game Over");
        
        //the scene object that has this script will also have this collider 2D with Collider 2D component
        //with is triggered checked so its an onTrigger event when entered

        //**you want to avoid using string references as much as possible it's hard to keep track of

    }
}
