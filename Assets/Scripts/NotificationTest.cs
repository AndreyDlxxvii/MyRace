using System;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;
//using Unity.Notifications.iOS;



namespace DefaultNamespace
{
    public class NotificationTest : MonoBehaviour
    {
        [SerializeField] private Button _notificationButton;

        private const string AndroidChannelId = "android_id";

        private void Awake()
        {
            var androidChanel = new AndroidNotificationChannel
            {
                Id = AndroidChannelId,
                Name = "MyNotification",
                Description = "Тестовое сообщение!",
                CanBypassDnd = true,
                EnableVibration = true,
                EnableLights = true,
                Importance = Importance.High,
                CanShowBadge = true,
                LockScreenVisibility = LockScreenVisibility.Public

            };
            AndroidNotificationCenter.RegisterNotificationChannel(androidChanel);
        }

        private void Start()
        {
            _notificationButton.onClick.AddListener(ShowNotification);
            
        }

        private void ShowNotification()
        {
#if UNITY_ANDROID
            NotificationAndroid();
#elif UNITY_IOS
            NotificationIOS();
#endif
            
        }

        private void NotificationAndroid()
        {
            var androidNotification = new AndroidNotification
            {
                Color = Color.yellow,
                FireTime = DateTime.Now + TimeSpan.FromSeconds(5),
                RepeatInterval = TimeSpan.FromSeconds(15),
                Text = "Тестовое сообщение"
            };

            AndroidNotificationCenter.SendNotification(androidNotification, AndroidChannelId);
            AndroidNotificationCenter.DeleteNotificationChannel(AndroidChannelId);
        }

        // private void NotificationIOS()
        // {
        //     var iosNotification = new iOSNotification
        //     {
        //         Identifier = "iosId",
        //         Title = "Уведомление",
        //         Body = "Тема уведомления",
        //         ForegroundPresentationOption = PresentationOption.Sound | PresentationOption.Badge | PresentationOption.Alert,
        //         Data = "07/02/2022"
        //     };
        //     iOSNotificationCenter.ScheduleNotification(iosNotification);
        // }

        private void OnDestroy()
        {
            _notificationButton.onClick.RemoveAllListeners();
        }
    }
}