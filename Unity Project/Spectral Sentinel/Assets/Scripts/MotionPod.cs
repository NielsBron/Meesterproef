using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionPod : MonoBehaviour
{
    [Header("Materials")]
    [SerializeField] public Material RedMat;
    [SerializeField] public Material GreenMat;
    [SerializeField] public Material YellowMat;
    [SerializeField] public Material BlueMat;
    [SerializeField] public Material PurpleMat;
    [SerializeField] public Material WhiteMat;

    [Header("Lights")]
    [SerializeField] public GameObject RedObject;
    [SerializeField] public GameObject GreenObject;
    [SerializeField] public GameObject YellowObject;
    [SerializeField] public GameObject BlueObject;
    [SerializeField] public GameObject PurpleObject;

    [Header("Distance parameters")]
    [SerializeField] public float GreenDistance = default;
    [SerializeField] public float YellowDistance = default;
    [SerializeField] public float BlueDistance = default;
    [SerializeField] public float PurpleDistance = default;

    [Header("Audio Clip")]
    [SerializeField] public AudioClip clip;
    [Header("Pitch Settings")]
    [SerializeField] public float pitchGreen = 1.0f;
    [SerializeField] public float pitchYellow = 1.1f;
    [SerializeField] public float pitchBlue = 1.2f;
    [SerializeField] public float pitchPurple = 1.3f;

    private GameObject RedLight;
    private GameObject GreenLight;
    private GameObject YellowLight;
    private GameObject BlueLight;
    private GameObject PurpleLight;
    
    private bool isOn = false;
    private GameObject playerObj = null;

    private AudioSource audioSource;

    void Start()
    {
        RedLight = RedObject.transform.GetChild(0).gameObject;
        GreenLight = GreenObject.transform.GetChild(0).gameObject;
        YellowLight = YellowObject.transform.GetChild(0).gameObject;
        BlueLight = BlueObject.transform.GetChild(0).gameObject;
        PurpleLight = PurpleObject.transform.GetChild(0).gameObject;

        playerObj = GameObject.FindGameObjectWithTag("Player");
        audioSource = GetComponent<AudioSource>();

        TurnOn();
    }

    void Update()
    {
        if (playerObj != null && isOn == true)
        {
            float distance = Vector3.Distance(transform.position, playerObj.transform.position);
            // Debug.Log("Distance to player: " + distance);

            if (distance <= PurpleDistance)
            {
                Purple();
            }
            else if (distance <= BlueDistance)
            {
                Blue();
            }
            else if (distance <= YellowDistance)
            {
                Yellow();
            }
            else if (distance <= GreenDistance)
            {
                Green();
            }
            else
            {
                TurnOn();
            }
        }
    }

    public void TurnOn()
    {
        isOn = true;
        DisableAll();
        RedObject.GetComponent<MeshRenderer>().material = RedMat;
        RedLight.SetActive(true);
        audioSource.Stop();
    }

    public void Green()
    {
        DisableAll();
        GreenObject.GetComponent<MeshRenderer>().material = GreenMat;
        GreenLight.SetActive(true);
        audioSource.clip = clip;
        audioSource.pitch = pitchGreen;
        audioSource.Play();
    }

    public void Yellow()
    {
        DisableAll();
        YellowObject.GetComponent<MeshRenderer>().material = YellowMat;
        YellowLight.SetActive(true);
        audioSource.clip = clip;
        audioSource.pitch = pitchYellow;
        audioSource.Play();
    }

    public void Blue()
    {
        DisableAll();
        BlueObject.GetComponent<MeshRenderer>().material = BlueMat;
        BlueLight.SetActive(true);
        audioSource.clip = clip;
        audioSource.pitch = pitchBlue;
        audioSource.Play();
    }

    public void Purple()
    {
        DisableAll();
        PurpleObject.GetComponent<MeshRenderer>().material = PurpleMat;
        PurpleLight.SetActive(true);
        audioSource.clip = clip;
        audioSource.pitch = pitchPurple;
        audioSource.Play();
    }

    public void TurnOff()
    {
        isOn = false;
        DisableAll();
        audioSource.Stop();
    }

    public void DisableAll()
    {
        RedObject.GetComponent<MeshRenderer>().material = WhiteMat;
        GreenObject.GetComponent<MeshRenderer>().material = WhiteMat;
        YellowObject.GetComponent<MeshRenderer>().material = WhiteMat;
        BlueObject.GetComponent<MeshRenderer>().material = WhiteMat;
        PurpleObject.GetComponent<MeshRenderer>().material = WhiteMat;

        RedLight.SetActive(false);
        GreenLight.SetActive(false);
        YellowLight.SetActive(false);
        BlueLight.SetActive(false);
        PurpleLight.SetActive(false);
    }
}
