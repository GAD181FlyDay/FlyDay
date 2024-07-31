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
            Airport,
            StoreBeforeDutyFree,
            DutyFree,
            Boarding,
            FinchsHouse
        }
        #endregion

        // What state is it right now?
        public NarrativeStates stateType;

        // What narrative (text and images) are related to that state?
        public string[] narrativeEntries;
        public Sprite[] narrativeImages;

        // What state is it after the narrative has been played?
        public NarrativeStates nextState;
    }
}