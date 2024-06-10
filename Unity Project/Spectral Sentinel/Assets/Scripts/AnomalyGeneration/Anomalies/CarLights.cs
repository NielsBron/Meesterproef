using UnityEngine;

public class CarLights : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;
    [SerializeField] private MonoBehaviour RoomScript;
    [SerializeField] private string AnomalyName = "AnomalyCarLights";
    [SerializeField] private GameObject Lights;
    [SerializeField] private float flickerInterval = 0.5f;

    private bool isLightsOn = true;
    private bool isFlickering = false;

    private void OnEnable()
    {
        StartFlickering();
    }

    private void OnDisable()
    {
        StopFlickering();
    }

    private void StartFlickering()
    {
        isFlickering = true;
        InvokeRepeating("ToggleLights", 0f, flickerInterval);
    }

    private void StopFlickering()
    {
        isFlickering = false;
        CancelInvoke("ToggleLights");
    }

    private void ToggleLights()
    {
        isLightsOn = !isLightsOn;
        Lights.SetActive(isLightsOn);
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
        StopFlickering();
        Lights.SetActive(false);
        AnomalyGeneratorScript.FixAnomaly(RoomScript, AnomalyName);
        gameObject.SetActive(false);
    }
}