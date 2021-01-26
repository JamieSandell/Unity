using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {
    [SerializeField] float loadGameOverDelay = 1.0f;

    GameSession gameSession;

    public void Start()
    {
        gameSession = GameSession.instance;
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(loadGameOverDelay, "Game Over"));        
    }

    public void LoadGameScene()
    {
        gameSession.ResetGame();
        LoadScene("Game");
    }

    public void LoadStartMenu()
    {
        LoadScene("Start");
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    private IEnumerator WaitAndLoad(float delayInSeconds, string scene)
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
