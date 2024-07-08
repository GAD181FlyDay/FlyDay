using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    /// <summary>
    /// This is a Scriptable object that stores Narrative related data.
    /// </summary>

    [CreateAssetMenu(fileName = "NarrativeStateData")]
    public class NarrativeStateStorage : ScriptableObject
    {
        #region Enum
        public enum NarrativeStates
        {
            PacsonsHouse,
            Taxi,
            ReachedAirport,
            PassportControl,
            LuggageCheck,
            InsideAirport,
            ReachedDutyFree,
            PlaneBoarded,
            FinchsHouse
            // Add more stages as needed
        }
        #endregion

        // What state is it right now?
        public NarrativeStates stateType;

        // What narrative is related to that state?
        public string[] narrativeEntries;

        // What state is it after the narrative has been played?
        public NarrativeStates nextState;
    }
}