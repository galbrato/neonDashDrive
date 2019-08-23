using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void TriggerGameOver()
    {
        //toggle slowmotion
        myAnimator.SetTrigger("OpenGameOver");
    }
}
