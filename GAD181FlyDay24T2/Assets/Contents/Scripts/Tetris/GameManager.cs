using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] tetrominoShapes;
    public float fallSpeed = 0.15f;

    private GameObject currentTetrominoPlayer1;
    private GameObject currentTetrominoPlayer2;
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
        SpawnNextTetromino(Players.one);
        SpawnNextTetromino(Players.two);
    }

    void Update()
    {
        if (gameOver)
            return;

        // Additional logic can be added here if needed
    }

    public void SpawnNextTetromino(Players player)
    {
        if (player == Players.one)
        {
            if (currentTetrominoPlayer1 != null)
                Destroy(currentTetrominoPlayer1);

            int randomIndex = Random.Range(0, tetrominoShapes.Length);
            currentTetrominoPlayer1 = Instantiate(tetrominoShapes[randomIndex], new Vector3(3, 20, 0), Quaternion.identity);
            currentTetrominoPlayer1.GetComponent<Tetromino>().player = Players.one;
        }
        else if (player == Players.two)
        {
            if (currentTetrominoPlayer2 != null)
                Destroy(currentTetrominoPlayer2);

            int randomIndex = Random.Range(0, tetrominoShapes.Length);
            currentTetrominoPlayer2 = Instantiate(tetrominoShapes[randomIndex], new Vector3(7, 20, 0), Quaternion.identity);
            currentTetrominoPlayer2.GetComponent<Tetromino>().player = Players.two;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over!");
    }
}