using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("In seconds")]
    public float loadNextLevelTimer = 5f;

    [SerializeField]
    [Tooltip("Name of the level to load automatically after the Load Next Level Timer has finished")]
    public String level = "";

    [SerializeField]
    public GameObject levelCompleteCanvas = null;
    [SerializeField]
    public GameObject youLoseCanvas = null;

    private int numberOfAttackers = 0;
    private Base playerBase = null;
    private GameTimer gameTimer = null;
    
    private LevelLoader levelLoader = null;
    private bool levelComplete = false;

    private int difficulty;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;

        gameTimer = FindObjectOfType<GameTimer>();
        playerBase = FindObjectOfType<Base>();
        if (playerBase)
        {
            SetDifficulty();
        }

        //Disable the level complete and you lose canvases
        if (levelCompleteCanvas) levelCompleteCanvas.SetActive(false);
        if (youLoseCanvas) youLoseCanvas.SetActive(false);

        levelLoader = GetComponent<LevelLoader>();
        if (levelLoader == null)
        {
            Debug.LogError("levelLoader is null in LevelController");
        }
        if (level != "") //level name provided
        {
            StartCoroutine(levelLoader.LoadLevel(level, loadNextLevelTimer));
        }       

    }

    // Update is called once per frame
    void Update()
    {
        if (gameTimer != null) //Does the game timer exist?
        {
            Debug.Log("gameTimer is not null");
            if ((gameTimer.HasTimerFinished()) && (levelComplete == false)) //If the game timer has finished, and the level isn't yet marked as complete then handle the win condition
            {
                Debug.Log("gameTimer has finished and level is not complete");
                HandleWinCondition();                
            }
            if (playerBase.GetHealth() <= 0) // Has the player lost?
            {
                HandleLoseCondition();
            }
        }              
    }

    private void HandleLoseCondition()
    {
        StopSpawning();
        youLoseCanvas.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void HandleWinCondition()
    {
        StopSpawning();

        int numberOfAttackers = FindObjectsOfType<Attacker>().Length;
        if (numberOfAttackers == 0)
        {
            Debug.Log("There are 0 attackers left and the game timer has finished, the level is now complete.");
            levelComplete = true;
            levelCompleteCanvas.SetActive(true);
            GetComponent<AudioSource>().Play();
            StartCoroutine(levelLoader.LoadNextLevel(loadNextLevelTimer));
        }
    }

    public void LoadStartScreen()
    {
        levelLoader.LoadStartScreen();
    }

    private void SetDifficulty()
    {
        difficulty = PlayerPrefsController.GetDifficulty();

        Base playerBase = FindObjectOfType<Base>();
        if (playerBase)
        {
            int health = playerBase.GetHealth();          
            int modifier = difficulty * 40;
            health = health - modifier;
            if (health <= 0)
            {
                health = 1;
            }
            playerBase.SetHealth(health);

            GameTimer gameTimer = FindObjectOfType<GameTimer>();
            float levelTime = gameTimer.GetLevelTime();
            int currentLevel = SceneManager.GetActiveScene().buildIndex;
            float modifiedLevelTime = levelTime * currentLevel;
            gameTimer.SetLevelTime(modifiedLevelTime);
        }
    }

    public void SetPaused(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }

    private void StopSpawning()
    {
        AttackerSpawner[] attackerSpawners = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in attackerSpawners)
        {
            spawner.StopSpawning();
        }
    }

    public void RestartLevel()
    {
        levelLoader.RestartLevel();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
