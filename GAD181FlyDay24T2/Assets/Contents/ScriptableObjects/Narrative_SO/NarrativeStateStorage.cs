using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    /// <summary>
    /// This is a Scriptable object that stores Narrative related data.
    /// </summary>

    #region Enum
    public enum NarrativeStates
    {
        PacsonsHouse,
        Taxi,
        ReachedAirport,
        InsideAirport,
        ReachedDutyFree,
        PlaneBoarded,
        FinchsHouse
        // Add more stages as needed
    }
    #endregion

    [CreateAssetMenu(fileName = "NarrativeStateData")]
    public class NarrativeStateStorage : ScriptableObject
    {
        public NarrativeStates stateType; // What state is it right now?
        public string[] narrativeEntries; // What narrative is related to that state?
        public NarrativeStates nextState; // What state is it after the narrative has been played?
    }
}