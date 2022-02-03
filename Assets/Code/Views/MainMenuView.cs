using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyRaces
{
    public class MainMenuView : MonoBehaviour, IDisposable
    {
        [SerializeField] private Button _buttonStart;
        [SerializeField] private Button _buttonReward;
        [SerializeField] private Button _buttonExit;

        public void Init(UnityAction startGame, UnityAction reward)
        {
            _buttonStart.onClick.AddListener(startGame);
            _buttonReward.onClick.AddListener(reward);
            _buttonExit.onClick.AddListener(QuitGame);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        public void Dispose()
        {
            _buttonStart.onClick.RemoveAllListeners();
            _buttonReward.onClick.RemoveAllListeners();
            _buttonExit.onClick.RemoveAllListeners();
        }
    }
}
