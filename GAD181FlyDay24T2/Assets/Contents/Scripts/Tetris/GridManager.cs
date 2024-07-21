using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance;
    public Vector2 gridDimensions = new Vector2(10, 20); 

    public Transform[,] grid;

    void Awake()
    {
        if (instance == null)
            instance = this;
            return;

    }

    public bool IsInsideGrid(Vector3 position)
    {
        return (int)position.x >= 0 && (int)position.x < gridDimensions.x &&
               (int)position.y >= 0;
    }

    public Vector3 RoundPosition(Vector3 position)
    {
        return new Vector3(Mathf.Round(position.x), Mathf.Round(position.y), 0);
    }

    public void StoreTetromino(Transform tetromino)
    {
        foreach (Transform block in tetromino)
        {
            Vector3 position = block.position;
            position = RoundPosition(position);

            grid[(int)position.x, (int)position.y] = block;
        }
    }

    public Transform GetTransformAtGridPosition(Vector3 position)
    {
        if (IsInsideGrid(position))
            return grid[(int)position.x, (int)position.y];
        else
            return null;
    }

    public void CheckLines()
    {
        for (int y = 0; y < gridDimensions.y; y++)
        {
            if (IsLineComplete(y))
            {
                ClearLine(y);
                MoveLinesDown(y);
            }
        }
    }

    bool IsLineComplete(int y)
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            if (grid[x, y] == null)
                return false;
        }
        return true;
    }

    void ClearLine(int y)
    {
        for (int x = 0; x < gridDimensions.x; x++)
        {
            Destroy(grid[x, y].gameObject);
            grid[x, y] = null;
        }
    }

    void MoveLinesDown(int startY)
    {
        for (int y = startY + 1; y < gridDimensions.y; y++)
        {
            for (int x = 0; x < gridDimensions.x; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }

    public bool IsGameOver(Transform tetromino)
    {
        foreach (Transform block in tetromino)
        {
            Vector3 position = block.position;
            position = RoundPosition(position);

            if (grid[(int)position.x, (int)position.y] != null)
                return true;
        }

        return false;
    }
}

