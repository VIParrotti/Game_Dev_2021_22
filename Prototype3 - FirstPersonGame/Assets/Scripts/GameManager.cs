using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int scoreToWin;
    public int curScore;
    public bool gamePaused;
    public static GameManager instance;

    void Awake()
    {
        //set instance of script
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.getButton("Cancel"))
        {
            TogglePauseGame();
        }
    }

    public void TogglePauseGame()
    {
        //freeze game
        gamePaused = !gamePaused;
        Time.timeScale = gamePaused == true ? 0.0f : 1.0f;

        //get pause menu
        GameUI.instance.TogglePauseMenu(gamePaused);

        //toggle mouse cursor
        Cursor.lockState = gamePaused == true ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void AddScore(int score)
    {
        curScore += score;
        GameUI.instance.UpdateScoreText(curScore);

        if(curScore >= scoreToWin)
            WinGame();
    }

    public void WinGame()
    {
        GameUI.instance.SetEndGameScreen(true, curScore);
    }

    public void LoseGame()
    {
        GameUI.instance.SetEndGameScreen(false, curScore);
        Time.timeScale = 0.0f;
        gamePaused = true;
    }
}
