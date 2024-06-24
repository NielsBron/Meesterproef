using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonicPresence : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private GameObject OriginalObject;
    [SerializeField] private GameObject NewObject;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;
    [SerializeField] private MonoBehaviour RoomScript; // Reference to the room script
    [SerializeField] private string AnomalyName = "AnomalyDemonicPresence"; // Name of the anomaly method

    private void OnEnable()
    {
        OriginalObject.SetActive(false);
        NewObject.SetActive(true);
    }

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
        OriginalObject.SetActive(true);
        NewObject.SetActive(false);
        gameObject.SetActive(false);
    }
}

