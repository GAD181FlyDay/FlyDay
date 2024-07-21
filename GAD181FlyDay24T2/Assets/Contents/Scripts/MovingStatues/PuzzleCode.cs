using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCode : MonoBehaviour
{
    [SerializeField] int[] puzzleCode;
    [SerializeField] StatueMovingCode[] statueMovingCode;

    bool CheckStatueCode()
    {
        for (int i = 0; i < puzzleCode.Length; i++)
        {
            if (statueMovingCode[i].currentCodeRotation != puzzleCode[i])
            {
                return false;
            }
        }
        return true;
    }

    private void Update()
    {
        Debug.Log(CheckStatueCode());
    }
}
