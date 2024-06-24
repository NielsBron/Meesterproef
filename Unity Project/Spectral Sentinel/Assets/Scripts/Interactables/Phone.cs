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

    public override void OnInteract()
    {
        gameObject.SetActive(false);
        RingingSound.SetActive(false);
        PickUpText.SetActive(false);
        PickUpSound.SetActive(true);
        PhoneObject.SetActive(false);
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
