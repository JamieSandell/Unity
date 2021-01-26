using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerController : MonoBehaviour {
	private static LevelManager instance;
	public LevelManager Instance { 
		get{ 
			return instance;
		}
	}

	[SerializeField]
	private int minBricksToSpawn;
	public int MinBricksToSpawn
	{
		get
		{
			return instance.MinBricksToSpawn;
		}
		set
		{
			instance.MinBricksToSpawn = value;
		}
	}

	[SerializeField]
	private int maxBricksToSpawn;
	public int MaxBricksToSpawn
	{
		get {
			return instance.MaxBricksToSpawn;
		}
		set {
			instance.MaxBricksToSpawn = value;
		}
	}

	[SerializeField]
	private float minBrickXPos;
	public float MinBrickXPos
	{
		get {
			return instance.MinBrickXPos;
		}
		set{
			instance.MinBrickXPos = value;
		}
	}

	[SerializeField]
	private float maxBrickXPos;
	public float MaxBrickXPos
	{
		get{ 
			return instance.MaxBrickXPos;
		}
		set {
			instance.MaxBrickXPos = value;
		}
	}

	[SerializeField]
	private float minBrickYPos;
	public float MinBrickYPos
	{
		get {
			return instance.MinBrickYPos;
		}
		set{
			instance.MinBrickYPos = value;
		}
	}

	[SerializeField]
	private float maxBrickYPos;
	public float MaxBrickYPos
	{
		get{ 
			return instance.MaxBrickYPos;
		}
		set {
			instance.MaxBrickYPos = value;
		}
	}

	[SerializeField]
	private float brickWidth;
	public float BrickWidth
	{
		get {
			return instance.BrickWidth;
		}
		set {
			BrickWidth = value;
		}
	}

	[SerializeField]
	private float brickHeight;
	public float BrickHeight
	{
		get {
			return instance.BrickHeight;
		}
		set {
			BrickHeight = value;
		}
	}

	void Awake () {
		Debug.Log ("Level Manager Controller Awake");
		instance = LevelManager.Instance;
	}

	// Use this for initialization
	void Start () {
        instance = LevelManager.Instance;
		MinBrickXPos = 0.5f;
		MaxBrickXPos = 15.5f;
		MinBrickYPos = 6.0f;
		MaxBrickYPos = 11.0f;
		BrickWidth = 1.0f;
		BrickHeight = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BrickDestroyed()
    {
        instance.BrickDestroyed();
    }

	public void LoadLevel (string name) {
		instance.LoadLevel (name);
	}

    public void LoadNextLevel()
    {
        instance.LoadNextLevel();
    }

    public void QuitRequest ()
    {
        instance.QuitRequest();
    }
}
