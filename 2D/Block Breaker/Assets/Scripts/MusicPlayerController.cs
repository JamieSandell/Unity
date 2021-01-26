using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayerController : MonoBehaviour {
	private static MusicPlayer instance;
	public MusicPlayer Instance {
		get {
            return instance;
		}
	}
    
	void Awake () {
        Debug.Log("MusicPlayerController Awake");
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Don't destroy on load " + this.gameObject.name);
    }

	// Use this for initialization
	void Start () {
        instance = MusicPlayer.Instance;
        instance.BackgroundMusic = GetComponent<AudioSource>();
        Debug.Log("State of music playing before calling PlayBackgroundMusic = " + instance.BackgroundMusicPlaying.ToString());
        instance.PlayBackgroundMusic();
        Debug.Log("State of music playing after calling PlayBackgroundMusic = " + instance.BackgroundMusicPlaying.ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
