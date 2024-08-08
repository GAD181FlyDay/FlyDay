using Player.Two;
using XAndOMinigame;

public class PlayerTwoXAndOController : Player2Controller
{
    #region Variables.
    private XAndOMinigameNewLogic _xAndOLogic;
    #endregion

    private void Start()
    {
        _xAndOLogic = FindAnyObjectByType<XAndOMinigameNewLogic>();
    }

    protected override void Update()
    {
        if (_xAndOLogic.CurrentPlayer == "O")
        {
            base.Update();
        }
    }
}