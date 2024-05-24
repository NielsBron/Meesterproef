using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Start()
    {
        if (cameras.Length > 0)
        {
            cameras[0].gameObject.SetActive(true);
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
    }
}
