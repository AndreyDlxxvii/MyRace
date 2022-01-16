using System.Collections.Generic;
using UnityEngine;

namespace MyRaces
{
    public class GameController : BaseController
    {
        public GameController(ProfilePlayer profilePlayer, Transform placeUI, List<ItemConfig> itemConfigs,
            List<AbilityItemConfig> abilityItemConfigs)
        {
            var leftMove = new SubscribeProperty<float>();
            var rightMove = new SubscribeProperty<float>();
            
            var carController = new CarController();
            AddControler(carController);
            
            var inputGameController = new BtnCtrlController(leftMove, rightMove, profilePlayer.CurrentCar, placeUI);
            AddControler(inputGameController);
            
            var tapeController = new TapeBackgroundController(leftMove, rightMove);
            AddControler(tapeController);
            
            var inventoryController = new InventoryController(itemConfigs, placeUI, carController.GetViewObject());
            AddControler(inventoryController);
            
            var abilityController = new AbilityController(placeUI, abilityItemConfigs);
            AddControler(abilityController);
        }
    }
}