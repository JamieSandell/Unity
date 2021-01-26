using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private static LevelLoader instance = null;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            sceneCountInBuildSettings = SceneManager.sceneCountInBuildSettings;
            //if (SceneManager.GetActiveScene().buildIndex == 0) //Loading screen
            //{
            //    StartCoroutine(LoadNextLevel(3.0f));
            //}
        }
        else
        {
            Destroy(this);
        }
    }

    private int sceneCountInBuildSettings;
    
    private bool IsThereANextLevel()
    {
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneBuildIndex < sceneCountInBuildSettings)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator LoadNextLevel(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (IsThereANextLevel() == true)
        {
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
        }
    }

    public IEnumerator LoadLevel(string level, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(level);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void LoadOptionsScreen()
    {
        LoadLevel("Options Screen");
    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1.0f;
        LoadLevel("Start Screen");
    }

    public void LoadYouLose()
    {
        LoadLevel("You Lose");
    }

    public void LoadFirstLevel()
    {
        LoadLevel("Level 01");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1.0f;
        LoadLevel(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
