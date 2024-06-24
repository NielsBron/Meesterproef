using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSwitch : Interactable
{
    [SerializeField] private GameObject FixText;
    [SerializeField] private GameObject SwitchHandle;
    [SerializeField] private AnomalyGenerator AnomalyGeneratorScript;
    [SerializeField] private MonoBehaviour RoomScript; // Reference to the room script
    [SerializeField] private string AnomalyName = "AnomalyMainSwitch"; // Name of the anomaly method

    [Header("Light Switch Scripts")]
    [SerializeField] private LightSwitch LivingRoomSwitchScript;
    [SerializeField] private LightSwitch OfficeSwitchScript;
    [SerializeField] private LightSwitch BathroomSwitchScript;
    [SerializeField] private LightSwitch KitchenSwitchScript;
    [SerializeField] private LightSwitch HallSwitchScript;
    [SerializeField] private LightSwitch GarageSwitchScript;
    [SerializeField] private LightSwitch EntranceSwitchScript;

    private void OnEnable()
    {
        SwitchHandle.GetComponent<Animation>().Play("SwitchDown");
        TurnOffLightsIfOn(LivingRoomSwitchScript);
        TurnOffLightsIfOn(OfficeSwitchScript);
        TurnOffLightsIfOn(BathroomSwitchScript);
        TurnOffLightsIfOn(KitchenSwitchScript);
        TurnOffLightsIfOn(HallSwitchScript);
        TurnOffLightsIfOn(GarageSwitchScript);
        TurnOffLightsIfOn(EntranceSwitchScript);
    }

    private void TurnOffLightsIfOn(LightSwitch lightSwitch)
    {
        if (lightSwitch.IsLightOn())
        {
            lightSwitch.ToggleLight();
        }
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
        SwitchHandle.GetComponent<Animation>().Play("SwitchUp");
    }
}
