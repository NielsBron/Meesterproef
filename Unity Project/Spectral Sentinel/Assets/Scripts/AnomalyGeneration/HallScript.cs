using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallScript : MonoBehaviour
{
    [Header("Room")]
    [SerializeField] private string RoomName = "Hall";

    [Header("Anomalies")]
    [SerializeField] private GameObject CameraMalfunction;
    [SerializeField] private GameObject New;
    [SerializeField] private GameObject ObjectMovement;
    [SerializeField] private GameObject CursedPainting;

    [Header("Anomalies Fixed Counter")]
    [SerializeField] private AnomaliesFixed anomaliesFixed;

    private bool isCameraMalfunctionActive = false;
    private bool isNewActive = false;
    private bool isObjectMovementActive = false;
    private bool isCursedPaintingActive = false;

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

    public void AnomalyCursedPainting()
    {
        if (isCursedPaintingActive) return;

        Debug.Log(RoomName + " Cursed Painting");
        CursedPainting.SetActive(true);
        isCursedPaintingActive = true;
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
        if (anomalyName == nameof(AnomalyCursedPainting))
        {
            CursedPainting.SetActive(false);
            isCursedPaintingActive = false;
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
        if (anomalyName == nameof(AnomalyCursedPainting))
            return isCursedPaintingActive;

        return false;
    }
}   