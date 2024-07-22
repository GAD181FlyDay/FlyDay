using System.Runtime.CompilerServices;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public Vector2 gridDimensions = new Vector2(9, 18);
    public float cellSize = 1f; // Size of each grid cell
    public Color gridColor = Color.gray; // Color for grid lines

    private Transform[,] playerOneGrid;
    private Transform[,] playerTwoGrid;

    void Awake()
    {
        if (instance == null)
            instance = this;

        playerOneGrid = new Transform[(int)gridDimensions.x, (int)gridDimensions.y];
        playerTwoGrid = new Transform[(int)gridDimensions.x, (int)gridDimensions.y];
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = gridColor;

        for (int x = 0; x <= gridDimensions.x; x++)
        {
            Gizmos.DrawLine(new Vector3(x * cellSize, 0, 0), new Vector3(x * cellSize, gridDimensions.y * cellSize, 0));
        }

        for (int y = 0; y <= gridDimensions.y; y++)
        {
            Gizmos.DrawLine(new Vector3(0, y * cellSize, 0), new Vector3(gridDimensions.x * cellSize, y * cellSize, 0));
        }
    }
    public bool IsInsideGrid(Vector3 position, int playerNumber)
    {
        return (int)position.x >= 0 && (int)position.x < gridDimensions.x &&
               (int)position.y >= 0 && (int)position.y < gridDimensions.y;
    }

    public Vector3 RoundPosition(Vector3 position)
    {
        return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), Mathf.Round(position.z));
    }

    public Transform GetTransformAtGridPosition(Vector3 position, int playerNumber)
    {
        if (playerNumber == 1)
        {
            if (position.y > gridDimensions.y - 1)
                return null;

            return playerOneGrid[(int)position.x, (int)position.y];
        }
        else if (playerNumber == 2)
        {
            if (position.y > gridDimensions.y - 1)
                return null;

            return playerTwoGrid[(int)position.x, (int)position.y];
        }

        return null;
    }

    public void StoreTetromino(Transform tetromino, int playerNumber)
    {
        foreach (Transform block in tetromino)
        {
            Vector3 position = RoundPosition(block.position);

            if (playerNumber == 1)
            {
                playerOneGrid[(int)position.x, (int)position.y] = block;
            }
            else if (playerNumber == 2)
            {
                playerTwoGrid[(int)position.x, (int)position.y] = block;
            }
        }
    }

    public void CheckLines(int playerNumber)
    {
        for (int y = 0; y < gridDimensions.y; y++)
        {
            if (IsFullLine(y, playerNumber))
            {
                DeleteLine(y, playerNumber);
                MoveDownLinesAbove(y, playerNumber);
                y--;
            }
        }
    }

    bool IsFullLine(int y, int playerNumber)
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            if (playerNumber == 1 && playerOneGrid[x, y] == null)
                return false;
            else if (playerNumber == 2 && playerTwoGrid[x, y] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int y, int playerNumber)
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            if (playerNumber == 1)
            {
                Destroy(playerOneGrid[x, y].gameObject);
                playerOneGrid[x, y] = null;
            }
            else if (playerNumber == 2)
            {
                Destroy(playerTwoGrid[x, y].gameObject);
                playerTwoGrid[x, y] = null;
            }
        }
    }

    void MoveDownLinesAbove(int y, int playerNumber)
    {
        for (int i = y; i < gridDimensions.y; i++)
        {
            MoveDownLine(i, playerNumber);
        }
    }

    void MoveDownLine(int y, int playerNumber)
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            if (playerNumber == 1)
            {
                if (playerOneGrid[x, y] != null)
                {
                    playerOneGrid[x, y - 1] = playerOneGrid[x, y];
                    playerOneGrid[x, y] = null;
                    playerOneGrid[x, y - 1].position += Vector3.down;
                }
            }
            else if (playerNumber == 2)
            {
                if (playerTwoGrid[x, y] != null)
                {
                    playerTwoGrid[x, y - 1] = playerTwoGrid[x, y];
                    playerTwoGrid[x, y] = null;
                    playerTwoGrid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }

    public bool IsGameOver(int playerNumber)
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            if (playerNumber == 1 && playerOneGrid[x, (int)gridDimensions.y - 1] != null)
                return true;
            else if (playerNumber == 2 && playerTwoGrid[x, (int)gridDimensions.y - 1] != null)
                return true;
        }
        return false;
    }
}
