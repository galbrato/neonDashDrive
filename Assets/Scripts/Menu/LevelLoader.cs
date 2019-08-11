using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] GameObject loadingScreen = null;
    Animator loadingAnimator;

    private void Awake()
    {
        loadingAnimator = loadingScreen.GetComponent<Animator>();
        loadingScreen.SetActive(true);
    }

    public void LoadScene(string sceneName) {
        loadingAnimator.SetTrigger("StartLoad");
        StartCoroutine(WaitForLoad(sceneName));
    }

    IEnumerator WaitForLoad(string sceneName)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneName);
    }
}
