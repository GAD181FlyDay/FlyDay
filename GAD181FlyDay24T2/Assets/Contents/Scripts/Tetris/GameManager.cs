using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject[] tetrominoPrefabs;
    public Transform playerOneSpawnPoint;
    public Transform playerTwoSpawnPoint;
    public float fallSpeed = 1f;
    public float fastFallSpeed = 0.5f;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        SpawnNextTetromino(1);
        SpawnNextTetromino(2);
    }

    public void SpawnNextTetromino(int playerNumber)
    {
        Transform spawnPoint = playerNumber == 1 ? playerOneSpawnPoint : playerTwoSpawnPoint;
        GameObject[] tetrominos = playerNumber == 1 ? tetrominoPrefabs : tetrominoPrefabs;

        GameObject tetromino = Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], spawnPoint.position, Quaternion.identity);
        Tetromino tetrominoScript = tetromino.GetComponent<Tetromino>();
        tetrominoScript.playerNumber = playerNumber;
        tetrominoScript.players = playerNumber == 1 ? Players.one : Players.two;
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
    }
}
