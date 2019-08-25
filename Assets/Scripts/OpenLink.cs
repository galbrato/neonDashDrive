using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLink : MonoBehaviour
{
    public void OpenExternalLink(string url)
    {
        Application.OpenURL(url);
    }
}
