using System.Collections;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float lastFall = 0;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameManager.instance;
        if (gameManager == null)
            Debug.LogError("GameManager not found!");
    }

    void Update()
    {
        if (Time.time - lastFall >= gameManager.fallSpeed)
        {
            transform.position += Vector3.down;

            if (!IsValidPosition())
            {
                transform.position -= Vector3.down;
                GridManager.instance.StoreTetromino(transform);
                GridManager.instance.CheckLines();

                if (GridManager.instance.IsGameOver(transform))
                    gameManager.GameOver();

                enabled = false;
            }

            lastFall = Time.time;
        }
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


