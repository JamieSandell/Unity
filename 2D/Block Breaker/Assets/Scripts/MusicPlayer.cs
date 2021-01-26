using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer{
	private static MusicPlayer instance;
	public static MusicPlayer Instance {
		get { 
			if (instance == null) {
				instance = new MusicPlayer ();
				Debug.Log ("New MusicPlayer created.");
			} else {
				Debug.Log ("A MusicPlayer already exists");
			}
			return instance;
		}
	}
    
    public AudioSource BackgroundMusic
    {
        set; private get;
    }
    public bool BackgroundMusicPlaying
    {
        private set;
        get;
    }

    private MusicPlayer()
    {
    }    

    void Awake()
    {
        Debug.Log("Background music playing " + BackgroundMusicPlaying.ToString());
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayBackgroundMusic()
    {
        if (BackgroundMusicPlaying == false)
        {
            BackgroundMusic.Play();
            BackgroundMusic.loop = true;
            BackgroundMusicPlaying = true;
        }
    }
}
