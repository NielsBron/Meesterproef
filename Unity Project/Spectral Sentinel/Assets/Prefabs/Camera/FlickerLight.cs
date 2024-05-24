using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Material lightOnMaterial;
    public Material lightOffMaterial;
    public float flickerInterval = 0.5f;

    private Renderer cameraRenderer;
    private bool isLightOn = false;

    void Start()
    {
        cameraRenderer = GetComponent<Renderer>();
        if (cameraRenderer == null)
        {
            Debug.LogError("Renderer not found on the object.");
            enabled = false;
        }

        InvokeRepeating("Flicker", flickerInterval, flickerInterval);
    }

    void Flicker()
    {
        isLightOn = !isLightOn;

        cameraRenderer.material = isLightOn ? lightOnMaterial : lightOffMaterial;
    }
}