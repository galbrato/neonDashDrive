using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InputType {
    None,
    Up,
    Right,
    Down,
    Left,
    Tap,
    DoubleTap,
    Confirmation,
    Cancel
}

public class InputManager : MonoBehaviour {
    public static float TouchSwipeDeltaPosition = 100f;

    // Start is called before the first frame update
    static List<PlayerController> Players;
 
    enum InputSourceType {
        Lan,
        Controller,
        Arrows
    }
    

    
    public static PlayerController GetPlayerInput(int index) {
        if (Players != null) {
            if (index < Players.Count) {
                return Players[index];
            } else {
                Debug.LogError("Player" + index + " não existe");
                return Players[0];
            }
        } else {
            Debug.Log("Criando player padrão");
            Players = new List<PlayerController>();
            Players.Add(new KeyboardController());
            return Players[0];
        }
    }
}

public abstract class PlayerController {
    public string Name;

    public abstract float GetHorizontal();
    public abstract float GetVertical();
    public abstract bool GetConfirmation();
    public abstract bool GetCancel();
}

public class TouchController : PlayerController {

    Touch ActualTouch;
    InputType actualInput;
    void HandleTouch() {
        if (Input.touchCount > 0) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                ActualTouch = Input.GetTouch(0);
            }
            if (ActualTouch.deltaPosition.magnitude > InputManager.TouchSwipeDeltaPosition) {

            }
        }
    }

    public override bool GetCancel() {
        HandleTouch()
    }

    public override bool GetConfirmation() {
        HandleTouch()
    }

    public override float GetHorizontal() {
        HandleTouch()
    }

    public override float GetVertical() {
        HandleTouch()
    }
}

public class KeyboardController : PlayerController {
    public override bool GetCancel() {
        return Input.GetButtonDown("Cancel");
    }

    public override bool GetConfirmation() {
        return Input.GetButtonUp("Submit");
    }

    public override float GetHorizontal() {
        if (Input.GetKeyDown(KeyCode.D)) {
            return 1;
        }else if (Input.GetKeyDown(KeyCode.A)) {
            return -1;
        }
        return 0;
    }

    public override float GetVertical() {
        if (Input.GetKeyDown(KeyCode.W)) {
            return 1;
        } else if (Input.GetKeyDown(KeyCode.S)) {
            return -1;
        }
        return 0;
    }
}


public class DefaultPlayerController : PlayerController {
    public override bool GetCancel() {
        Debug.LogError("Retornando valor padrão");
        return false;
    }

    public override bool GetConfirmation() {
        Debug.LogError("Retornando valor padrão");
        return false;
    }

    public override float GetHorizontal() {
        Debug.LogError("Retornando valor padrão");
        return 0;
    }

    public override float GetVertical() {
        Debug.LogError("Retornando valor padrão");
        return 0;
    }
}
