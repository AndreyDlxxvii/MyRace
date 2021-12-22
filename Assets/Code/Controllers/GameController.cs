using UnityEngine;

namespace MyRaces
{
    public class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, Transform placeUI)
        {
            var leftMove = new SubscribeProperty<float>();
            var rightMove = new SubscribeProperty<float>();
            
            var carController = new CarController();
            AddControler(carController);
            
            var inputGameController = new BtnCtrlController(leftMove, rightMove, profilePlayer.CurrentCar, placeUI);
            AddControler(inputGameController);
            
            var tapeController = new TapeBackgroundController(leftMove, rightMove);
            AddControler(tapeController);
        }
    }
}