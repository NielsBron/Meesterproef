using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningFaucet : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;
    [SerializeField] private MonoBehaviour RoomScript; // Reference to the room script
    [SerializeField] private string AnomalyName = "AnomalyRunningFaucet"; // Name of the anomaly method

    public override void OnInteract()
    {
        FixAnomaly();
    }

    public override void OnFocus()
    {
        FixText.SetActive(true);
    }

    public override void OnLoseFocus()
    {
        FixText.SetActive(false);
    }

    private void FixAnomaly()
    {
        Debug.Log("Anomaly Fixed");
        AnomalyGeneratorScript.FixAnomaly(RoomScript, AnomalyName);
        gameObject.SetActive(false);
    }
}