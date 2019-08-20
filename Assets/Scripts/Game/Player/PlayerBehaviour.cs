﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{
    TileMovement Movement;
    SpecialAtack specialAtack;
     
    private void Awake() {
        Movement = GetComponent<TileMovement>();
        specialAtack = GetComponent<SpecialAtack>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (Input.touchSupported) {
            Debug.Log("Touch funfa");
            InputManager.MakeTouchPlayer(0);
        } else {
            Debug.Log("Touch não funfa");
        }

        GameObject g = GameObject.Find("SpecialAtackButton");

        if (g != null) {
            Button button = GetComponent<Button>();
            if (button != null) {
                button.onClick.AddListener(() => specialAtack.StartAtack());
            } else {
                Debug.LogError("SpecialAtackButton não tem component de botão");
            }
        } else {
            Debug.LogError("SpecialAtackButton não encontrado na cena");
        }
    }

    // Update is called once per frame
    void Update(){
        Move();

        for (int i = 0; i < Input.touchCount; i++) {
            //Debug.Log("touch(" + i+ ") " + Input.GetTouch(i).fingerId);
        }

        if (Input.GetKey(KeyCode.Space)) {
            specialAtack.ChargeAtack();
        }
    }

    void Move() {
        if (InputManager.GetPlayerInput(0).GetHorizontal() > 0 ) {
            Movement.MoveRight();
        }
        if (InputManager.GetPlayerInput(0).GetHorizontal() < 0) {
            Movement.MoveLeft();
        }
        if (InputManager.GetPlayerInput(0).GetVertical() > 0) {
            Movement.MoveUp();
        }
        if (InputManager.GetPlayerInput(0).GetVertical() < 0) {
            Movement.MoveDown();
        }
    }
}
