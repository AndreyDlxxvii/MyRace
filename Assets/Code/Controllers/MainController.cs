using System.Collections.Generic;
using UnityEngine;

namespace MyRaces
{
    public class MainController : BaseController
    {
        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private DailyRewardController _dailyRewardController;
        private FightWindowController _fightWindowController;
        private StartFightWindowController _startFightWindowController;
        
        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly DailyRewardView _dailyRewardView;
        private readonly CurrencyView _currencyView;
        private readonly FightWindowView _fightWindowView;
        private readonly StartFightWindowView _startFightWindowView;
        
        private readonly List<ItemConfig> _itemConfigs;
        private readonly List<AbilityItemConfig> _abilityItemConfigs;

        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemConfigs,
            List<AbilityItemConfig> abilityItemConfigs, DailyRewardView dailyRewardView, 
            CurrencyView currencyView, FightWindowView fightWindowView, StartFightWindowView startFightWindowView)
        {
            _dailyRewardView = dailyRewardView;
            _currencyView = currencyView;
            _fightWindowView = fightWindowView;
            _startFightWindowView = startFightWindowView;
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
                    _dailyRewardController?.Dispose();
                    break;
                
                case GameState.Game:
                    _gameController = new GameController(_profilePlayer, _placeForUi, _itemConfigs, _abilityItemConfigs);
                    _startFightWindowController = new StartFightWindowController(_placeForUi, _profilePlayer, _startFightWindowView);
                    
                    _mainMenuController?.Dispose();
                    _fightWindowController?.Dispose();
                    break;
                
                case GameState.Reward:
                    _dailyRewardController = new DailyRewardController(_placeForUi, _dailyRewardView, _profilePlayer, _currencyView);
                    _dailyRewardController.RefreshView();
                    
                    _mainMenuController?.Dispose();
                    break;
                
                case GameState.Fight:
                    _fightWindowController = new FightWindowController(_placeForUi, _profilePlayer, _fightWindowView);
                    _fightWindowController.RefreshView();
                    
                    _gameController?.Dispose();
                    _startFightWindowController?.Dispose();
                    break;
                
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    _fightWindowController?.Dispose();
                    _dailyRewardController?.Dispose();
                    _startFightWindowController?.Dispose();
                    break;
            }
        }
    }
}
