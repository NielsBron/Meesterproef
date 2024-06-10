using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject GameOverScreen;
    
    public void GameOverFunction()
    {
        Player.SetActive(false);
        GameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
