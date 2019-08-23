using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfScreen : MonoBehaviour
{
    Transform myTransform;
    float screenBoundsX;
    float screenBoundsY;
    Camera mainCamera;
    [SerializeField] float disableOffset = 0.2f;
    [SerializeField] float safetyOffset = 2;

    bool disabled = false;

    private void Awake()
    {
        myTransform = transform;
        mainCamera = Camera.main;

        screenBoundsY = mainCamera.orthographicSize;
        screenBoundsX = screenBoundsY * mainCamera.aspect;
    }

    private void Update()
    {
        if (Mathf.Abs(myTransform.position.x) > screenBoundsX + safetyOffset || Mathf.Abs(myTransform.position.y) > screenBoundsY + safetyOffset)
        {
            Destroy(gameObject);
        }

        if (disabled) return;

        if (Mathf.Abs(myTransform.position.x) > screenBoundsX - disableOffset || Mathf.Abs(myTransform.position.y) > screenBoundsY - disableOffset)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            disabled = true;
        }
    }
}
