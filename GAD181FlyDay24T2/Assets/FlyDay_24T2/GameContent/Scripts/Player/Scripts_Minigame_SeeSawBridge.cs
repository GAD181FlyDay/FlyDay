using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_MinigameLoad_SeeSawBridge : Scripts_Generic_InteractionBase
{
    public override void Interact()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SeesawBridge");
    }
}
