using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour{
    public Tile ActualTile;
    
    private Tile NextTile;

    [SerializeField] float VerticalDuration = 1f;
    [SerializeField] float HorizontalDuration = 1f;

    [SerializeField] AnimationCurve Curve = null;
    Vector2 formerPosition;
    float CurveTime;

    AutoShoot autoShoot;

    public bool isMoving;
    

    public bool canMove = false;
    [SerializeField] bool willBuffer = true;

    private void Awake()
    {
        autoShoot = GetComponent<AutoShoot>();
    }
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
            autoShoot.ToggleShoot();
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
            transform.position = ActualTile.transform.position;
            formerPosition = transform.position;
            CurveTime = 0;

            isMoving = false;
            autoShoot.ToggleShoot();

            if (NextTile!=null && !NextTile.isOccupied) {
                TileSwap(NextTile);
            }
            NextTile = null;

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

    public void MoveUp() {
        if (ActualTile.upTile != null && canMove) {
            if (isMoving) {
                if(willBuffer)NextTile = ActualTile.upTile;
            } else if (!ActualTile.upTile.isOccupied) {
                TileSwap(ActualTile.upTile);
            }
        }
        return;  
    }
    public void MoveDown() {
        if (ActualTile.downTile != null && canMove) {
            if (isMoving) {
                if (willBuffer) NextTile = ActualTile.downTile;
            } else if (!ActualTile.downTile.isOccupied) {
                TileSwap(ActualTile.downTile);
            }
        }
        return;
    }
    public void MoveRight() {
        if (ActualTile.rightTile != null && canMove) {
            if (isMoving) {
                if (willBuffer) NextTile = ActualTile.rightTile;
            } else if (!ActualTile.rightTile.isOccupied) {
                TileSwap(ActualTile.rightTile);
            }
        }
        return;
    }
    public void MoveLeft() {
        if (ActualTile.leftTile != null && canMove) {
            if (isMoving) {
                if (willBuffer) NextTile = ActualTile.leftTile;
            } else if (!ActualTile.leftTile.isOccupied) {
                TileSwap(ActualTile.leftTile);
            }
        }
        return;
    }

    void TileSwap(Tile newTile) {
        ActualTile.isOccupied = false;
        ActualTile = newTile;
        ActualTile.isOccupied = true;
        isMoving = true;
        autoShoot.ToggleShoot();
    }
}
