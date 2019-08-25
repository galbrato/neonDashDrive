using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float slowMotionTime = 2f;
    float currentTime;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void TriggerGameOver()
    {
        StartCoroutine(SlowMotion());
    }

    IEnumerator SlowMotion()
    {
        currentTime = slowMotionTime;
        Time.timeScale = 0.5f;
        while(currentTime > slowMotionTime / 2)
        {
            currentTime -= Time.deltaTime / Time.timeScale;
            yield return null;
        }
        while (currentTime <= slowMotionTime/2 && currentTime > 0)
        {
            if (Time.timeScale > 0)
            {
                currentTime -= Time.deltaTime / Time.timeScale;
            }
            if (currentTime < 0) currentTime = 0;
            Time.timeScale = currentTime/slowMotionTime;
            yield return null;
        }
        myAnimator.SetTrigger("OpenGameOver");
    }
}
