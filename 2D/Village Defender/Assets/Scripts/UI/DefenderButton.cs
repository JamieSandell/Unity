using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab = null;
    [SerializeField] GameObject stats = null;

    private void Awake()
    {
        Text costText = GetComponentInChildren<Text>();
        if (costText == null)
        {
            //Debug.LogError(name + " has no cost text.");
        }
        else
        {
            costText.text = defenderPrefab.GetStarCost().ToString();
        }
    }

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();

        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;

        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(1)) //right mouse button held down but not released
        {
            if(stats.activeSelf == false) //only run if the stats canvas is not active, not once every loop (if the right mouse button is held down).
            {
                stats.SetActive(true);
                Defender tempDefender = Instantiate(defenderPrefab) as Defender; //need to instantiate a temp object from the prefab so we can call getters on it for it's components, like Health.
                FindObjectOfType<StatsDisplay>().SetDefender(tempDefender);
                Destroy(tempDefender.gameObject);
                FindObjectOfType<LevelController>().SetPaused(true);
            }
            
        }
        else //no longer held down so disable the stats canvas
        {
            if (stats.activeSelf == true)
            {
                stats.SetActive(false);
                FindObjectOfType<LevelController>().SetPaused(false);
            }            
        }
    }
}
