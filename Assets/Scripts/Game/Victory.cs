using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    Animator myAnimator;
    [SerializeField] float playerAnimationTime;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void TriggerVictory()
    {
        StartCoroutine(PlayerAnimationDelay());
    }

    IEnumerator PlayerAnimationDelay()
    {
        //stop moving background
        yield return new WaitForSeconds(playerAnimationTime);
        myAnimator.SetTrigger("TriggerVictory");
    }
}
