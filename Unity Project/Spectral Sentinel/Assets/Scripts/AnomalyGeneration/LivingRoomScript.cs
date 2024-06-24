using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoomScript : MonoBehaviour
{
    [Header("Room")]
    [SerializeField] private string RoomName = "Living Room";

    [Header("Anomalies")]
    [SerializeField] private GameObject CameraMalfunction;
    [SerializeField] private GameObject New;
    [SerializeField] private GameObject ObjectMovement;
    [SerializeField] private GameObject EmergencyBroadcast;
    [SerializeField] private GameObject DemonicPresence;

    [Header("Anomalies Fixed Counter")]
    [SerializeField] private AnomaliesFixed anomaliesFixed;

    private bool isCameraMalfunctionActive = false;
    private bool isNewActive = false;
    private bool isObjectMovementActive = false;
    private bool isEmergencyBroadcastActive = false;
    private bool isDemonicPresenceActive = false;

    public void AnomalyCameraMalfunction()
    {
        if (isCameraMalfunctionActive) return;

        Debug.Log(RoomName + " CameraMalfunction");
        CameraMalfunction.SetActive(true);
        isCameraMalfunctionActive = true;
    }

    public void AnomalyNew()
    {
        if (isNewActive) return;

        Debug.Log(RoomName + " New");
        New.SetActive(true);
        isNewActive = true;
    }

    public void AnomalyObjectMovement()
    {
        if (isObjectMovementActive) return;

        Debug.Log(RoomName + " Object Movement");
        ObjectMovement.SetActive(true);
        isObjectMovementActive = true;
    }

    public void AnomalyEmergencyBroadcast()
    {
        if (isEmergencyBroadcastActive) return;

        Debug.Log(RoomName + " EmergencyBroadcast");
        EmergencyBroadcast.SetActive(true);
        isEmergencyBroadcastActive = true;
    }

    public void AnomalyDemonicPresence()
    {
        if (isDemonicPresenceActive) return;

        Debug.Log(RoomName + " Demonic Presence");
        DemonicPresence.SetActive(true);
        isDemonicPresenceActive = true;
    }

    public void FixAnomaly(string anomalyName)
    {
        if (anomalyName == nameof(AnomalyCameraMalfunction))
        {
            CameraMalfunction.SetActive(false);
            isCameraMalfunctionActive = false;
        }
        if (anomalyName == nameof(AnomalyNew))
        {
            New.SetActive(false);
            isNewActive = false;
        }
        if (anomalyName == nameof(AnomalyObjectMovement))
        {
            ObjectMovement.SetActive(false);
            isObjectMovementActive = false;
        }
        if (anomalyName == nameof(AnomalyEmergencyBroadcast))
        {
            EmergencyBroadcast.SetActive(false);
            isEmergencyBroadcastActive = false;
        }
        if (anomalyName == nameof(AnomalyDemonicPresence))
        {
            DemonicPresence.SetActive(false);
            isDemonicPresenceActive = false;
        }
        anomaliesFixed.AddOne();
    }

    public bool IsAnomalyActive(string anomalyName)
    {
        if (anomalyName == nameof(AnomalyCameraMalfunction))
            return isCameraMalfunctionActive;
        if (anomalyName == nameof(AnomalyNew))
            return isNewActive;
        if (anomalyName == nameof(AnomalyObjectMovement))
            return isObjectMovementActive;
        if (anomalyName == nameof(AnomalyEmergencyBroadcast))
            return isEmergencyBroadcastActive;
        if (anomalyName == nameof(AnomalyDemonicPresence))
            return isDemonicPresenceActive;

        return false;
    }
}