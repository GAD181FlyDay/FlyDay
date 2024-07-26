

using UnityEngine;
using UnityEngine.SceneManagement;

// Hello!! Attach to any game object within main game scene!!!

public class TEMP_SceneManager : MonoBehaviour
{
    public string sceneToAlwaysLoad = "MinigameStands"; 

    void Start()
    {
        if (!SceneManager.GetSceneByName(sceneToAlwaysLoad).isLoaded)
        {
            SceneManager.LoadScene("MinigameStands", LoadSceneMode.Additive);
        }
    }
}
