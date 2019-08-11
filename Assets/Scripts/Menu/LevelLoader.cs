using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] GameObject loadingScreen = null;
    Animator loadingAnimator;

    [Space(20)]
    [SerializeField] AudioClip menuClip = null;
    [SerializeField] float menuClipLoop = 0;
    [Space(20)]
    [SerializeField] AudioClip gameClip = null;
    [SerializeField] float gameClipLoop = 0;

    MusicController musicController;

    private void Awake()
    {
        loadingAnimator = loadingScreen.GetComponent<Animator>();
        loadingScreen.SetActive(true);
    }

    private void Start()
    {
        musicController = AudioManager.instance?.GetComponent<MusicController>();
    }

    public void LoadScene(string sceneName) {
        loadingAnimator.SetTrigger("StartLoad");

        //temp
        
        switch (sceneName)
        {
            case "Game":
                musicController.ChangeTrackBlend(gameClip, gameClipLoop, loadDelay * 2);
                break;
            case "Menu":
                musicController.ChangeTrackBlend(menuClip, menuClipLoop, loadDelay * 2);
                break;
        }
        
        //temp

        StartCoroutine(WaitForLoad(sceneName));
    }

    IEnumerator WaitForLoad(string sceneName)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneName);
    }
}
