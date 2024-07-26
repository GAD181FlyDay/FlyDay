using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dana
{


    public class Scripts_MinigameMovingStatues : Scripts_Generic_InteractionBase
    {
        public override void Interact()
        {
            SceneManager.LoadScene("MovingStatues");
        }
    }
}