using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementManager : MonoBehaviour
{

    public static AnnouncementManager instance = null; 
    void Awake() {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        anim = GetComponent<Animator>();
    }

    static Animator anim;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AnnouncementTheSpecial() {
        anim.SetTrigger("Announce");
    }

    public void StopTheTime() {
        Time.timeScale = 0;
    }

    public void UnStopTheTime() {
        Time.timeScale = 1;
    }
}
