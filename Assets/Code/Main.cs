using System;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace MyRaces
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private Transform _placeForUI;
        [SerializeField] private UnityAdsTools _unityAdsTools;
        private MainController _mainController;
        
        private CursorController _cursorController;

        private void Awake()
        {
            var profilePlayer = new ProfilePlayer(15f, _unityAdsTools);
            profilePlayer.CurrentState.value = GameState.Start;
            _mainController = new MainController(_placeForUI, profilePlayer);
            
            
            _cursorController = new CursorController();
        }

        private void Update()
        {
            _cursorController.OnUpdate();
        }
    }
}