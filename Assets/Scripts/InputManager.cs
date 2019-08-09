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
    public static float TouchSwipeDeltaPosition = 70f;

    // Start is called before the first frame update
    static List<PlayerController> Players;
 
    enum InputSourceType {
        Lan,
        Controller,
        Arrows
    }

    static void  InitializePlayers() {
        Players = new List<PlayerController>();
        Players.Add(new KeyboardController());

    }

    public static void MakeTouchPlayer(int index) {
        if (Players == null)InitializePlayers();
        if (index < Players.Count) {
            Players[index] = new TouchController();
        }
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
            InitializePlayers();
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

    InputType actualInput;

    //Variavel apra executar o handle uma vez por update
    float toucheInputMoment;

    Vector2 startPosition;
    bool isToching = false;
    void HandleTouch() {
        if (toucheInputMoment != Time.time) {
            toucheInputMoment = Time.time;
            actualInput = InputType.None;
            if (Input.touchCount > 0) {
                if (!isToching && Input.GetTouch(0).phase == TouchPhase.Began) {
                    isToching = true;
                    startPosition = Input.GetTouch(0).position;
                }
                Vector2 DeltaPosition = Input.GetTouch(0).position - startPosition;
                if (isToching && Input.GetTouch(0).phase == TouchPhase.Ended) {
                    Debug.Log("SwipeDistance : " + DeltaPosition.magnitude);
                    isToching = false;
                }
                if (isToching && DeltaPosition.magnitude > InputManager.TouchSwipeDeltaPosition) {
                    //SwipeFeito
                    Vector2 dir = Input.GetTouch(0).deltaPosition;
                    if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y)) {
                        if (dir.x >= 0) {
                            actualInput = InputType.Right;
                        } else {
                            actualInput = InputType.Left;
                        }
                    } else {
                        if (dir.y >= 0) {
                            actualInput = InputType.Up;
                        } else {
                            actualInput = InputType.Down;
                        }
                    }
                    Debug.Log("SwipeDistance : " + DeltaPosition.magnitude);
                    isToching = false;
                }
            }
        } 
    }

    public override bool GetCancel() {
        HandleTouch();
        return (actualInput == InputType.Cancel);
    }

    public override bool GetConfirmation() {
        HandleTouch();
        return (actualInput == InputType.Confirmation);
    }

    public override float GetHorizontal() {
        HandleTouch();
        if (actualInput == InputType.Right) {
            return 1;
        } else if (actualInput == InputType.Left) {
            return -1;
        }
        return 0;
    }

    public override float GetVertical() {
        HandleTouch();
        if (actualInput == InputType.Up) {
            return 1;
        } else if (actualInput == InputType.Down) {
            return -1;
        }
        return 0;
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
