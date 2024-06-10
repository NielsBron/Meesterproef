using UnityEngine;
using System.Collections;

public class LightBuzzer : MonoBehaviour
{
    private Light pointLight;
    [SerializeField] private GameObject lightGameObject;
    [SerializeField] private float minIntensity = 0.5f;
    [SerializeField] private float maxIntensity = 1.5f;
    [SerializeField] private float minRange = 10f;
    [SerializeField] private float maxRange = 15f;
    [SerializeField] private float flickerSpeed = 0.1f;

    void Start()
    {
        if (lightGameObject == null)
        {
            Debug.LogError("No GameObject assigned.");
            return;
        }

        pointLight = lightGameObject.GetComponent<Light>();

        if (pointLight == null)
        {
            Debug.LogError("No Light component found on the assigned GameObject.");
            return;
        }

        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            pointLight.intensity = Random.Range(minIntensity, maxIntensity);
            pointLight.range = Random.Range(minRange, maxRange);
            yield return new WaitForSeconds(flickerSpeed);
        }
    }
}
