using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCode : MonoBehaviour
{
    [SerializeField] int[] puzzleCode;
    [SerializeField] StatueMovingCode[] statueMovingCode;
    public bool codeHasMatch;

    void CheckStatueCode()
    {
        for (int i = 0; i < puzzleCode.Length; i++)
        {
            if (statueMovingCode[i].currentCodeRotation != puzzleCode[i])
            {
                codeHasMatch = false;
                return;
            }
        }
        codeHasMatch = true;
    }

    private void Update()
    {
        CheckStatueCode();
    }
}
