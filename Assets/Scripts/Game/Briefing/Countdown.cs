using System.Collections;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] float totalDelay;
    Animator animator;

    public delegate void CountdownDelegate();
    public CountdownDelegate OnCountdownEnd;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void StartCountdown()
    {
        animator?.SetTrigger("StartCountdown");
        StartCoroutine(CountdownDelay());
    }

    IEnumerator CountdownDelay()
    {
        yield return new WaitForSeconds(totalDelay);
        OnCountdownEnd?.Invoke();
    }
}