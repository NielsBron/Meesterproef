using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Phone : Interactable
{
    [SerializeField] private GameObject PickUpText;
    [SerializeField] private GameObject RingingSound;
    [SerializeField] private GameObject PickUpSound;
    [SerializeField] private GameObject PhoneObject;
    [SerializeField] private GameObject PutDownSound;
    [SerializeField] private GameObject Call;
    [SerializeField] private GameObject AnomalyGenerator;

    public override void OnInteract()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 100, transform.position.z);
        RingingSound.SetActive(false);
        PickUpText.SetActive(false);
        PickUpSound.SetActive(true);
        PhoneObject.SetActive(false);
        StartCoroutine(Caller());
    }

    IEnumerator Caller()
    {
        yield return new WaitForSeconds(1.0f);
        Call.SetActive(true);
        yield return new WaitForSeconds(26.5f);
        AnomalyGenerator.SetActive(true);
        PhoneObject.SetActive(true);
        PutDownSound.SetActive(true);
    }

    public override void OnFocus()
    {
        PickUpText.SetActive(true);
    }

    public override void OnLoseFocus()
    {
        PickUpText.SetActive(false);
    }
}
