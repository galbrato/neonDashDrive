using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationSettings : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = 60;
    }
}
