using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private GameObject OriginalObject;
    [SerializeField] private GameObject NewObject;
    
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript; // Reference to AnomalyGenerator
    [SerializeField] private MonoBehaviour RoomScript; // Reference to the room script
    [SerializeField] private string AnomalyName = "AnomalyObjectMovement"; // Name of the anomaly method

    [SerializeField] private Animation animationComponent; // Reference to the Animation component
    [SerializeField] private string animationClipName; // Name of the animation clip

    private void OnEnable()
    {
        OriginalObject.SetActive(false);
        NewObject.SetActive(true);
        animationComponent.Play(animationClipName);
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