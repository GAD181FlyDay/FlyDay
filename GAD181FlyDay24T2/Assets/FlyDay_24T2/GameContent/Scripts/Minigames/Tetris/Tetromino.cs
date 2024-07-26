using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public Players players;
    public int playerNumber; 
    public float fallDistance = 1f;
    private float lastFall = 0;
    private GameManager gameManager;
    private KeyCode _moveLeftKey;
    private KeyCode _moveRightKey;
    private KeyCode _rotateKey;
    private KeyCode _fallDownKey;
    private bool isFastFalling = false;

    void Start()
    {
        switch (players)
        {
            case Players.one:
                _moveLeftKey = KeyCode.A;
                _moveRightKey = KeyCode.D;
                _rotateKey = KeyCode.W;
                _fallDownKey = KeyCode.S;
                break;
            case Players.two:
                _moveLeftKey = KeyCode.LeftArrow;
                _moveRightKey = KeyCode.RightArrow;
                _rotateKey = KeyCode.UpArrow;
                _fallDownKey = KeyCode.DownArrow;
                break;
        }

        gameManager = GameManager.instance;
        if (gameManager == null)
            Debug.LogError("GameManager not found!");
    }

    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (playerNumber == 1)
        {
            if (Input.GetKeyDown(_moveLeftKey))
                Move(Vector3.left);
            else if (Input.GetKeyDown(_moveRightKey))
                Move(Vector3.right);
            else if (Input.GetKeyDown(_rotateKey))
                Rotate();
            else if (Input.GetKey(_fallDownKey))
                isFastFalling = true;
            else if (Input.GetKeyUp(_fallDownKey))
                isFastFalling = false;
        }
        else if (playerNumber == 2)
        {
            if (Input.GetKeyDown(_moveLeftKey))
                Move(Vector3.left);
            else if (Input.GetKeyDown(_moveRightKey))
                Move(Vector3.right);
            else if (Input.GetKeyDown(_rotateKey))
                Rotate();
            else if (Input.GetKey(_fallDownKey))
                isFastFalling = true;
            else if (Input.GetKeyUp(_fallDownKey))
                isFastFalling = false;
        }

        float fallSpeed = isFastFalling ? gameManager.fastFallSpeed : gameManager.fallSpeed;

        if (Time.time - lastFall >= fallSpeed)
        {
            Move(Vector3.down * fallDistance);
            lastFall = Time.time;
        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction;

        if (!IsValidPosition())
        {
            transform.position -= direction;
            if (direction == Vector3.down * fallDistance)
            {
                GridManager.instance.StoreTetromino(transform, playerNumber);
                GridManager.instance.CheckLines(playerNumber);

                if (GridManager.instance.IsGameOver(playerNumber))
                    gameManager.GameOver();

                gameManager.SpawnNextTetromino(playerNumber); 
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

    bool IsValidPosition()
    {
        foreach (Transform block in transform)
        {
            Vector3 position = block.position;
            position = GridManager.instance.RoundPosition(position);

            if (!GridManager.instance.IsInsideGrid(position, playerNumber))
                return false;

            if (GridManager.instance.GetTransformAtGridPosition(position, playerNumber) != null &&
                GridManager.instance.GetTransformAtGridPosition(position, playerNumber).parent != transform)
                return false;
        }

        return true;
    }
}
