using System.Collections.Generic;
using UnityEngine;

namespace MyRaces
{
    public class MainController : BaseController
    {
        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly List<ItemConfig> _itemConfigs;
        private readonly List<AbilityItemConfig> _abilityItemConfigs;

        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemConfigs,
            List<AbilityItemConfig> abilityItemConfigs)
        {
            _placeForUi = placeForUi;
            _profilePlayer = profilePlayer;
            OnChangeGameState(_profilePlayer.CurrentState.value);
            profilePlayer.CurrentState.SubcribeOnChange(OnChangeGameState);
            _abilityItemConfigs = abilityItemConfigs;
            _itemConfigs = itemConfigs;
        }

        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _profilePlayer.CurrentState.UnSubcribeOnChange(OnChangeGameState);
            base.OnDispose();
        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                    _gameController?.Dispose();
                    break;
                
                case GameState.Game:
                    _gameController = new GameController(_profilePlayer, _placeForUi, _itemConfigs, _abilityItemConfigs);
                    _mainMenuController?.Dispose();
                    break;
                
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
            }
        }
    }
}
