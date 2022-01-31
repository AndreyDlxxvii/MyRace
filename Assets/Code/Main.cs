using System.Linq;
using UnityEngine;
using DG.Tweening;

namespace MyRaces
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        [SerializeField] private UnityAdsTools _unityAdsTools;
        [SerializeField] private ItemConfig[] _itemConfigs;
        [SerializeField] private AbilityItemConfig[] _abilityItemConfigs;

        [SerializeField] private DailyRewardView _dailyRewardView;
        [SerializeField] private CurrencyView _currencyView;
        [SerializeField] private FightWindowView _fightWindowView;
        [SerializeField] private StartFightWindowView _startFightWindowView;
        
        private CursorController _cursorController;

        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
            profilePlayer.CurrentState.value = GameState.Start;
            new MainController(_placeForUI, profilePlayer, _itemConfigs.ToList(), _abilityItemConfigs.ToList(), _dailyRewardView,
                _currencyView, _fightWindowView, _startFightWindowView);
            
            
            _cursorController = new CursorController();
        }

        private void Update()
        {
            _cursorController.OnUpdate();
        }
    }
}