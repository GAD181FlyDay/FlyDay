using UnityEngine.SceneManagement;

public class Scripts_Minigame_TaxiMeter : Scripts_Generic_InteractionBase
{
    public override void Interact()
    {
        SceneManager.LoadScene("TaxiMeter");
    }
}
