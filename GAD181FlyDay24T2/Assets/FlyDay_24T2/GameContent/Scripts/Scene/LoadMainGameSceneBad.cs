using DutyFree;
using UnityEngine;

public class LoadMainGameSceneBad : MonoBehaviour
{
    private void Start()
    {
        DataManager.Instance.SetGameState(8);
        Invoke("SceneLoadDelayer", 5f);
    }

    private void SceneLoadDelayer()
    {
        if (DataManager.Instance.PlayerData.currentStateInt == 8)
        {
            SceneTransitionManager.Instance.LoadSceneBasedOnState(9);
        }
    }
}
