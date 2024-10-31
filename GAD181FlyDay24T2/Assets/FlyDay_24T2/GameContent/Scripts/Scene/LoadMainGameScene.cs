using UnityEngine;

public class LoadMainGameScene : MonoBehaviour
{
    private void Start()
    {
        DataManager.Instance.SetGameState(5);
        Invoke("SceneLoadDelayer", 5f);
    }

    private void SceneLoadDelayer()
    {
        if (DataManager.Instance.PlayerData.currentStateInt == 5)
        {
            SceneTransitionManager.Instance.LoadSceneBasedOnState(5);
        }
    }
}
