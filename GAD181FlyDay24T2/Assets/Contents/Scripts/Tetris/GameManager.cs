using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] tetrominoShapes;
    public float minSpawnDelay = 1f;
    public float maxSpawnDelay = 3f;

    [SerializeField] private Vector2 playerOneTempPos = new Vector2(0, 21);
    [SerializeField] private Vector2 playerTwoTempPos = new Vector2(20, 21);

    private GameObject currentTetrominoPlayer1;
    private GameObject currentTetrominoPlayer2;
    private bool gameOver = false;

    // Enum to represent player numbers
    public enum PlayerNumber
    {
        One,
        Two
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(SpawnTetrominoes());
    }

    IEnumerator SpawnTetrominoes()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

            SpawnNextTetromino(PlayerNumber.One);

            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));

            SpawnNextTetromino(PlayerNumber.Two);
        }
    }

    public void SpawnNextTetromino(PlayerNumber player)
    {
        if (player == PlayerNumber.One)
        {
            if (currentTetrominoPlayer1 != null)
                Destroy(currentTetrominoPlayer1);

            int randomIndex = Random.Range(0, tetrominoShapes.Length);
            currentTetrominoPlayer1 = Instantiate(tetrominoShapes[randomIndex], playerOneTempPos, Quaternion.identity);
            currentTetrominoPlayer1.GetComponent<Tetromino>().player = PlayerNumber.One;
        }
        else if (player == PlayerNumber.Two)
        {
            if (currentTetrominoPlayer2 != null)
                Destroy(currentTetrominoPlayer2);

            int randomIndex = Random.Range(0, tetrominoShapes.Length);
            currentTetrominoPlayer2 = Instantiate(tetrominoShapes[randomIndex], playerTwoTempPos, Quaternion.identity);
            currentTetrominoPlayer2.GetComponent<Tetromino>().player = PlayerNumber.Two;
        }
    }

    public void GameOver(PlayerNumber player)
    {
        if (player == PlayerNumber.One)
        {
            if (currentTetrominoPlayer1 != null)
                Destroy(currentTetrominoPlayer1);
        }
        else if (player == PlayerNumber.Two)
        {
            if (currentTetrominoPlayer2 != null)
                Destroy(currentTetrominoPlayer2);
        }

        gameOver = true;
        Debug.Log("Player " + player + " Game Over!");
    }
}

