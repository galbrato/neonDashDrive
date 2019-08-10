using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool isPaused = false;

    [SerializeField] Animator pauseAnimator;

    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        if (isPaused)
        {
            pauseAnimator.SetTrigger("PauseOn");
        }
        else
        {
            pauseAnimator.SetTrigger("PauseOff");
        }
    }
}
