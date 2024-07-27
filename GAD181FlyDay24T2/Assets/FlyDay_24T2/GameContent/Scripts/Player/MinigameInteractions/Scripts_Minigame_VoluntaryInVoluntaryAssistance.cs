using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dana
{

public class Scripts_Minigame_VoluntaryInVoluntaryAssistance : Scripts_Generic_InteractionBase
{
    public override void Interact()
    {
        SceneManager.LoadScene("VoluntaryInVoluntaryAssistance");
    }
}
}