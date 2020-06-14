using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    //this will have a slider serializer
    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is saying the slider you made above referenes the time scale
        Time.timeScale = gameSpeed;
    }
}


