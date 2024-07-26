using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSlidesDown : MonoBehaviour
{
    [SerializeField] Animator m_Animator;
    [SerializeField] PuzzleCode puzzleCode;

    void CheckPuzzleCode()
    {
        if(puzzleCode.codeHasMatch == true)
        {
            m_Animator.SetBool("DoorGoesDown", true);
        }
        else
        {
            m_Animator.SetBool("DoorGoesDown", false);
        }
    }

    private void Update()
    {
        CheckPuzzleCode();
    }
}
