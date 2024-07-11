using System.Collections;
using System.Collections.Generic;
using TaxiMeter;
using UnityEngine;

public class MatchingNotes : MonoBehaviour
{
    public Transform matchArea; // Match area transform
    public float matchTolerance = 0.1f; // Tolerance for matching notes
    public int maxInputs = 2; // Maximum inputs per player

    private int inputCounter = 0;
    private float meter = 0.0f;

    void Update()
    {
        // Player one inputs
        if (inputCounter < maxInputs)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                CheckMatch("W");
                inputCounter++;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                CheckMatch("A");
                inputCounter++;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                CheckMatch("S");
                inputCounter++;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                CheckMatch("D");
                inputCounter++;
            }
        }

        // Player two inputs
        if (inputCounter < maxInputs * 2)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CheckMatch("Up");
                inputCounter++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                CheckMatch("Left");
                inputCounter++;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CheckMatch("Down");
                inputCounter++;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                CheckMatch("Right");
                inputCounter++;
            }
        }
    }

    void CheckMatch(string noteType)
    {
        List<GameObject> notesToRemove = new List<GameObject>();
        bool matched = false;

        foreach (GameObject note in NotesSpawner.activeNotes)
        {
            Notes noteComponent = note.GetComponent<Notes>();

            if (noteComponent.noteType == noteType)
            {
                float distance = Vector2.Distance(note.transform.position, matchArea.position);
                if (distance <= matchTolerance)
                {
                    matched = true;
                    notesToRemove.Add(note);
                }
            }
        }

        if (matched)
        {
            meter += 0.25f;
            Debug.Log("Matched: " + noteType);
        }
        else
        {
            meter += 1.0f;
            Debug.Log("Not Matched: " + noteType);
        }

        foreach (GameObject note in notesToRemove)
        {
            NotesSpawner.activeNotes.Remove(note);
            Destroy(note);
        }

        Debug.Log("Meter: " + meter);
    }

    public void ResetInputs()
    {
        inputCounter = 0;
    }
}
