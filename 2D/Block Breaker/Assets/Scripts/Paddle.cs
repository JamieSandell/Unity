using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField]
    private bool automaticallyPlay;
    public bool AutomaticallyPlay
    {
        get
        {
            return automaticallyPlay;
        }
        set
        {
            automaticallyPlay = value;
        }
    }

    private Ball ball;
    private Ball Ball
    {
        get
        {
            return ball;
        }
        set
        {
            ball = value;
        }
    }

	// Use this for initialization
	void Start () {
        Ball = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        if (AutomaticallyPlay)
        {
            AutoPlay();
        }
        else
        {
            MoveWithMouse();
        }        
        
	}

    void AutoPlay()
    {
        Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0.0f);
        Vector3 ballPos = Ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPos.x, 0.7f, 15.28f);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
        mousePosInBlocks = Mathf.Clamp(mousePosInBlocks, 0.7f, 15.28f);

        Vector3 paddlePos = new Vector3(mousePosInBlocks, this.transform.position.y, 0.0f);
        this.transform.position = paddlePos;
        //0.7, 15.28
        //Debug.Log(mousePosInBlocks.ToString());
    }
}
