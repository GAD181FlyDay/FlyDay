using UnityEngine;

public class InspectorStatesEnabler : MonoBehaviour
{
    #region Variables.
    public bool pacsonHouse;
    public bool Airport;
    public bool airportBlankState;
    public bool dutyFree;
    public bool dutyFreeBlankState;
    public bool boarding;
    public bool finchsHouseGood;
    public bool finchsHouseBad;

    [SerializeField] private PlayerSaveData playerSaveData;
    #endregion
    
    private void Update()
    {
        if (pacsonHouse) { playerSaveData.currentStateInt = 0; }
        if (Airport) { playerSaveData.currentStateInt = 1; }
        if (airportBlankState) { playerSaveData.currentStateInt = 2; }
        if (dutyFree) { playerSaveData.currentStateInt = 3; }
        if (dutyFreeBlankState) { playerSaveData.currentStateInt = 4; }
        if (boarding) { playerSaveData.currentStateInt = 5; }
        if (finchsHouseGood) { playerSaveData.currentStateInt = 6;}
        if (finchsHouseBad) { playerSaveData.currentStateInt = 7;}
    }
}
