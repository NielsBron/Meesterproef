using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursedPainting : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private GameObject OriginalPainting;
    [SerializeField] private GameObject NewPainting;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;
    [SerializeField] private MonoBehaviour RoomScript; // Reference to the room script
    [SerializeField] private string AnomalyName = "AnomalyCursedPainting"; // Name of the anomaly method

    private void OnEnable()
    {
        OriginalPainting.SetActive(false);
        NewPainting.SetActive(true);
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
        OriginalPainting.SetActive(true);
        NewPainting.SetActive(false);
        gameObject.SetActive(false);
    }
}
