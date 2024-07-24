
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    public Transform[,] playerOneGrid;
    public Transform[,] playerTwoGrid;

    public Vector2 gridDimensions; 

    void Awake()
    {
        if (instance == null)
            instance = this;

        gridDimensions = new Vector2(Mathf.RoundToInt(transform.localScale.x), Mathf.RoundToInt(transform.localScale.y));

        playerOneGrid = new Transform[(int)gridDimensions.x, (int)gridDimensions.y];
        playerTwoGrid = new Transform[(int)gridDimensions.x, (int)gridDimensions.y];
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        for (int x = 0; x < gridDimensions.x; x++)
        {
            for (int y = 0; y < gridDimensions.y; y++)
            {
                Vector2 position = transform.position + new Vector3(x, y);
                Gizmos.DrawWireCube(position, Vector2.one);
            }
        }
    }

    public bool IsInsideGrid(Vector2 position, int playerNumber)
    {
        return (int)position.x >= 0 && (int)position.x < gridDimensions.x &&
               (int)position.y >= 0 && (int)position.y < gridDimensions.y;
    }

    public Vector3 RoundPosition(Vector2 position)
    {
        return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y));
    }

    public Transform GetTransformAtGridPosition(Vector3 position, int playerNumber)
    {
        if (position.y >= gridDimensions.y)
            return null;

        return playerNumber == 1 ? playerOneGrid[(int)position.x, (int)position.y] : playerTwoGrid[(int)position.x, (int)position.y];
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
