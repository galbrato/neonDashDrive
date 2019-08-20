using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackupSpecialAtack : SpecialAtack {
    [SerializeField] float Duration = 2f;
    [SerializeField] float ActivationTime = 0.5f;
    float TimeCounter = 0;

    bool isAtacking = false;
    bool isPressing = false;

    [SerializeField]Animator SpecialAtackAnimator;
    // Start is called before the first frame update
    void Start() {
        TimeCounter = 0;
        bool isAtacking = false;
        bool isPressing = false;

    }

    // Update is called once per frame
    void Update() {
        if (isAtacking) {
            //Debug.Log("PEW PEW PEW");
            TimeCounter += Time.deltaTime;
            if (TimeCounter >= Duration) {
                EndAtack();
            }
        } else {
            if (!isPressing && TimeCounter > 0) {
                //Debug.Log("I... faio");
                Time.timeScale = 1;
                TimeCounter = 0;
            } else {
                isPressing = false;
            }
        }
        
    }


    public override bool CanAtack() {
        throw new System.NotImplementedException();
    }

    public override void EndAtack() {
        isAtacking = false;
        //Debug.Log("Cabooooooooooooooo");
        SpecialAtackAnimator.SetTrigger("Stop");
    }

    public override bool IsAtacking() {
        return isAtacking;
    }

    public override void ChargeAtack() {
        if (!isAtacking) {
            isPressing = true;
            //Time.timeScale = 0.2f + (1 - (TimeCounter / ActivationTime)) * 0.8f;
            Time.timeScale = Mathf.Lerp(1f, 0.2f, Mathf.Clamp(TimeCounter / ActivationTime,0f,1f));
            TimeCounter += Time.deltaTime;
            //Debug.Log("CARREGANDO");
            if (TimeCounter >= ActivationTime) {
                StartAtack();
            }
        }
    }


    public override void StartAtack() {
        //Debug.Log("DROP IT");

        //temp
        OnSpecialUse?.Invoke();
        //temp
        SpecialAtackAnimator.SetTrigger("Start");
        AnnouncementManager.AnnouncementTheSpecial();
        Time.timeScale = 1;
        TimeCounter = 0;
        isAtacking = true;
    }
}
