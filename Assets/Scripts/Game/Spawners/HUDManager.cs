using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    [SerializeField] int lifeCount = 3;
    [SerializeField] int bombCount = 1;
    [SerializeField] int points = 0;
    //playersprite
    //playername

    [SerializeField] GameObject[] lifeIcons;
    [SerializeField] GameObject[] bombIcons;
    [SerializeField] TextMeshProUGUI scoreText;

    public void InitializeHUD()
    {

    }

    public void UpdateLives(int change)
    {
        lifeCount += 3;
        if (lifeCount > 3) lifeCount = 3;
        else if (lifeCount < 0) lifeCount = 0;


    }

    public void UpdateText(int change)
    {
        points += change;
        scoreText.text = points.ToString();
    }
}
