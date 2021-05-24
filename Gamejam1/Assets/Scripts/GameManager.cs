using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isGameStarted;
    public static bool gameOver;
    public static bool levelCompleted;
    PlayerInputs playerInput;
    SetLevelToCanvas scriptOfSetLevelToCanvas;

    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
        levelCompleted = false;
        scriptOfSetLevelToCanvas = GameObject.FindWithTag("LevelCompletedCanvas").GetComponentInChildren<SetLevelToCanvas>();
        scriptOfSetLevelToCanvas.SetLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public bool getIsGameStarted()
    {

        return isGameStarted;
    }

    public void setIsGameStarted(bool GameStarted)
    {
        isGameStarted = GameStarted;
    }

    public bool getIsLevelCompleted()
    {

        return levelCompleted;
    }

    public void setIsLevelCompleted(bool LevelCompleted)
    {
        levelCompleted = LevelCompleted;
    }

    public bool getGameOver()
    {
        
        return gameOver;
    }

    public void setGameOver(bool GameOver)
    {
        gameOver = GameOver;
    }
}
