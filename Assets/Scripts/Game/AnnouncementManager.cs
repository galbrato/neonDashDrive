using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementManager : MonoBehaviour
{
    public static AnnouncementManager instance = null;
    static Animator anim;

    void Awake() {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        anim = GetComponent<Animator>();
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
