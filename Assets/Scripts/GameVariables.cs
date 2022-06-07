using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public int placar_P1 = 0;
    public int placar_P2 = 0;

    public bool gamePaused = true;
    public float gamePauseCountdown = 3.0f;
    public bool controllerResponse;
    public bool gameOver = false;

    public float gameSpeed = 1.0f;    
    public float playerSpeed = 12.0f;
    public float playerJump = 6.0f;

    public float gameTime = 180.0f;




    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePaused == false)
        {
            gameTime -= Time.deltaTime;
        }
        if (gameTime <= 0)
        {
            gameOver = true;
            gamePaused = true;
        }
    }
}
