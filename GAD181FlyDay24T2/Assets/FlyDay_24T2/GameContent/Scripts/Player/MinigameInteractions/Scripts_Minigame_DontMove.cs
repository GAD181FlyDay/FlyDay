using UnityEngine.SceneManagement;

public class Scripts_Minigame_DontMove : Scripts_Generic_InteractionBase
{
    public override void Interact()
    {
        SceneManager.LoadScene("DontMove");
    }
}
