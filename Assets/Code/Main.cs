using System.Linq;
using UnityEngine;

namespace MyRaces
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        [SerializeField] private UnityAdsTools _unityAdsTools;
        [SerializeField] private ItemConfig[] _itemConfigs;
        [SerializeField] private AbilityItemConfig[] _abilityItemConfigs;
        //private MainController _mainController;
        
        private CursorController _cursorController;

        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
            profilePlayer.CurrentState.value = GameState.Start;
            new MainController(_placeForUI, profilePlayer, _itemConfigs.ToList(), _abilityItemConfigs.ToList());
            
            
            _cursorController = new CursorController();
        }

        private void Update()
        {
            _cursorController.OnUpdate();
        }
    }
}