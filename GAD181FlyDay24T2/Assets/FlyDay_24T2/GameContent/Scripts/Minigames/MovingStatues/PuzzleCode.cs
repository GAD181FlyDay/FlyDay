using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCode : MonoBehaviour
{
    [SerializeField] int[] puzzleCode;
    [SerializeField] StatueMovingCode[] statueMovingCode;
    public bool codeHasMatch;
    [SerializeField] PaintingPuzzle[] paintingPuzzles;
    [SerializeField] GameObject[] paintingPuzzleCheckBox;

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
    void CheckBoxes()
    {
        for(int i = 0;i < puzzleCode.Length; i++)
        {
            if (paintingPuzzles[i].currentCodeRotation == puzzleCode[i])
            {
                paintingPuzzleCheckBox[i].GetComponent<MeshRenderer>().material.color = Color.green;
            }
            else
            {
                paintingPuzzleCheckBox[i].GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }    
    }

    private void Update()
    {
        CheckStatueCode();
        CheckBoxes();
    }
}
