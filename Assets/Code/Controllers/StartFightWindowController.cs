using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace MyRaces
{
    public class StartFightWindowController : BaseController
    {
        private StartFightWindowView _startFight;
        private ProfilePlayer _profilePlayer;
        public StartFightWindowController(Transform placeForUI, ProfilePlayer profilePlayer, StartFightWindowView startFightWindowView)
        {
            _profilePlayer = profilePlayer;
            _startFight = Object.Instantiate(startFightWindowView, placeForUI);
             AddGameObject(_startFight.gameObject);
             _startFight.StartFigth.onClick.AddListener(StartFight);
        }
        

        private void StartFight()
        {
            _profilePlayer.CurrentState.value = GameState.Fight;
        }

        protected override void OnDispose()
        {
            _startFight.StartFigth.onClick.RemoveAllListeners();
            base.OnDispose();
        }
    }
}