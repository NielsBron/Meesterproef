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

  

  // private bool isOn = false;

  // private GameObject playerObj = null;
    
  // void Start()
  // {
  //     // Find the player object with the "Player" tag
  //     playerObj = GameObject.FindGameObjectWithTag("Player");
  //     TurnOn();
  // }

  // void Update()
  // {
  //     RedLight = RedObject.transform.GetChild(0).gameObject;
  //     GreenLight = GreenObject.transform.GetChild(0).gameObject;
  //     YellowLight = YellowObject.transform.GetChild(0).gameObject;
  //     BlueLight = BlueObject.transform.GetChild(0).gameObject;
  //     PurpleLight = PurpleObject.transform.GetChild(0).gameObject;
  //     if (playerObj != null && isOn == true)
  //     {
  //       float distance = Vector3.Distance (transform.position, playerObj.transform.position);
  //       if (playerObj.transform.position.x <= 1)
  //       {
  //           Debug.Log("Attack!");
  //       }
  //       else
  //       {
  //           Debug.Log("Good!");
  //       }      
  //     }
  // }

  // public void TurnOn()
  // {
  //   isOn = true;
  //   DisableAll();
  //   RedObject.GetComponent<MeshRenderer> ().material = RedMat;
  //   RedLight.SetActive(true);
  // }

  // public void Green()
  // {
  //   DisableAll();
  //   GreenObject.GetComponent<MeshRenderer> ().material = GreenMat;
  //   GreenLight.SetActive(true);
  // }

  // public void Yellow()
  // {
  //   DisableAll();
  //   YellowObject.GetComponent<MeshRenderer> ().material = YellowMat;
  //   YellowLight.SetActive(true);
  // }

  // public void Blue()
  // {
  //   DisableAll();
  //   BlueObject.GetComponent<MeshRenderer> ().material = BlueMat;
  //   BlueLight.SetActive(true);
  // }

  // public void Purple()
  // {
  //   DisableAll();
  //   PurpleObject.GetComponent<MeshRenderer> ().material = PurpleMat;
  //   PurpleLight.SetActive(true);
  // }

  // public void TurnOff()
  // {
  //   isOn = false;
  //   DisableAll();
  // }

  // public void DisableAll()
  // {
  //   RedObject.GetComponent<MeshRenderer> ().material = WhiteMat;
  //   GreenObject.GetComponent<MeshRenderer> ().material = WhiteMat;
  //   YellowObject.GetComponent<MeshRenderer> ().material = WhiteMat;
  //   BlueObject.GetComponent<MeshRenderer> ().material = WhiteMat;
  //   PurpleObject.GetComponent<MeshRenderer> ().material = WhiteMat;

  //   RedLight.SetActive(false);
  //   GreenLight.SetActive(false);
  //   YellowLight.SetActive(false);
  //   BlueLight.SetActive(false);
  //   PurpleLight.SetActive(false);
  // }
}
