using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorOption : MonoBehaviour
{
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject Door;
    private ASyncLoader asyncLoader;
    
    private Renderer renderer;
    private Color originalColor;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
        GameObject loaderObject = GameObject.Find("ASyncManager");
        if (loaderObject != null)
        {
            asyncLoader = loaderObject.GetComponent<ASyncLoader>();
        }
        else
        {
            Debug.LogError("SceneLoader GameObject not found in the scene.");
        }
    }

    void OnMouseEnter()
    {
        Door.GetComponent<Animation>().Play("DoorOpen01");
        Light.SetActive(true);
    }

    void OnMouseExit()
    {
        Door.GetComponent<Animation>().Play("DoorClose01");
        Light.SetActive(false);
    }

    void OnMouseDown()
    {
        switch (gameObject.name)
        {
            case "Door_1":
                Door1();
                break;
            case "Door_2":
                Door1();
                break;
            case "Door_3":
                Door1();
                break;
        }
    }

    public void Door1()
    {
        Debug.Log("Clicked door 1");
        if (asyncLoader != null)
        {
            asyncLoader.LoadLevel("Scene_01");
        }
        else
        {
            Debug.LogError("ASyncLoader component not found on SceneLoader GameObject.");
        }
    }
}
