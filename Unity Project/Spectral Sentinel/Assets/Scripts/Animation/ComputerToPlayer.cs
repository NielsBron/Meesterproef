using System.Collections;
using UnityEngine;

public class ComputerToPlayer : MonoBehaviour
{
    [SerializeField] private Camera computerCamera;
    [SerializeField] private Transform playerCameraPosition;
    [SerializeField] private float animationDuration = 0.5f;

    private Animation animationComponent;

    void OnEnable()
    {
        animationComponent = computerCamera.GetComponent<Animation>();
        StartCoroutine(Transition());
    }

    private IEnumerator Transition()
    {
        if (animationComponent != null)
        {
            animationComponent.Play("ComputerToPlayer");
            yield return new WaitForSeconds(animationDuration);
        }

        Vector3 startPosition = computerCamera.transform.position;
        Quaternion startRotation = computerCamera.transform.rotation;
        Vector3 endPosition = playerCameraPosition.position;
        Quaternion endRotation = playerCameraPosition.rotation;
        float elapsedTime = 0;

        while (elapsedTime < 0.5f)
        {
            computerCamera.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / 0.5f);
            computerCamera.transform.rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / 0.5f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        computerCamera.transform.position = endPosition;
        computerCamera.transform.rotation = endRotation;
    }
}