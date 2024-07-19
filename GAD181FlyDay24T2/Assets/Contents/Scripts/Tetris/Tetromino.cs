using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public Players player;

    [SerializeField] private float normalFallSpeed = 0.5f; // The lower the value the faster.
    [SerializeField] private float forcedFalSpeed = 0.1f;

    private float _lastFall = 0;
    private GameManager _gameManager;
    private KeyCode _moveLeftKey;
    private KeyCode _moveRightKey;
    private KeyCode _rotateKey;
    private KeyCode _fallDownKey;

    void Start()
    {
        SetControls(player);

        _gameManager = GameManager.instance;
        if (_gameManager == null)
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
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(_moveLeftKey))
            Move(Vector3.left);
        else if (Input.GetKeyDown(_moveRightKey))
            Move(Vector3.right);
        else if (Input.GetKeyDown(_rotateKey))
            Rotate();

        if (Input.GetKey(_fallDownKey) && Time.time - _lastFall >= forcedFalSpeed)
        {
            IncreaseFallSpeed();
        }
        else if (Time.time - _lastFall >= normalFallSpeed)
        {
            MaintainNormalFallSpeed();
        }
    }

    void IncreaseFallSpeed()
    {
        Move(Vector3.down);
        _lastFall = Time.time;
    }

    void MaintainNormalFallSpeed()
    {
        Move(Vector3.down);
        _lastFall = Time.time;
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
                    _gameManager.GameOver();

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

            if (!GridManager.instance.IsInsideGrid(position))
                return false;

            if (GridManager.instance.GetTransformAtGridPosition(position) != null && GridManager.instance.GetTransformAtGridPosition(position).parent != transform)
                return false;
        }

        return true;
    }
}
