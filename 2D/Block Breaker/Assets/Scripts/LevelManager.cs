using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager{
	private static LevelManager instance;
	public static LevelManager Instance {
		get { 
			if (instance == null) {
				instance = new LevelManager ();
				Debug.Log ("New " + instance.GetType ().ToString () + " created.");
			} else {
				Debug.Log (instance.GetType ().ToString () + " already exists");
			}
			return instance;
		}
	}

	[SerializeField]
	private int minBricksToSpawn;
	public int MinBricksToSpawn
	{
		get
		{
			return minBricksToSpawn;
		}
		set
		{
			minBricksToSpawn = value;
		}
	}

	[SerializeField]
	private int maxBricksToSpawn;
	public int MaxBricksToSpawn
	{
		get {
			return maxBricksToSpawn;
		}
		set {
			maxBricksToSpawn = value;
		}
	}

	[SerializeField]
	private float minBrickXPos;
	public float MinBrickXPos
	{
		get {
			return minBrickXPos;
		}
		set {
			minBrickXPos = value;
		}
	}

	[SerializeField]
	private float maxBrickXPos;
	public float MaxBrickXPos
	{
		get{ 
			return maxBrickXPos;
		}
		set {
			maxBrickXPos = value;
		}
	}

	[SerializeField]
	private float minBrickYPos;
	public float MinBrickYPos
	{
		get {
			return minBrickYPos;
		}
		set{
			minBrickYPos = value;
		}
	}

	[SerializeField]
	private float maxBrickYPos;
	public float MaxBrickYPos
	{
		get{ 
			return maxBrickYPos;
		}
		set {
			maxBrickYPos = value;
		}
	}

	[SerializeField]
	private float brickWidth;
	public float BrickWidth
	{
		get {
			return brickWidth;
		}
		set {
			brickWidth = value;
		}
	}

	[SerializeField]
	private float brickHeight;
	public float BrickHeight
	{
		get {
			return brickHeight;
		}
		set {
			brickHeight = value;
		}
	}

	private LevelManager ()
	{
		
	}

    public void BrickDestroyed()
    {
        if (Bricks.BreakableBrick <= 0)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1;
        int maxLevelIndex = SceneManager.sceneCountInBuildSettings;
        if (nextLevelIndex >= maxLevelIndex)
        {
            throw new UnityException("LoadNextLevel out of bounds");
        }
        ResetBrickCount();
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex) + 1);
		if (SceneManager.GetActiveScene().name == "Level_Random") {
			Debug.Log ("Random level loaded.");
		}
    }
	
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        ResetBrickCount();
        SceneManager.LoadScene(name);
		if (name == "Level_Random") {
			Debug.Log ("Random level loaded.");
		}
    }

    public void ResetBrickCount()
    {
        Bricks.BreakableBrick = 0;
    }

	public void SpawnBrick()
	{
		
	}

    public void QuitRequest ()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }

}
