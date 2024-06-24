using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    [Header("Light Switch Scripts")]
    [SerializeField] private LightSwitch LivingRoomSwitchScript;
    [SerializeField] private LightSwitch OfficeSwitchScript;
    [SerializeField] private LightSwitch BathroomSwitchScript;
    [SerializeField] private LightSwitch KitchenSwitchScript;
    [SerializeField] private LightSwitch HallSwitchScript;
    [SerializeField] private LightSwitch GarageSwitchScript;
    [SerializeField] private LightSwitch EntranceSwitchScript;

    private float timer;
    private float interval = 20f;
    private bool shouldTurnOffLights = true;

    void Start()
    {
        timer = interval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            timer = interval;

            if (Random.value < 0.5f)
            {
                TurnOffRandomLight();
            }
        }

        if (shouldTurnOffLights && Input.GetKeyDown(KeyCode.L))
        {
            TurnOffRandomLight();
        }
    }

    void TurnOffRandomLight()
    {
        List<LightSwitch> onSwitches = new List<LightSwitch>();
        if (LivingRoomSwitchScript.IsLightOn())
            onSwitches.Add(LivingRoomSwitchScript);
        if (OfficeSwitchScript.IsLightOn())
            onSwitches.Add(OfficeSwitchScript);
        if (BathroomSwitchScript.IsLightOn())
            onSwitches.Add(BathroomSwitchScript);
        if (KitchenSwitchScript.IsLightOn())
            onSwitches.Add(KitchenSwitchScript);
        if (HallSwitchScript.IsLightOn())
            onSwitches.Add(HallSwitchScript);
        if (GarageSwitchScript.IsLightOn())
            onSwitches.Add(GarageSwitchScript);
        if (EntranceSwitchScript.IsLightOn())
            onSwitches.Add(EntranceSwitchScript);

        if (onSwitches.Count > 0)
        {
            int randomIndex = Random.Range(0, onSwitches.Count);
            onSwitches[randomIndex].ToggleLight();
        }
    }

    public void TurnOffLightsOccasionally()
    {
        shouldTurnOffLights = true;
    }
}
