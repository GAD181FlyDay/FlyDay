using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] tetrominoShapes; 
    public float fallSpeed = 0.15f; 

    [SerializeField] private GameObject nextTetromino;
    private bool gameOver = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    void Start()
    {
        SpawnNextTetromino();
    }

    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                MoveTetromino(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                MoveTetromino(Vector3.right);
            else if (Input.GetKeyDown(KeyCode.UpArrow))
                RotateTetromino();
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                IncreaseFallSpeed(); 

            if (Time.time - fallSpeed >= 0)
            {
                MoveTetromino(Vector3.down);
                fallSpeed = Time.time;
            }
        }
    }

    void SpawnNextTetromino()
    {
        int randomIndex = Random.Range(0, tetrominoShapes.Length);
        nextTetromino = Instantiate(tetrominoShapes[randomIndex], transform.position, Quaternion.identity);
    }

    void MoveTetromino(Vector3 direction)
    {
        nextTetromino.transform.position += direction;

        if (!IsValidPosition())
        {
            nextTetromino.transform.position -= direction;
            if (direction == Vector3.down)
            {
                nextTetromino.SetActive(false);
                SpawnNextTetromino();
            }
        }
    }

    void RotateTetromino()
    {
        nextTetromino.transform.Rotate(0, 0, -90);


        if (!IsValidPosition())
            nextTetromino.transform.Rotate(0, 0, 90);
    }

    bool IsValidPosition()
    {
        foreach (Transform block in nextTetromino.transform)
        {
            Vector3 position = block.position;
            position = GridManager.instance.RoundPosition(position);

            if (!GridManager.instance.IsInsideGrid(position))
                return false;

            if (GridManager.instance.GetTransformAtGridPosition(position) != null && GridManager.instance.GetTransformAtGridPosition(position).parent != nextTetromino.transform)
                return false;
        }

        return true;
    }

    void IncreaseFallSpeed()
    {
        fallSpeed = 0.05f;
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}


