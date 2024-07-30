
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Minigame_JUstifiableShoplifting : Scripts_InteractionBaseToOverride
{
    public override void Interact()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("JustifiableShoplifting");
    }
}
