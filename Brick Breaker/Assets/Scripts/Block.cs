using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //when something collides to whatever holds this script...
    //were passing in a variable type of collison
    //there is trigger and collision
   private void OnCollisionEnter2D(Collision2D collision) {
       //the game object that holds this script... i could create a 1 second delay by typing Destroy(gameObject, 1f) 
       //the collision variable just holds information about what it collides with and info about the collision... I think
       Destroy(gameObject);
   }
}
