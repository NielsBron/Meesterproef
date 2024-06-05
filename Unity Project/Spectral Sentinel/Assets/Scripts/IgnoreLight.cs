using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLight : MonoBehaviour
{
    [SerializeField] private Light[] disabledLights;

    private void OnPreCull()
    {
        foreach (Light light in disabledLights)
        {
            light.enabled = false;
        }
    }

    private void OnPreRender()
    {
        foreach (Light light in disabledLights)
        {
            light.enabled = false;
        }
    }

    private void OnPostRender()
    {
        foreach (Light light in disabledLights)
        {
            light.enabled = true;
        }
    }
}