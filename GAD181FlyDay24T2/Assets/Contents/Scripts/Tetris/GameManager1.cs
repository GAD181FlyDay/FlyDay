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

    public Camera camera1; // Assign Camera1 in the Unity Inspector
    public Camera camera2; // Assign Camera2 in the Unity Inspector

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

        // Set camera viewports
        camera1.rect = new Rect(0, 0, 0.5f, 1);
        camera2.rect = new Rect(0.5f, 0, 0.5f, 1);
    }

    IEnumerator SpawnTetrominoes()
    {
        while (!gameOver)
        {
            SpawnNextTetromino(PlayerNumber.One);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnNextTetromino(PlayerNumber.Two);
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
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
            currentTetrominoPlayer1.GetComponent<Tetromino>().player = (Players)PlayerNumber.One;

            camera1.transform.position = new Vector3(playerOneTempPos.x, playerOneTempPos.y, -10); // Adjust camera position as needed
        }
        else if (player == PlayerNumber.Two)
        {
            if (currentTetrominoPlayer2 != null)
                Destroy(currentTetrominoPlayer2);

            int randomIndex = Random.Range(0, tetrominoShapes.Length);
            currentTetrominoPlayer2 = Instantiate(tetrominoShapes[randomIndex], playerTwoTempPos, Quaternion.identity);
            currentTetrominoPlayer2.GetComponent<Tetromino>().player = (Players)PlayerNumber.Two;

            camera2.transform.position = new Vector3(playerTwoTempPos.x, playerTwoTempPos.y, -10); // Adjust camera position as needed
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

