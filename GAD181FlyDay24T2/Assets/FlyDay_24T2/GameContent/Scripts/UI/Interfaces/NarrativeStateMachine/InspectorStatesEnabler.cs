using UnityEngine;

public class InspectorStatesEnabler : MonoBehaviour
{
    #region Variables.
    public bool firstState;
    public bool secondState;
    public bool thirdState;
    public bool fourthState;
    public bool fifthState;
    public bool sixthState;
    public bool seventhState;
    public bool eighthState;
    public bool ninthState;

    [SerializeField] private PlayerSaveData playerSaveData;
    #endregion
    
    private void Update()
    {
        if (firstState) { playerSaveData.currentStateInt = 0; }
        if (secondState) { playerSaveData.currentStateInt = 1; }
        if (thirdState) { playerSaveData.currentStateInt = 2; }
        if (fourthState) { playerSaveData.currentStateInt = 3; }
        if (fifthState) { playerSaveData.currentStateInt = 4; }
        if (sixthState) { playerSaveData.currentStateInt = 5; }
        if (seventhState) { playerSaveData.currentStateInt = 6;}
        if (eighthState) { playerSaveData.currentStateInt = 7;}
        if (ninthState) { playerSaveData.currentStateInt = 8;}
    }
}
