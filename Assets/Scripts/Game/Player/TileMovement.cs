using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour{
    public Tile ActualTile;

    [SerializeField] float VerticalDuration = 1f;
    [SerializeField] float HorizontalDuration = 1f;

    [SerializeField] AnimationCurve Curve;
    Vector2 formerPosition;
    float CurveTime;

    public bool isMoving;

    public bool canMove = false;

    // Start is called before the first frame update
    void Start(){
        formerPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (ActualTile == null) {
            ActualTile = FindObjectOfType<Tile>();
            isMoving = true;
        }
        
        if (!isMoving && canMove) {
            //Input temporario
            if (Input.GetKeyDown(KeyCode.W)) {
                //MoveUp
                MoveUp();
            }
            if (Input.GetKeyDown(KeyCode.D)) {
                //MoveRight
                MoveRight();
            }
            if (Input.GetKeyDown(KeyCode.S)) {
                //MoveDown
                MoveDown();
            }
            if (Input.GetKeyDown(KeyCode.A)) {
                //MoveLeft
                MoveLeft();
            }
        }

        Move();
    }

    void Move() {
        if (!isMoving) {
            return;
        }
        Vector2 Destination = ActualTile.transform.position;
        Vector2 myPosition = transform.position;
        Vector2 Direction = Destination - myPosition;

        if (Direction.magnitude <= 0.01f) {
            isMoving = false;
            transform.position = ActualTile.transform.position;
            formerPosition = transform.position;
            CurveTime = 0;
            return;
        }
        float duration;
        if (Mathf.Abs(Direction.x) > Mathf.Abs(Direction.y)) {
            duration = HorizontalDuration;
        } else {
            duration = VerticalDuration;
        }
        CurveTime += Time.deltaTime;
        transform.position = Vector2.Lerp(formerPosition, Destination, Curve.Evaluate(CurveTime/duration));//tem que mudar isso pra a movimentaçao depender da duração
    }

    public bool MoveUp() {
        if (isMoving || !canMove) return false;

        if (ActualTile.upTile != null && !ActualTile.upTile.isOccupied) {
            TileSwap(ActualTile.upTile);
            isMoving = true;
            return true;
        }
        return false;  
    }

    public bool MoveRight() {
        if (isMoving || !canMove) return false;

        if (ActualTile.rightTile != null && !ActualTile.rightTile.isOccupied) {
            TileSwap(ActualTile.rightTile);
            isMoving = true;
            return true;
        }
        return false;
    }

    public bool MoveDown() {
        if (isMoving || !canMove) return false;

        if (ActualTile.downTile != null && !ActualTile.downTile.isOccupied) {
            TileSwap(ActualTile.downTile);
            isMoving = true;
            return true;
        }
        return false;
    }

    public bool MoveLeft() {
        if (isMoving || !canMove) return false;

        if (ActualTile.leftTile != null && !ActualTile.leftTile.isOccupied) {
            TileSwap( ActualTile.leftTile);
            isMoving = true;
            return true;
        }
        return false;
    }
    void TileSwap(Tile newTile) {
        ActualTile.isOccupied = false;
        ActualTile = newTile;
        ActualTile.isOccupied = true;
    }
}
