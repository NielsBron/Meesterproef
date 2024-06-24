using System.Collections;
using UnityEngine;

public class FanController : MonoBehaviour
{
    [SerializeField] private float maxRotationSpeed = 360f;
    [SerializeField] private float accelerationTime = 2f;
    [SerializeField] private float decelerationTime = 3f;

    private float currentSpeed = 0f;
    private bool isFanOn = false;

    private Coroutine fanCoroutine;

    public void SetFanState(bool state)
    {
        if (state == isFanOn) return;

        isFanOn = state;

        if (fanCoroutine != null)
        {
            StopCoroutine(fanCoroutine);
        }

        fanCoroutine = StartCoroutine(isFanOn ? AccelerateFan() : DecelerateFan());
    }

    private IEnumerator AccelerateFan()
    {
        float elapsed = 0f;
        float startSpeed = currentSpeed;

        while (elapsed < accelerationTime)
        {
            elapsed += Time.deltaTime;
            currentSpeed = Mathf.Lerp(startSpeed, maxRotationSpeed, elapsed / accelerationTime);
            yield return null;
        }

        currentSpeed = maxRotationSpeed;
    }

    private IEnumerator DecelerateFan()
    {
        float elapsed = 0f;
        float startSpeed = currentSpeed;

        while (elapsed < decelerationTime)
        {
            elapsed += Time.deltaTime;
            currentSpeed = Mathf.Lerp(startSpeed, 0f, elapsed / decelerationTime);
            yield return null;
        }

        currentSpeed = 0f;
    }

    void Update()
    {
        if (currentSpeed > 0f || isFanOn)
        {
            transform.Rotate(0, 0, currentSpeed * Time.deltaTime);
        }
    }
}