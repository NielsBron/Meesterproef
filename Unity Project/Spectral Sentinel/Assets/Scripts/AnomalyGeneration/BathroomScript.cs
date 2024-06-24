using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomScript : MonoBehaviour
{
    [Header("Room")]
    [SerializeField] private string RoomName = "Bathroom";

    [Header("Anomalies")]
    [SerializeField] private GameObject New;
    [SerializeField] private GameObject ObjectMovement;
    [SerializeField] private GameObject RunningFaucet;
    [SerializeField] private GameObject CursedPainting;
    [SerializeField] private GameObject DemonicPresence;

    [Header("Anomalies Fixed Counter")]
    [SerializeField] private AnomaliesFixed anomaliesFixed;

    private bool isNewActive = false;
    private bool isObjectMovementActive = false;
    private bool isRunningFaucetActive = false;
    private bool isCursedPaintingActive = false;
    private bool isDemonicPresenceActive = false;

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

    public void AnomalyRunningFaucet()
    {
        if (isRunningFaucetActive) return;

        Debug.Log(RoomName + " Running Faucet");
        RunningFaucet.SetActive(true);
        isRunningFaucetActive = true;
    }

    public void AnomalyCursedPainting()
    {
        if (isCursedPaintingActive) return;

        Debug.Log(RoomName + " Cursed Painting");
        CursedPainting.SetActive(true);
        isCursedPaintingActive = true;
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
        if (anomalyName == nameof(AnomalyRunningFaucet))
        {
            RunningFaucet.SetActive(false);
            isRunningFaucetActive = false;
        }
        if (anomalyName == nameof(AnomalyCursedPainting))
        {
            CursedPainting.SetActive(false);
            isCursedPaintingActive = false;
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
        if (anomalyName == nameof(AnomalyNew))
            return isNewActive;
        if (anomalyName == nameof(AnomalyObjectMovement))
            return isObjectMovementActive;
        if (anomalyName == nameof(AnomalyRunningFaucet))
            return isRunningFaucetActive;
        if (anomalyName == nameof(AnomalyCursedPainting))
            return isCursedPaintingActive;
        if (anomalyName == nameof(AnomalyDemonicPresence))
            return isDemonicPresenceActive;

        return false;
    }
}   