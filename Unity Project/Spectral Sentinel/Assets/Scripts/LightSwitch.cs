using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] public GameObject UseText;
    [SerializeField] public List<Light> controlledLights; // List of lights to control
    [SerializeField] public Animation switchAnimation;
    [SerializeField] public List<Renderer> lightRenderers; // List of renderers to update
    [SerializeField] public Material lightOnMaterial;
    [SerializeField] public Material lightOffMaterial;
    [SerializeField] public AudioClip turnOnSound;
    [SerializeField] public AudioClip turnOffSound;
    [SerializeField] public AudioSource audioSource;

    private bool isLightOn = true;

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
        print("Looking at object: " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        UseText.SetActive(false);
        print("Stopped Looking at object: " + gameObject.name);
    }

    private void ToggleLight()
    {
        isLightOn = !isLightOn;

        if (isLightOn)
        {
            switchAnimation.Play("TurnOn");
            SetLightsState(true);
            SetRenderersMaterial(lightOnMaterial);
            audioSource.PlayOneShot(turnOnSound);
        }
        else
        {
            switchAnimation.Play("TurnOff");
            SetLightsState(false);
            SetRenderersMaterial(lightOffMaterial);
            audioSource.PlayOneShot(turnOffSound);
        }

        print("Interacted with object: " + gameObject.name);
    }

    private void SetInitialLightState()
    {
        SetLightsState(isLightOn);
        SetRenderersMaterial(isLightOn ? lightOnMaterial : lightOffMaterial);
    }

    private void SetLightsState(bool state)
    {
        foreach (Light light in controlledLights)
        {
            light.enabled = state;
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
