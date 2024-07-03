using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CollisionGameOver : MonoBehaviour
{
    [SerializeField] GameOverManager gameOverManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameOverManager.EnableGameOverUI();
        }
    }
}
