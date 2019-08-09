using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] GameObject loadingScreen = null;

    private void Awake()
    {
        loadingScreen.SetActive(true);
    }

    public void LoadScene(string sceneName) {
        StartCoroutine(WaitForLoad(sceneName));
    }

    IEnumerator WaitForLoad(string sceneName)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneName);
    }
}
