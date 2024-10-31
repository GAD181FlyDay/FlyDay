using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    private bool isTransitioning = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadSceneBasedOnState(int state)
    {
        if (isTransitioning)
        {
            Debug.Log("Cant load another scene.");
            return;
        }

        isTransitioning = true;
        string sceneName = GetSceneNameForState(state);

        if (!string.IsNullOrEmpty(sceneName) && SceneManager.GetActiveScene().name != sceneName)
        {
            Debug.Log($"Starting transition to scene: {sceneName} for state: {state}");
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.Log("Scene is already loaded");
            isTransitioning = false;  
        }
    }

    private string GetSceneNameForState(int state)
    {
        switch (state)
        {
            case 5:
            case 6:
            case 9:
                return "MainGameScene";
            case 7:
                return "LoadMainGameGoodScene";
            case 8:
                return "LoadMainGameBadScene";
            case 10:
                return "BlankSceneRefresher";
            default:
                return null;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isTransitioning = false;
        Debug.Log("Scene loaded successfully");
    }
}
