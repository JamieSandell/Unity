using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level timer in seconds")]
    [SerializeField] float levelTime = 10;

    private bool timerFinished = false;

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            Debug.Log("Level timer expired");
        }
    }

    public bool HasTimerFinished()
    {
        return timerFinished;
    }

    public float GetLevelTime()
    {
        return levelTime;
    }

    public void SetLevelTime(float time)
    {
        levelTime = time;
    }
}
