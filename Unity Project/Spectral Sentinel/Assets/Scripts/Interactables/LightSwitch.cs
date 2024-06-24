using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] private GameObject UseText;
    [SerializeField] private List<GameObject> controlledLightObjects; // GameObject references instead of Light components
    [SerializeField] private Animation switchAnimation;
    [SerializeField] private List<Renderer> lightRenderers;
    [SerializeField] private Material lightOnMaterial;
    [SerializeField] private Material lightOffMaterial;
    [SerializeField] private AudioClip turnOnSound;
    [SerializeField] private AudioClip turnOffSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private FanController fanController;

    public bool isLightOn = true;

    public bool IsLightOn()
    {
        return isLightOn;
    }

    void Start()
    {
        SetInitialLightState();
    }

    public override void OnInteract()
    {
        ToggleLight();
    }

    public override void OnFocus()
    {
        UseText.SetActive(true);
    }

    public override void OnLoseFocus()
    {
        UseText.SetActive(false);
    }

    public void ToggleLight()
    {
        isLightOn = !isLightOn;

        if (isLightOn)
        {
            switchAnimation.Play("TurnOn");
            SetLightsState(true);
            SetRenderersMaterial(lightOnMaterial);
            audioSource.PlayOneShot(turnOnSound);
            if (fanController != null)
            {
                fanController.SetFanState(true);
            }
        }
        else
        {
            switchAnimation.Play("TurnOff");
            SetLightsState(false);
            SetRenderersMaterial(lightOffMaterial);
            audioSource.PlayOneShot(turnOffSound);
            if (fanController != null)
            {
                fanController.SetFanState(false);
            }
        }
    }

    private void SetInitialLightState()
    {
        SetLightsState(isLightOn);
        SetRenderersMaterial(isLightOn ? lightOnMaterial : lightOffMaterial);
        if (fanController != null)
        {
            fanController.SetFanState(isLightOn);
        }
    }

    private void SetLightsState(bool state)
    {
        foreach (GameObject lightObject in controlledLightObjects)
        {
            lightObject.SetActive(state); // Activate or deactivate the entire GameObject
        }
    }

    private void SetRenderersMaterial(Material material)
    {
        foreach (Renderer renderer in lightRenderers)
        {
            renderer.material = material;
        }
    }
}