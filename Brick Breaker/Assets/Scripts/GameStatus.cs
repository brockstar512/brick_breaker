using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    //config peremeters
    //this will have a slider serializer
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed =83;

    //text on screen. grab this type of variable on the ui
    //however we have to drag the score text child into the game status ersialized field
    [SerializeField] TextMeshProUGUI scoreText;
    

    //state
    [SerializeField] int currentScore = 0;

                            //singleton pattern
    //this also is applied to the children of the GameStatis
     void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1)
        {
            //anytime using the singleton pattern use this
            gameObject.SetActive(false);

            //if theres more than one destory yourself
            Destroy(gameObject);
        //game object that is being referenced is the game object unity is grabbing  by FindObjectsOfType<GameStatus>
        }
        else{
            //if there is not more than one don't destroy youyrslef
            DontDestroyOnLoad(gameObject);

            //no any time a scene loads the original Game 
            //status will stay and the new ones will get destoryed
        }
    }
    void Start()
    {
        //whatever we display has to be a string
        scoreText.text = currentScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is saying the slider you made above referenes the time scale
        Time.timeScale = gameSpeed;
    }

    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        
        scoreText.text = currentScore.ToString();

    }
    public void ResetGame(){
        //destroy this game status script when reset game is called. then a new one will be created
        Destroy(gameObject);

    }

}

//singleton pattern - allows us to maintain certian states between levels
//https://docs.unity3d.com/Manual/ExecutionOrder.html
//execution order
