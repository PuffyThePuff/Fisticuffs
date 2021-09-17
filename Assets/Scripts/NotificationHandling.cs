using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationHandling : MonoBehaviour
{
    private void BuildOnDemandNotifChannel()
    {
        string channelID = "ondemand";
        string title = "On-Demand Notifications";
        string description = "Notifications sent ten seconds after requested through the Options menu.";
        Importance importance = Importance.Default;

        AndroidNotificationChannel onDemandChannel = new AndroidNotificationChannel(channelID, title, description, importance);
        AndroidNotificationCenter.RegisterNotificationChannel(onDemandChannel);
    }

    public void SendOnDemandNotif()
    {
        string title = "Requested Notification";
        string message = "Here is your requested notification. Now play more Fisticuffs.";
        System.DateTime sendTime = System.DateTime.Now.AddSeconds(10);

        AndroidNotification onDemandNotif = new AndroidNotification(title, message, sendTime);
        AndroidNotificationCenter.SendNotification(onDemandNotif, "ondemand");
    }

    private void Awake()
    {
        BuildOnDemandNotifChannel();
    }
}