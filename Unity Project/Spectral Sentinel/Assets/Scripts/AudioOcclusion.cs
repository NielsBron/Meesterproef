using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(AudioLowPassFilter))]
public class AudioOcclusion : MonoBehaviour
{
    public Transform listener;
    public LayerMask occlusionLayer;
    public float maxDistance = 10f;
    public float occlusionAmount = 0.5f;
    public float transitionSpeed = 5f;
    public float maxCutoffFrequency = 22000f;
    public float minCutoffFrequency = 500f;

    private AudioSource audioSource;
    private AudioLowPassFilter lowPassFilter;
    private float originalVolume;
    private float targetVolume;
    private float targetCutoffFrequency;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from this GameObject.");
        }

        if (lowPassFilter == null)
        {
            Debug.LogError("AudioLowPassFilter component missing from this GameObject.");
        }

        originalVolume = audioSource.volume;
        targetVolume = originalVolume;
        targetCutoffFrequency = maxCutoffFrequency;

        StartCoroutine(UpdateAudioProperties());
    }

    void Update()
    {
        if (audioSource == null || listener == null) return;

        // Calculate direction and distance to the listener
        Vector3 directionToListener = listener.position - transform.position;
        float distanceToListener = directionToListener.magnitude;

        // Check if the listener is within max distance
        if (distanceToListener <= maxDistance)
        {
            // Perform a raycast to check for occlusion
            if (Physics.Raycast(transform.position, directionToListener, distanceToListener, occlusionLayer))
            {
                // If the ray hits something, reduce the volume and cutoff frequency, draw a red ray
                targetVolume = originalVolume * (1f - occlusionAmount);
                targetCutoffFrequency = minCutoffFrequency;
                Debug.DrawRay(transform.position, directionToListener, Color.red);
            }
            else
            {
                // If the ray doesn't hit anything, restore the original volume and cutoff frequency, draw a green ray
                targetVolume = originalVolume;
                targetCutoffFrequency = maxCutoffFrequency;
                Debug.DrawRay(transform.position, directionToListener, Color.green);
            }
        }
        else
        {
            // If the listener is out of range, reduce the volume and cutoff frequency
            targetVolume = originalVolume * (1f - occlusionAmount);
            targetCutoffFrequency = minCutoffFrequency;
        }
    }

    private IEnumerator UpdateAudioProperties()
    {
        while (true)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, targetVolume, Time.deltaTime * transitionSpeed);
            lowPassFilter.cutoffFrequency = Mathf.Lerp(lowPassFilter.cutoffFrequency, targetCutoffFrequency, Time.deltaTime * transitionSpeed);
            yield return null;
        }
    }
}
