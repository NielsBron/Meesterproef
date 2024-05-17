using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
  public bool canMove { get; private set;} = true;
  private bool IsSprinting => canSprint && Input.GetKey(sprintKey);

  [Header("Functional Options")]
  [SerializeField] private bool canSprint = true;
  [SerializeField] private bool canUseHeadBob = true;

  [Header("Controls")]
  [SerializeField] private KeyCode sprintKey = KeyCode.LeftShift;

  [Header("Movement Parameters")]
  [SerializeField] private float walkSpeed = 3.0f;
  [SerializeField] private float sprintSpeed = 6.0f;
  [SerializeField] private float gravity = 30.0f;

  [Header("Look Parameters")]
  [SerializeField, Range(1, 10)] private float lookSpeedX = 2.0f;
  [SerializeField, Range(1, 10)] private float lookSpeedY = 2.0f;
  [SerializeField, Range(1, 100)] private float upperLookLimit = 90.0f;
  [SerializeField, Range(1, 100)] private float lowerLookLimit = 90.0f;

  [Header("Headbob Parameters")]
  [SerializeField] private float walkBobSpeed = 14f;
  [SerializeField] private float walkBobAmount = 0.05f;
  [SerializeField] private float sprintBobSpeed = 18f;
  [SerializeField] private float sprintBobAmount = 0.1f;
  private float defaultYPos = 0;
  private float timer;

  private Camera playerCamera;
  private CharacterController characterController;

  private Vector3 moveDirection;
  private Vector2 currentInput;

  private float rotationX = 0;

  void Awake()
  {
    playerCamera = GetComponentInChildren<Camera>();
    characterController = GetComponent<CharacterController>();
    defaultYPos = playerCamera.transform.localPosition.y;
    Cursor.lockState = CursorLockMode.Locked;
    Cursor.visible = false;
  }

  void Update()
  {
    if (canMove)
    {
      HandleMovementInput();
      HandleMouseLook();

      if (canUseHeadBob)
        HandleHeadBob();

      ApplyFinalMovements(); 
    }
  }

  private void HandleMovementInput()
  {
    currentInput = new Vector2((IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Vertical"), (IsSprinting ? sprintSpeed : walkSpeed) * Input.GetAxis("Horizontal"));

    float moveDirectionY = moveDirection.y;
    moveDirection = (transform.TransformDirection(Vector3.forward) * currentInput.x) + (transform.TransformDirection(Vector3.right) * currentInput.y);
    moveDirection.y = moveDirectionY;
  }

  private void HandleMouseLook()
  {
    rotationX -= Input.GetAxis("Mouse Y") * lookSpeedY;
    rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
    playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeedX, 0);
  }

  private void HandleHeadBob()
  {
    if(!characterController.isGrounded) return;

    if(Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) >0.1f)
    {
      timer += Time.deltaTime * (IsSprinting ? sprintBobSpeed : walkBobSpeed);
      playerCamera.transform.localPosition = new Vector3(
        playerCamera.transform.localPosition.x,
        defaultYPos + Mathf.Sin(timer) * (IsSprinting ? sprintBobAmount : walkBobAmount),
        playerCamera.transform.localPosition.z);
    }
  }

  private void ApplyFinalMovements()
  {
    if(!characterController.isGrounded)
      moveDirection.y -= gravity + Time.deltaTime;
    
    characterController.Move(moveDirection * Time.deltaTime);
  }
}
