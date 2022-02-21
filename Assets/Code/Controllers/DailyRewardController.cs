using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyRaces
{
    public class DailyRewardController : BaseController
    {
        private readonly DailyRewardView _dailyRewardView;
        private readonly List<ContainerSlotView> _slotsViews = new List<ContainerSlotView>();
        private bool _isGetReward;
        private readonly CurrencyController _currencyController;
        private readonly ProfilePlayer _profilePlayer;
        private readonly CurrencyView _currencyView;
        
        public DailyRewardController(Transform placeForUI, DailyRewardView dailyRewardView, ProfilePlayer profilePlayer, 
            CurrencyView currencyView)
        {
            _profilePlayer = profilePlayer;
            _currencyView = currencyView;
            
            _dailyRewardView = Object.Instantiate(dailyRewardView, placeForUI);
            AddGameObject(_dailyRewardView.gameObject);
            
            _currencyController = new CurrencyController(placeForUI, _currencyView);
            AddControler(_currencyController);
        }

        public void RefreshView()
        {
            InitSlot();
            _dailyRewardView.StartCoroutine(RewardsStartUpdater());
            RefreshUI();
            SubscribeButtons();
        }
        
        private void InitSlot()
        {
            for (int i = 0; i < _dailyRewardView.Rewards.Count; i++)
            {
                var instanceSLot = Object.Instantiate(_dailyRewardView.ContainerSlotView, _dailyRewardView.MountRootSlotsReward, false);
                _slotsViews.Add(instanceSLot);
            }
        }

        private IEnumerator RewardsStartUpdater()
        {
            while (true)
            {
                RefreshRewardState();
                yield return new WaitForSeconds(1);
            }
        }

        private void RefreshRewardState()
        {
            _isGetReward = true;
            if (_dailyRewardView.TimeGetReward.HasValue)
            {
                var timeSpawn = DateTime.UtcNow - _dailyRewardView.TimeGetReward.Value;
                if (timeSpawn.Seconds > _dailyRewardView.TimeDeadline)
                {
                    _dailyRewardView.TimeGetReward = null;
                    _dailyRewardView.CurrentSlotInActive = 0;
                }
                else if (timeSpawn.Seconds < _dailyRewardView.TimeCooldown)
                {
                    _isGetReward = false;
                }
            }
            RefreshUI();
        }

        private void RefreshUI()
        {
            _dailyRewardView.GetRewardButton.interactable = _isGetReward;

            if (_isGetReward)
            {
                _dailyRewardView.TimerNewReward.text = $"Reward recived";
            }
            else
            {
                if (_dailyRewardView.TimeGetReward != null)
                {
                    var nextClaimTime = _dailyRewardView.TimeGetReward.Value.AddSeconds(_dailyRewardView.TimeCooldown);
                    var currentClaimCooldown = nextClaimTime - DateTime.UtcNow;
                    var timeGetReward = $"{currentClaimCooldown.Days:D2} : {currentClaimCooldown.Hours:D2} : {currentClaimCooldown.Minutes:D2} : {currentClaimCooldown.Seconds:D2}";
                    _dailyRewardView.TimerNewReward.text = $"{timeGetReward}";
                }
            }

            for (int i = 0; i < _slotsViews.Count; i++)
                _slotsViews[i].SetData(_dailyRewardView.Rewards[i], i+1, i == _dailyRewardView.CurrentSlotInActive);
        }
        private void SubscribeButtons()
        {
            _dailyRewardView.GetRewardButton.onClick.AddListener(ClaimReward);
            _dailyRewardView.ResetButton.onClick.AddListener(ResetTimer);
            _dailyRewardView.ExitButton.onClick.AddListener(CloseWindow);
        }

        private void CloseWindow()
        {
            _profilePlayer.CurrentState.value = GameState.Start;
        }

        private void ClaimReward()
        {
            if (!_isGetReward)
                return;
            var reward = _dailyRewardView.Rewards[_dailyRewardView.CurrentSlotInActive];

            switch (reward.RewardType)
            {
                case RewardType.Wood:
                    CurrencyView.Instance.AddWood(reward.CountCurrency);
                    break;
                case RewardType.Diamond:
                    CurrencyView.Instance.AddDiamond(reward.CountCurrency);
                    break;
            }
            _dailyRewardView.TimeGetReward = DateTime.UtcNow;
            _dailyRewardView.CurrentSlotInActive =
                (_dailyRewardView.CurrentSlotInActive + 1) % _dailyRewardView.Rewards.Count;
            RefreshRewardState();
        }

        private void ResetTimer()
        {
            PlayerPrefs.DeleteAll();
            CurrencyView.Instance.RefreshView();
            //_currencyView.RefreshView();
        }

        protected override void OnDispose()
        {
            _dailyRewardView.GetRewardButton.onClick.RemoveAllListeners();
            _dailyRewardView.ResetButton.onClick.RemoveAllListeners();
            _dailyRewardView.ExitButton.onClick.RemoveAllListeners();
            base.OnDispose();
        }
    }
}