using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public float levelTime;
    private float timer;
    public GameObject menu, gameOverScreen;
    private bool paused;
    public TextMeshProUGUI timeGUI, gameOverText;
    public MowerController mc;
    private AudioSource audio1, audio2;
    private void Start()
    {
        audio1=mc.GetComponents<AudioSource>()[0];
        audio2=mc.GetComponents<AudioSource>()[1];

        timer = levelTime;
    }

    public void PauseGame()
    {
        audio1.Pause();
        audio2.Pause();
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    void GameOver()
    {
        audio1.Stop();
        timer = 0;
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
        gameOverText.text = "Игра окончена! Счёт: " + mc.getScore();

    }
    private void Update()
    {
        timer -= Time.deltaTime;
        timeGUI.text = "Осталось: " + timer.ToString("F2")+"с";
        if (timer <= 0)
        {
            GameOver();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                paused = false;
                ResumeGame();
            }
            else
            {
                paused = true;
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        audio1.UnPause();
        audio2.UnPause();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
