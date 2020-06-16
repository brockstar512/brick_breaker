using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    //instantiating block images
    [SerializeField] Sprite[] hitSprites;

    //cashed reference
    Level level;

    //state var
    [SerializeField] int timesHit;//only serialized for debug purposes

    private void Start() {
        //at the start we find a class called Level in a different script. so now level = the script called Level
        level = FindObjectOfType<Level>();
        if(tag == "Breakable")
        {
            level.CountBreakableBlocks();  
        }
    }
    //when something collides to whatever holds this script...
    //were passing in a variable type of collison
    //there is trigger and collision
   private void OnCollisionEnter2D(Collision2D collision) {
       
       //this way we are not grabbing the component sound. we are creating a audio source and we want it on the camera so it wont play far away
                        //sound were playing   //camera.whichever camera it is.trasform.position
       AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
       //the game object that holds this script... i could create a 1 second delay by typing Destroy(gameObject, 1f) 
       //the collision variable just holds information about what it collides with and info about the collision... I think
       //if we destroy the brick on impact it will destory the sound effect attached to the file before it has a chance to play
       //so we are going to play the sound effect even when its destroyed
       if(tag == "Breakable"){
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if(timesHit>=maxHits){
            FindObjectOfType<GameStatus>().AddToScore();
            Destroy(gameObject);
            level.BlockDestroyed();
            TriggerSparklesVFX();
            }
            else{
                ShowNextHitSprite();
            }
       }
   }
   public void ShowNextHitSprite(){
       int spriteIndex = timesHit - 1;
       if(hitSprites[spriteIndex] != null)
       //grabs compontn and the sprite renderer and makes it equal the times the block was hit - 1
       {
           GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
       //**this is saying when this is hit render this picture
       //when its hit 1 it needs to go to the picture at index 0 
       //thats why its times hit - 1
       else
       {
           Debug.LogError("Block sprite missing from array" + gameObject.name);
       }
   }
   private void TriggerSparklesVFX(){
                                        //this will put this sparkls at a specific place rather than where its been dropped
                                        //so when the block is hit it will call this function and place the effect right where
                                        //the function is called. 
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
        //destroy after 1 second so the UI doesn't build up with old effects
   }
}
//child prefrab element - apply will change the prefab from the child
//unique instances are going to be bold

//in order to change the balls bounce and friction you have to go to the materials and edit form there

//rigid body informs how gravity effects the ball
//collider is how the item reacts when it collides to other objects it also gives it a physicall body
//you can attach material to the collider
//scripts attached give the items their state


//it seems like get components allows us to grab attributes specific to that object. rather than things like 
//tranform we can grab directly because every object has it.


