using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Minigame_XnOs : Scripts_InteractionBaseToOverride
{
    public override void Interact()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("XAndOMinigame_Test");
    }
}
