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

    public static InputManager instance = null;

    void Awake() {
        //Check if instance already exists
        if (instance == null)
            instance = this;

        //Destroy the fake
        else if (instance != this)
            Destroy(gameObject);

        //Dont destroy the ruler
        //DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    static List<PlayerController> Players;
   

    static bool inlobby = true;

    public GameObject[] playerTokens;

    public GameObject[] arrows;

    public GameObject readyButton;

    int connectedPlayers = 0;

    public void ConnectPlayer(int index, PlayerController controller)
    {
        connectedPlayers++;
        if (connectedPlayers > 0)
        {
            readyButton.SetActive(true);
        }
        switch (index)
        {
            case 0:
                Player0 = controller;
                break;
            case 1:
                Player1 = controller;
                break;
            case 2:
                Player2 = controller;
                break;
            case 3:
                Player3 = controller;
                break;

        }
        arrows[index].SetActive(true);
        playerTokens[index].SetActive(true);
        //show client which token he is
    }

    public void DisconnectPlayer(int index)
    {
        connectedPlayers--;
        if (connectedPlayers == 0)
        {
            readyButton.SetActive(false);
        }
        switch (index)
        {
            case 0:
                Player0 = null;
                break;
            case 1:
                Player1 = null;
                break;
            case 2:
                Player2 = null;
                break;
            case 3:
                Player3 = null;
                break;

        }
        arrows[index].SetActive(false);
        playerTokens[index].SetActive(false);
    }

    public void StartGame()
    {
        inlobby = false;
    }

    enum InputSourceType {
        Lan,
        Controller,
        Arrows
    }
    

    
    public static PlayerController GetPlayerInput(int index) {
        switch (index) {
            case 0:
                return Player0;
            case 1:
                return Player1;
            case 2:
                return Player2;
            case 3:
                return Player3;
            default:
                break;
        }
        return null;
    }
}
public abstract class PlayerController {
    public string Name;

    public abstract float GetHorizontal();
    public abstract float GetVertical();
    public abstract bool GetConfirmation();
    public abstract bool GetCancel();
}
