using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class EmergencyBroadcast : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;
    [SerializeField] private MonoBehaviour RoomScript; // Reference to the room script
    [SerializeField] private string AnomalyName = "AnomalyEmergencyBroadcast"; // Name of the anomaly method
    [SerializeField] private LightSwitch LivingRoomSwitchScript;
    [SerializeField] private GameObject VideoScreen;
    [SerializeField] private GameObject VideoLight;

    private void OnEnable()
    {
        TurnOffLightsIfOn(LivingRoomSwitchScript);
        VideoLight.SetActive(true);
        PlayEmergencyBroadcast();
    }

    private void TurnOffLightsIfOn(LightSwitch lightSwitch)
    {
        if (lightSwitch.IsLightOn())
        {
            lightSwitch.ToggleLight();
        }
    }

    private void PlayEmergencyBroadcast()
    {
        VideoScreen.GetComponent<VideoPlayer>().Play();
        VideoScreen.GetComponent<MeshRenderer>().enabled = true;
        VideoScreen.GetComponent<AudioSource>().enabled = true;
        VideoScreen.GetComponent<AudioLowPassFilter>().enabled = true;
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
        gameObject.SetActive(false);
        VideoScreen.GetComponent<VideoPlayer>().Stop();
        VideoScreen.GetComponent<MeshRenderer>().enabled = false;
        VideoLight.SetActive(false);
    }
}