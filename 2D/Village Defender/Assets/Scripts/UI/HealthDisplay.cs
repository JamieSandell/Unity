using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private Text healthText;
    private Base playerBase;

    private void Awake()
    {
        healthText = GetComponent<Text>();
        playerBase = FindObjectOfType<Base>();
    }

    private void Update()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        healthText.text = playerBase.GetHealth().ToString();        
    }
}
