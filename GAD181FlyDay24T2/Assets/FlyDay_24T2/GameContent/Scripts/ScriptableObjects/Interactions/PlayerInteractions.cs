using UnityEngine;

[CreateAssetMenu]

public class PlayerInteractions : ScriptableObject
{
    /// <summary>
    /// Keeps track of what stands have been interacted with.
    /// </summary>
    public bool taxiStand;
    public bool justifiableShopliftingStand;
    public bool voluntaryInVoluntaryAssistance;
    public bool xAndOStand;
    public bool dontMove;
    public bool seeSawBridge;
}
