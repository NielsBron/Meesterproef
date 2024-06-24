using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : Interactable
{
  [SerializeField] public GameObject TakeText;

  public override void OnInteract()
  {
    TakeText.SetActive(true);
    gameObject.SetActive(false);
  }

  public override void OnFocus()
  {
    TakeText.SetActive(true);
  }

  public override void OnLoseFocus()
  {
    TakeText.SetActive(false);
  }

}
