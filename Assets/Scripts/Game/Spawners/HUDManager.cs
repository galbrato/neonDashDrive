using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance = null;

    void Awake() {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);
    }


    [SerializeField] int lifeCount = 3;
    [SerializeField] int bombCount = 1;
    [SerializeField] int points = 0;
    //playersprite
    //playername

    [SerializeField] GameObject[] lifeIcons = null;
    [SerializeField] TextMeshProUGUI bombText = null;
    [SerializeField] TextMeshProUGUI scoreText = null;

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

    void UpdateBombsHUD(){
        if (bombText != null) {
            bombText.text = "X " + bombCount;
        } else {
            Debug.LogError("No HUDManager ta faltando o texto do que aparece as bombas");
        }
    }

    void UpdateScoreHUD()
    {
        scoreText.text = points.ToString();
    }

    public void UpdateLives(int change)
    {
        lifeCount += change;
        if (lifeCount > 3) lifeCount = 3;
        else if (lifeCount < 0) lifeCount = 0;

        UpdateLifeHUD();
    }

    public void UpdateBombs(int change)
    {
        bombCount += change;
        if (bombCount > 3) lifeCount = 3;
        else if (bombCount < 0) bombCount = 0;

        UpdateBombsHUD();
    }

    public void UpdateScore(int change)
    {
        points += change;

        UpdateScoreHUD();
    }
}
