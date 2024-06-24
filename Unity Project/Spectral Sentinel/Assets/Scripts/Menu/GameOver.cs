using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    [SerializeField] private MonoBehaviour PlayerScript;
    [SerializeField] private GameObject GameOverScreen;
    
    public void GameOverFunction()
    {
        PauseMenu.SetActive(false);
        PlayerScript.enabled = false;
        GameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
