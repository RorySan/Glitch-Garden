using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 800;
    Text starText;

    private void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int cost)
    {
        return stars >= cost;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int cost)
    {
        if (stars >= cost)
        {
            stars -= cost;
            UpdateDisplay();
        }
        else
        {
            Debug.Log("no hay pasta");
        }
    }
}
