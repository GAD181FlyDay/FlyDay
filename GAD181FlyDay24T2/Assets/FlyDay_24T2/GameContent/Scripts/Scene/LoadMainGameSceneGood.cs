using DutyFree;
using UnityEngine;

public class LoadMainGameSceneGood : MonoBehaviour
{
    private void Start()
    {
        DataManager.Instance.SetGameState(7);
        Invoke("SceneLoadDelayer", 5f);
    }

    private void SceneLoadDelayer()
    {
        if (DataManager.Instance.PlayerData.currentStateInt == 7)
        {
            SceneTransitionManager.Instance.LoadSceneBasedOnState(9); 
        }
    }
}
