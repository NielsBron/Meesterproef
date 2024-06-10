using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TestTV : Interactable
{
    [SerializeField] private GameObject TurnOnText;
    [SerializeField] private GameObject TurnOffText;
    [SerializeField] private GameObject VideoScreen;
    [SerializeField] private GameObject VideoLight;
    private bool isOn = false;
    private AudioSource audioSource;
    private AudioLowPassFilter lowPassFilter;
    private MeshRenderer meshRenderer;
    private VideoPlayer videoPlayer;

    void Start()
    {
        audioSource = VideoScreen.GetComponent<AudioSource>();
        lowPassFilter = VideoScreen.GetComponent<AudioLowPassFilter>();
        meshRenderer = VideoScreen.GetComponent<MeshRenderer>();
        videoPlayer = VideoScreen.GetComponent<VideoPlayer>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component missing from VideoScreen.");
        }

        if (lowPassFilter == null)
        {
            Debug.LogError("AudioLowPassFilter component missing from VideoScreen.");
        }

        if (meshRenderer == null)
        {
            Debug.LogError("MeshRenderer component missing from VideoScreen.");
        }

        if (videoPlayer == null)
        {
            Debug.LogError("VideoPlayer component missing from VideoScreen.");
        }
    }

    public override void OnInteract()
    {
        if (!isOn)
        {
            meshRenderer.enabled = true;
            if (audioSource != null) audioSource.enabled = true;
            if (lowPassFilter != null) lowPassFilter.enabled = true;
            if (videoPlayer != null) videoPlayer.enabled = true;
            VideoLight.SetActive(true);
            isOn = true;
            OnLoseFocus();
        }
        else 
        {
            meshRenderer.enabled = false;
            if (audioSource != null) audioSource.enabled = false;
            if (lowPassFilter != null) lowPassFilter.enabled = false;
            if (videoPlayer != null) videoPlayer.enabled = false;
            VideoLight.SetActive(false);
            isOn = false;
            OnLoseFocus();
        }
    }

    public override void OnFocus()
    {
        if (!isOn)
        {
            TurnOnText.SetActive(true);
            //print("Turn on " + gameObject.name + "?");
        }
        else
        {
            TurnOffText.SetActive(true);
            //print("Turn off " + gameObject.name + "?");
        }
    }

    public override void OnLoseFocus()
    {
        TurnOnText.SetActive(false);
        TurnOffText.SetActive(false);
    }
}
