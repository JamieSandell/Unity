using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
    private LevelManagerController levelManagerController;
    private LevelManagerController LevelManagerController
    {
        get
        {
            return levelManagerController;
        }
        set
        {
            levelManagerController = value;
        }
    }
    // Use this for initialization
	void Start () {
        levelManagerController = FindObjectOfType<LevelManagerController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger");
        levelManagerController.LoadLevel("Lose");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
    }
}
