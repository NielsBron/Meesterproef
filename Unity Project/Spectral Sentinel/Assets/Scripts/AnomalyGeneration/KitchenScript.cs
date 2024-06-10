using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScript : MonoBehaviour
{
    [SerializeField] private string RoomName = "Kitchen";
    [SerializeField] private GameObject CameraMalfunction;
    [SerializeField] private GameObject New;

    private bool isCameraMalfunctionActive = false;
    private bool isNewActive = false;

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

    public bool IsAnomalyActive(string anomalyName)
    {
        if (anomalyName == nameof(AnomalyCameraMalfunction))
            return isCameraMalfunctionActive;
        if (anomalyName == nameof(AnomalyNew))
            return isNewActive;

        return false;
    }
}   