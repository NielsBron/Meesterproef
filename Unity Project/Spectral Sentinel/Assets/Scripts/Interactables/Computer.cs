using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactable
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
        if (isUsingComputer && Input.GetKeyDown(KeyCode.Escape))
        {
            ExitComputer();
        }
    }

    public override void OnInteract()
    {
        UseText.SetActive(true);
        EnterComputer();
    }

    public override void OnFocus()
    {
        UseText.SetActive(true);
    }

    public override void OnLoseFocus()
    {
        UseText.SetActive(false);
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
