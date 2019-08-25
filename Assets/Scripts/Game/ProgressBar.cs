using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] float initialPosition;
    [SerializeField] float finalPosition;
    [SerializeField] RectTransform marker;

    float distance;
    float matchTime;

    Vector2 moveAmmount;

    // Start is called before the first frame update
    void Start()
    {
        distance = finalPosition - initialPosition;
        marker.anchoredPosition = new Vector2(initialPosition, 43);
    }

    public void StartProgressCounting(float time)
    {
        matchTime = time;
        moveAmmount = new Vector2(distance / matchTime, 0);
        StartCoroutine(MatchTime());
    }

    IEnumerator MatchTime()
    {
        float currentTime = 0;
        while (currentTime < matchTime)
        {
            currentTime += Time.deltaTime;
            marker.anchoredPosition += moveAmmount*Time.deltaTime;
            yield return null;
        }
    }
}
