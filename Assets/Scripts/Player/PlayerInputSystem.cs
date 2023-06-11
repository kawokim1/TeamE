using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem : MonoBehaviour
{
    PlayerInputAction inputActions;
    Rigidbody playerRigidbody;
    private CharacterController characterController;

    public Vector2 movementInput;
    public Vector3 moveDir;
    Vector3 targetDirection = Vector3.zero;
    public float movementSpeed = 5.0f;

    //bool move = false;
    //캐릭터 컨트롤러
    private float gravity = -2.81f;
    Vector3 moveDirection;

    //회전
    Transform cameraObject;
    Vector2 cameraInput;
    float rotationSpeed = 7f;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
        playerRigidbody = GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        cameraObject = Camera.main.transform;

    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Movement.performed += MovementLogic;
        inputActions.Player.Movement.canceled += MovementLogic;

        inputActions.Player.CameraLook.performed += i => cameraInput = i.ReadValue<Vector2>();
    }

    private void MovementLogic(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        moveDir.x = movementInput.x;
        moveDir.z = movementInput.y;
        //move = move ? false : true;
    }


    private void OnDisable()
    {
        inputActions.Player.Disable();
    }

    private void Update()
    {
 
    }
    private void FixedUpdate()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.fixedDeltaTime;
            //playerRigidbody.useGravity = true;
            
        }
        else
        {
            moveDirection.y = 0;
        }
        Debug.Log(moveDirection.y);
        MoveTo(new Vector3(moveDir.x, 0, moveDir.z));
        characterController.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);

        //HandleMove();
    }

    public void MoveTo(Vector3 direction)
    {
        // 카메라가 바라보고 있는 방향을 기준으로 방향키에 따라 이동할 수 있도록 함
        Vector3 movedis = cameraObject.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
        HandleRotate();


    }

    private void HandleRotate()
    {
        targetDirection = cameraObject.forward * moveDir.z;
        targetDirection = targetDirection + cameraObject.right * moveDir.x;
        targetDirection.Normalize();

        if (targetDirection == Vector3.zero)
            targetDirection = transform.forward;

        targetDirection.y = 0;


        Quaternion targerRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRoation = Quaternion.Slerp(transform.rotation, targerRotation, rotationSpeed * Time.fixedDeltaTime);

        transform.rotation = playerRoation;


        

        ////playerRigidbody.velocity = targetDirection * movementSpeed;
        ////playerRigidbody.AddForce(targetDirection * movementSpeed, ForceMode.Force);
        //if (movementInput != Vector2.zero)
        //{
        //    //Vector3 movePos = gameObject.transform.position + targetDirection * (movementSpeed * Time.fixedDeltaTime);
        //    //movePos.y = 0;
        //    //playerRigidbody.MovePosition(movePos);
        //    characterController.Move(targetDirection * movementSpeed * Time.deltaTime);
        //}
    }

}
