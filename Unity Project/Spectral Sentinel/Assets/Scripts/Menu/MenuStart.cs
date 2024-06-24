using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStart : MonoBehaviour
{
    [SerializeField] GameObject FadeBackground;
    
    void Start()
    {
        FadeBackground.SetActive(true);
        FadeBackground.GetComponent<Animation>().Play("FadeIn");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}