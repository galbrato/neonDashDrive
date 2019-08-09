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
        lifeCount = 3;
        bombCount = 1;
        points = 0;
        UpdateLifeHUD();
        UpdateBombsHUD();
        UpdateScoreHUD();
    }

    void UpdateLifeHUD()
    {
        for(int i = 0; i < 3; i++)
        {
            if(lifeCount-1 == i)
            {
                lifeIcons[i].SetActive(true);
            }
            else
            {
                lifeIcons[i].SetActive(false);
            }
        }

    }

    void UpdateBombsHUD()
    {
        for (int i = 0; i < 3; i++)
        {
            if (bombCount - 1 == i)
            {
                bombIcons[i].SetActive(true);
            }
            else
            {
                bombIcons[i].SetActive(false);
            }
        }
    }

    void UpdateScoreHUD()
    {
        scoreText.text = points.ToString();
    }

    public void UpdateLives(int change)
    {
        lifeCount += 3;
        if (lifeCount > 3) lifeCount = 3;
        else if (lifeCount < 0) lifeCount = 0;

        UpdateLifeHUD();
    }

    public void UpdateBombs(int change)
    {
        lifeCount += 3;
        if (lifeCount > 3) lifeCount = 3;
        else if (lifeCount < 0) lifeCount = 0;

        UpdateBombsHUD();
    }

    public void UpdateText(int change)
    {
        points += change;

        UpdateScoreHUD();
    }
}
