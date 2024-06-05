using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStart : MonoBehaviour
{
    [SerializeField] GameObject CameraLights;
    
    void Awake()
    {
       CameraLights.SetActive(true); 
    }
}
