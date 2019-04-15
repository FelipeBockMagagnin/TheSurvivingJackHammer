using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class NotificationExample : MonoBehaviour
    {
        private void Start()
        {
            CancelAll();
        }

        public void ScheduleNormal()
        {
            NotificationManager.SendWithAppIcon(TimeSpan.FromHours(4), "The Surviving JackHammer", "Time to beat some bad guys :)", new Color(0, 0.6f, 1), NotificationIcon.Clock);
            NotificationManager.SendWithAppIcon(TimeSpan.FromHours(23), "The Surviving JackHammer", "Time to play :)", new Color(0, 0.6f, 1), NotificationIcon.Clock);
        }

        public void CancelAll()
        {
            NotificationManager.CancelAll();
        }

        public void Rate()
        {
            Application.OpenURL("http://u3d.as/y6r");
        }

        public void OpenWiki()
        {
            Application.OpenURL("https://github.com/hippogamesunity/SimpleAndroidNotificationsPublic/wiki");
        }

        private void OnApplicationPause(bool pause)
        {
            if (pause)
            {
                ScheduleNormal();
            }
            else
            {
                CancelAll();
            }
        }
    }
}