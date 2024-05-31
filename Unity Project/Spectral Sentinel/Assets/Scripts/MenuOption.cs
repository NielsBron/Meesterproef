using UnityEngine;
using System.Collections;

public class MenuOption : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    [SerializeField] public GameObject Light;
    [SerializeField] public GameObject PlayerCamera;
    [SerializeField] public GameObject Wall;
    [SerializeField] public GameObject Door;
    [SerializeField] public GameObject Logo;
    [SerializeField] public GameObject Back;
    

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    void OnMouseEnter()
    {
        renderer.material.color = Color.red;
    }

    void OnMouseExit()
    {
        renderer.material.color = originalColor;
    }

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Play":
                PlayGame();
                break;
            case "Settings":
                OpenSettings();
                break;
            case "Quit":
                QuitGame();
                break;
            case "Back":
                BackButton();
                break;
        }
    }

    public void PlayGame()
    {
        StartCoroutine(ChooseDoor());
    }

    IEnumerator ChooseDoor()
    {
        Debug.Log("Play Clicked");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCamera.GetComponent<Animation>().Play("MenuToDoor");
        Light.SetActive(false);
        Wall.SetActive(false);
        Logo.SetActive(false);
        Door.SetActive(true);
        Back.GetComponent<Collider>().enabled = true;
        Back.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(1);
        Light.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void BackButton()
    {
        StartCoroutine(BackToMenu());
    }

    IEnumerator BackToMenu()
    {
        Debug.Log("Back Clicked");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerCamera.GetComponent<Animation>().Play("DoorToMenu");
        Light.SetActive(false);
        Wall.SetActive(true);
        Logo.SetActive(true);
        Door.SetActive(false);
        Back.GetComponent<Collider>().enabled = false;
        Back.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        Light.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OpenSettings()
    {
        Debug.Log("Settings Clicked");
    }

    void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
