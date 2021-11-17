using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [Header("Hud")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI ammoText
    public Image HealthBarPhil;

    [Header("Pause Menu")]
    public GameObject pauseMenu;

    [Header("End Game Screen")]
    public GameObject endGameScreen;
    public public TextMeshProUGUI endGameHeaderText;
    public TextMeshProUGUI endGameScoreText;
    
    //Instance
    public static GameUI instance;

    void Awake()
    {
        //Set the instance to this script
        instance = this;
    }

    public void UpdatePhil(int curHP, int MaxHP)
    {
        HealthBarPhil.fillAmount = (float)curHP / (float)MaxHP
    
    
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateAmmoText(int curAmmo, int maxAmmo)
    {
        ammoText.text = "Ammo: " + curAmmo + " / " + maxAmmo;
    }

    public void TogglePauseMenu(bool paused)
    {
        pauseMenu.SetActive(paused);
    }

    public void SetEndGameScreen(bool won, int score)
    {
        endGameScreen.SetActive(true);
        endGameHeaderText.text = won == true ? "CoONGRATULATIONS!" : "GAME OVER";
        endGameHeaderText.color = won == true ? Color.green : Color.red;
        endGameScoreText.text = "<b>Score</b>\n" + score;
    }

    public void OnResumeButton()
    {
        Gamemanager.instance.TogglePauseGame();
    }

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
}