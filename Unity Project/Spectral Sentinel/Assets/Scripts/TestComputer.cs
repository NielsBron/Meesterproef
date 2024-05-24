using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestComputer : Interactable
{
    [SerializeField] public GameObject UseText;
    [SerializeField] public GameObject playerController;
    [SerializeField] public Camera pcCamera;

    private Camera mainCamera;
    private bool isUsingComputer = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (isUsingComputer && Input.GetKeyDown(KeyCode.X))
        {
            ExitComputer();
        }
    }

    public override void OnInteract()
    {
        UseText.SetActive(true);
        EnterComputer();
        print("Interacted with object: " + gameObject.name);
    }

    public override void OnFocus()
    {
        UseText.SetActive(true);
        print("Looking at object: " + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        UseText.SetActive(false);
        print("Stopped Looking at object: " + gameObject.name);
    }

    private void EnterComputer()
    {
        playerController.SetActive(false);

        pcCamera.gameObject.SetActive(true);

        mainCamera.gameObject.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        isUsingComputer = true;
    }

    private void ExitComputer()
    {
        playerController.SetActive(true);

        pcCamera.gameObject.SetActive(false);

        mainCamera.gameObject.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isUsingComputer = false;
    }
}
