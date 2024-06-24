using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    [SerializeField] GameObject CameraLights;
    [SerializeField] GameObject FadeBackground;
    
    void Awake()
    {
       CameraLights.SetActive(true);
       FadeBackground.SetActive(true);
       FadeBackground.GetComponent<Animation>().Play("FadeIn");
    }
}
