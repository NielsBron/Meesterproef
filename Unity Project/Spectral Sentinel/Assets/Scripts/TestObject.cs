using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : Interactable
{
  [SerializeField] public GameObject TakeText;

  public override void OnInteract()
  {
    TakeText.SetActive(true);
    print("Interacted with object: " + gameObject.name);
    gameObject.SetActive(false);
  }

  public override void OnFocus()
  {
    TakeText.SetActive(true);
    print("Looking at object: " + gameObject.name);
  }

  public override void OnLoseFocus()
  {
    TakeText.SetActive(false);
    print("Stopped Looking at object: " + gameObject.name);
  }

}
