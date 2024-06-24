using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerToComputer : MonoBehaviour
{
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Camera ComputerCamera;
    [SerializeField] private Transform ComputerCameraPosition;
    [SerializeField] private float transitionDuration = 0.5f;
    [SerializeField] private string animationName = "AnimationName";

    private Animation animationComponent;

    void OnEnable()
    {
        ComputerCamera.transform.position = PlayerCamera.transform.position;
        ComputerCamera.transform.rotation = PlayerCamera.transform.rotation;
        animationComponent = GetComponent<Animation>();
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        Vector3 startPosition = ComputerCamera.transform.position;
        Quaternion startRotation = ComputerCamera.transform.rotation;
        Vector3 endPosition = ComputerCameraPosition.position;
        Quaternion endRotation = ComputerCameraPosition.rotation;
        float elapsedTime = 0;

        while (elapsedTime < transitionDuration)
        {
            ComputerCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / transitionDuration);
            ComputerCamera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / transitionDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        ComputerCamera.transform.position = endPosition;
        ComputerCamera.transform.rotation = endRotation;
        PlayAnimation();
    }

    private void PlayAnimation()
    {
        if (animationComponent != null)
        {
            animationComponent.Play(animationName);
        }
    }
} 