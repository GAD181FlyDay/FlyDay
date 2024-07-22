using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float fallSpeed = 1.0f;
    public GameObject[] tetrominoPrefabs; // Array of Tetromino Prefabs
    public Transform playerOneSpawner;
    public Transform playerTwoSpawner;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        SpawnTetromino(1);
        SpawnTetromino(2);
    }

    public void SpawnTetromino(int playerNumber)
    {
        int index = Random.Range(0, tetrominoPrefabs.Length);
        Vector3 spawnPosition = playerNumber == 1 ? playerOneSpawner.position : playerTwoSpawner.position;
        GameObject tetromino = Instantiate(tetrominoPrefabs[index], spawnPosition, Quaternion.identity);
        tetromino.GetComponent<Tetromino>().playerNumber = playerNumber;
    }

    public void GameOver(int playerNumber)
    {
        Debug.Log("Player " + playerNumber + " has lost!");
        // Game Over logic like stopping the game, displaying UI yada yada.
    }
}
