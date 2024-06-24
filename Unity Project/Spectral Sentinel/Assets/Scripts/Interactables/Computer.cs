using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Interactable
{
    [SerializeField] private GameObject UseText;
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private GameObject playerController;
    [SerializeField] private GameObject PcToPlayerScript;
    [SerializeField] private GameObject PlayerToPcScript;
    [SerializeField] private Camera pcCamera;

    private Camera mainCamera;
    private bool isUsingComputer = false;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public override void OnInteract()
    {
        PcToPlayerScript.SetActive(true);
        UseText.SetActive(false);
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
        PauseMenu.SetActive(false);
        playerController.SetActive(false);
        pcCamera.gameObject.SetActive(true);
        mainCamera.gameObject.SetActive(false);
        StartCoroutine(PlayerToPc());
    }

    IEnumerator PlayerToPc()
    {
        yield return new WaitForSeconds(1.0f);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isUsingComputer = true;
    }

    public void ExitComputer()
    {
        StartCoroutine(PcToPlayer());
    }
    
    IEnumerator PcToPlayer()
    {
        PlayerToPcScript.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitForSeconds(1.0f);
        isUsingComputer = false;
        PauseMenu.SetActive(true);
        PlayerToPcScript.SetActive(false);
        playerController.SetActive(true);
        pcCamera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
    }
        
}
