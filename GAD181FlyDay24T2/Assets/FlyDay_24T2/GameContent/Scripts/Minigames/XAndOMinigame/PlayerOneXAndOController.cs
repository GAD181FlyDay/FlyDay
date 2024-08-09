using Player.One;
using XAndOMinigame;

namespace XAndOMinigame
{
    /// <summary>
    /// This script overrides regular player controller for x and o minigame.
    /// </summary>
    public class PlayerOneXAndOController : PlayerControls
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
            if (_xAndOLogic.CurrentPlayer == "X")
            {
                base.Update();
            }
        }
    }
}
