using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    private Paddle paddle;
    private Paddle Paddle {
        get
        {
            return paddle;
        }
        set
        {
            paddle = value;
        }
    }    
    private Vector3 PaddleToBallVector
    {
        get; set;
    }
    private bool HasStarted
    {
        get;set;
    }
    private AudioSource audioSource;
    private AudioSource AudioSource
    {
        get
        {
            return audioSource;
        }
        set
        {
            audioSource = value;
        }
    }

	// Use this for initialization
	void Start () {
        Paddle = FindObjectOfType<Paddle>();
        PaddleToBallVector = this.transform.position - paddle.transform.position;
        Debug.Log(PaddleToBallVector.ToString());
        this.transform.position = paddle.transform.position + PaddleToBallVector;
        HasStarted = false;

        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {    
        if (HasStarted == false)
        {            
            //Lock the ball relative to the paddle
            this.transform.position = paddle.transform.position + PaddleToBallVector;

            //Wait for a mouse press to launch
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Left mouse button clicked, launching ball");
                GetComponent<Rigidbody2D>().velocity = new Vector2(2.0f, 10.0f);
                HasStarted = true;
            }

        }        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0.0f, 0.2f), Random.Range(0.0f, 0.2f));
        if (HasStarted)
        {
            audioSource.Play();
            Debug.Log("Ball velocity before tweak: " + GetComponent<Rigidbody2D>().velocity.ToString());
            GetComponent<Rigidbody2D>().velocity += tweak;
            Debug.Log("Ball velocity tweak value: " + tweak.ToString());
            Debug.Log("Ball veloctiy after tweaking: " + GetComponent<Rigidbody2D>().velocity.ToString());
        }
        
    }
}
