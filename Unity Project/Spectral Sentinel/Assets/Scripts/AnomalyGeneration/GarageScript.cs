using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageScript : MonoBehaviour
{
    [SerializeField] private string RoomName = "Garage";
    [SerializeField] private GameObject CameraMalfunction;
    [SerializeField] private GameObject New;
    [SerializeField] private GameObject CarLights;

    private bool isCameraMalfunctionActive = false;
    private bool isNewActive = false;
    private bool isCarLightsActive = false;

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

    public void AnomalyCarLights()
    {
        if (isCarLightsActive) return;

        Debug.Log(RoomName + " Car Lights");
        CarLights.SetActive(true);
        isCarLightsActive = true;
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
        if (anomalyName == nameof(AnomalyCarLights))
        {
            CarLights.SetActive(false);
            isCarLightsActive = false;
        }
    }

    public bool IsAnomalyActive(string anomalyName)
    {
        if (anomalyName == nameof(AnomalyCameraMalfunction))
            return isCameraMalfunctionActive;
        if (anomalyName == nameof(AnomalyNew))
            return isNewActive;
        if (anomalyName == nameof(AnomalyCarLights))
            return isCarLightsActive;

        return false;
    }
}   