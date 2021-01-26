using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    private Text starText;

    private void Awake()
    {
        starText = GetComponent<Text>();
    }

    void Start()
    {
        
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        if (amount <= stars)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
    
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public int GetStars()
    {
        return stars;
    }

    public void SpendStars(int amount)
    {
        if (amount <= stars)
        {
            stars -= amount;
            UpdateDisplay();
        }        
    }
}
