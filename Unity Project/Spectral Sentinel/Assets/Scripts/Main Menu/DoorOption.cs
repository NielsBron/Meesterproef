using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DoorOption : MonoBehaviour
{
    private Renderer renderer;
    private Color originalColor;
    [SerializeField] public GameObject Light;
    

    void Start()
    {
        renderer = GetComponent<Renderer>();
        originalColor = renderer.material.color;
    }

    void OnMouseEnter()
    {
        Light.SetActive(true);
    }

    void OnMouseExit()
    {
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
        SceneManager.LoadScene(1);
    }
}
