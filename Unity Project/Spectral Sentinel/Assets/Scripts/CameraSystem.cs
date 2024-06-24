using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    [SerializeField] private Text cameraNameText;
    private int currentCameraIndex = 0;

    private void Start()
    {
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
            UpdateCameraNameText();
        }
    }

    public void SwitchToNextCamera()
    {
        int nextIndex = (currentCameraIndex + 1) % cameras.Length;
        SwitchCamera(nextIndex);
    }

    public void SwitchToPreviousCamera()
    {
        int previousIndex = (currentCameraIndex - 1 + cameras.Length) % cameras.Length;
        SwitchCamera(previousIndex);
    }

    private void SwitchCamera(int newIndex)
    {
        cameras[currentCameraIndex].gameObject.SetActive(false);
        cameras[newIndex].gameObject.SetActive(true);
        currentCameraIndex = newIndex;
        UpdateCameraNameText();
    }

    private void UpdateCameraNameText()
    {
        if (cameraNameText != null && cameras.Length > 0)
        {
            cameraNameText.text = cameras[currentCameraIndex].gameObject.name;
        }
    }
}