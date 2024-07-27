using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChange: MonoBehavior
{
   public void LoadScene(string LuggagePacking)
    {
        SceneManager.LoadScene(LuggagePacking);
    }
}
