using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public Players player;
    private float lastFall = 0;
    private GameManager gameManager;

    private KeyCode moveLeftKey;
    private KeyCode moveRightKey;
    private KeyCode rotateKey;
    private KeyCode fallDownKey;

    void Start()
    {
        SetControls(player);

        gameManager = GameManager.instance;
        if (gameManager == null)
            Debug.LogError("GameManager not found!");
    }

    void Update()
    {
        HandleMovement();
    }

    void SetControls(Players player)
    {
        switch (player)
        {
            case Players.one:
                moveLeftKey = KeyCode.A;
                moveRightKey = KeyCode.D;
                rotateKey = KeyCode.W;
                fallDownKey = KeyCode.S;
                break;
            case Players.two:
                moveLeftKey = KeyCode.LeftArrow;
                moveRightKey = KeyCode.RightArrow;
                rotateKey = KeyCode.UpArrow;
                fallDownKey = KeyCode.DownArrow;
                break;
        }
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(moveLeftKey))
            Move(Vector3.left);
        else if (Input.GetKeyDown(moveRightKey))
            Move(Vector3.right);
        else if (Input.GetKeyDown(rotateKey))
            Rotate();
        else if (Input.GetKeyDown(fallDownKey))
            IncreaseFallSpeed();

        if (Time.time - lastFall >= gameManager.fallSpeed)
        {
            Move(Vector3.down);
            lastFall = Time.time;
        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction;

        if (!IsValidPosition())
        {
            transform.position -= direction;
            if (direction == Vector3.down)
            {
                GridManager.instance.StoreTetromino(transform);
                GridManager.instance.CheckLines();

                if (GridManager.instance.IsGameOver(transform))
                    gameManager.GameOver();

                enabled = false;
            }
        }
    }

    void Rotate()
    {
        transform.Rotate(0, 0, -90);

        if (!IsValidPosition())
            transform.Rotate(0, 0, 90);
    }

    void IncreaseFallSpeed()
    {
        lastFall = Time.time - gameManager.fallSpeed;
    }

    bool IsValidPosition()
    {
        foreach (Transform block in transform)
        {
            Vector3 position = block.position;
            position = GridManager.instance.RoundPosition(position);

            if (!GridManager.instance.IsInsideGrid(position))
                return false;

            if (GridManager.instance.GetTransformAtGridPosition(position) != null && GridManager.instance.GetTransformAtGridPosition(position).parent != transform)
                return false;
        }

        return true;
    }
}