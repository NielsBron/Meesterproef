using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : Interactable
{
    [SerializeField] public GameObject UseText;
    [SerializeField] public Light controlledLight;
    [SerializeField] public Animation switchAnimation;
    [SerializeField] public Renderer lightRenderer; // Reference to the Renderer of the light object
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
            controlledLight.enabled = true;
            lightRenderer.material = lightOnMaterial;
            audioSource.PlayOneShot(turnOnSound);
        }
        else
        {
            switchAnimation.Play("TurnOff");
            controlledLight.enabled = false;
            lightRenderer.material = lightOffMaterial;
            audioSource.PlayOneShot(turnOffSound);
        }

        print("Interacted with object: " + gameObject.name);
    }

    private void SetInitialLightState()
    {
        if (isLightOn)
        {
            controlledLight.enabled = true;
            lightRenderer.material = lightOnMaterial;
        }
        else
        {
            controlledLight.enabled = false;
            lightRenderer.material = lightOffMaterial;
        }
    }
}
