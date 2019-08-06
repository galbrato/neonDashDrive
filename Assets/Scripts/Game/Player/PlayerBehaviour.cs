using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour{
    TileMovement Movement;

    private void Awake() {
        Movement = GetComponent<TileMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){
        Move();
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
