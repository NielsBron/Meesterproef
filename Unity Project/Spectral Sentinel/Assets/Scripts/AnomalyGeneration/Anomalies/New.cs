using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;

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
        AnomalyGeneratorScript.DecrementAnomalyCounter();
        gameObject.SetActive(false);
    }
}