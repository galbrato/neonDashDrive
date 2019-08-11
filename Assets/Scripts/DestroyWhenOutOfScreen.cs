using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfScreen : MonoBehaviour
{
    Transform myTransform;
    float screenBoundsX;
    float screenBoundsY;
    Camera mainCamera;
    [SerializeField] float safetyOffset = 2;

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
    }
}
