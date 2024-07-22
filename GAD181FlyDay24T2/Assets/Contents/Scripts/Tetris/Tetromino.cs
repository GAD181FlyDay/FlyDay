using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float lastFall = 0;
    private GameManager gameManager;
    private GridManager gridManager;
    public int playerNumber; 

    private KeyCode moveLeftKey;
    private KeyCode moveRightKey;
    private KeyCode rotateKey;
    private KeyCode fallDownKey;

    private bool isFastFalling = false;
    private float fastFallSpeed = 0.05f; 


    void Start()
    {
        gameManager = GameManager.instance;
        gridManager = GridManager.instance;
        if (gameManager == null || gridManager == null)
        {
            Debug.LogError("GameManager or GridManager not found!");
            return;
        }

        switch (playerNumber)
        {
            case 1:
                moveLeftKey = KeyCode.A;
                moveRightKey = KeyCode.D;
                rotateKey = KeyCode.W;
                fallDownKey = KeyCode.S;
                break;
            case 2:
                moveLeftKey = KeyCode.LeftArrow;
                moveRightKey = KeyCode.RightArrow;
                rotateKey = KeyCode.UpArrow;
                fallDownKey = KeyCode.DownArrow;
                break;
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        if (Input.GetKeyDown(moveLeftKey))
            Move(Vector3.left);
        else if (Input.GetKeyDown(moveRightKey))
            Move(Vector3.right);
        else if (Input.GetKeyDown(rotateKey))
            Rotate();

        if (Input.GetKeyDown(fallDownKey))
            isFastFalling = true;
        if (Input.GetKeyUp(fallDownKey))
            isFastFalling = false;

        if (isFastFalling)
        {
            if (Time.time - lastFall >= fastFallSpeed)
            {
                Move(Vector3.down);
                lastFall = Time.time;
            }
        }
        else
        {
            if (Time.time - lastFall >= gameManager.fallSpeed)
            {
                Move(Vector3.down);
                lastFall = Time.time;
            }
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
                gridManager.StoreTetromino(transform, playerNumber);
                gridManager.CheckLines(playerNumber);

                if (gridManager.IsGameOver(playerNumber))
                {
                    gameManager.GameOver(playerNumber);
                }
                else
                {
                    gameManager.SpawnTetromino(playerNumber);
                }

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
            position = gridManager.RoundPosition(position);

            if (!gridManager.IsInsideGrid(position, playerNumber))
                return false;

            if (gridManager.GetTransformAtGridPosition(position, playerNumber) != null &&
                gridManager.GetTransformAtGridPosition(position, playerNumber).parent != transform)
                return false;
        }

        return true;
    }
}
