using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace player
{
    enum State
    {
        IDLE = 0,
        WALK,
        RUN,
        SPRINT
    }
    public class PlayerInputSystem : MonoBehaviour
    {

        //컴퍼넌트
        //Rigidbody playerRigidbody;
        PlayerInputAction inputActions;
        CharacterController characterController;
        Animator animator;


        //현재 상태


        public PlayerState playerCurrentStates;
        PlayerState idleState;
        PlayerState walkState;
        PlayerState runState; 
        PlayerState sprintState;

        //애니메이션
        //readonly int InputYString = Animator.StringToHash("InputY");
        readonly int AnimatorState = Animator.StringToHash("State");
        bool walkBool = false;

        //입력값
        private Vector2 movementInput; //액션으로 받는 입력값
        private Vector3 moveDir; //입력값으로 만든 벡터3

        //캐릭터 컨트롤러
        float gravity = -9.81f; // 중력
        public Vector3 moveDirection; // 카메라까지 계산한 이동 방향

        //회전
        Transform cameraObject;
        Vector3 targetDirection = Vector3.zero; //회전하는 방향
        private float rotationSpeed = 7f;

        private void Awake()
        {
            //playerRigidbody = GetComponent<Rigidbody>();
            inputActions = new PlayerInputAction();
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            cameraObject = Camera.main.transform;


            //상태
            idleState = new IdleState(this);
            walkState = new WalkState(this);
            runState = new RunState(this);
            sprintState = new SprintState(this);
            

            playerCurrentStates = idleState;
        }

        private void OnEnable()
        {

            //인풋시스템
            inputActions.Player.Enable();
            
            //WASD
            inputActions.Player.Movement.performed += MovementLogic;
            inputActions.Player.Movement.canceled += MovementLogic;

            //Shift 전력 질주
            inputActions.Player.Sprint.performed += SprintButton;
            //inputActions.Player.CameraLook.performed += i => cameraInput = i.ReadValue<Vector2>();

            //Control 걷기
            inputActions.Player.Walk.performed += WalkButton;
        }

        private void WalkButton(InputAction.CallbackContext _)
        {
            walkState.EnterState();
            walkBool = walkBool ? false : true;
        }

        private void SprintButton(InputAction.CallbackContext _)
        {
            sprintState.EnterState();
            walkBool = false;
        }

        private void MovementLogic(InputAction.CallbackContext context)
        {
            movementInput = context.ReadValue<Vector2>();
            moveDir.x = movementInput.x;
            moveDir.z = movementInput.y;


            if (movementInput == Vector2.zero)
            {
                idleState.EnterState();
            }
            else if(playerCurrentStates != sprintState && !walkBool)
            {
                runState.EnterState();
            }
            else if(walkBool)
            {
                walkState.EnterState();
            }
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
            playerCurrentStates.MoveLogic();
        }


        public void PlayerMove(float moveSpeed)
        {
            if (characterController.isGrounded == false)
            {
                moveDirection.y += gravity * Time.fixedDeltaTime;
            }
            //else
            //{
            //    moveDirection.y = 0;
            //}
            characterController.Move(moveDirection * moveSpeed * Time.fixedDeltaTime);
        }

        public void PlayerAnimoatrChage(int state)
        {
            animator.SetInteger(AnimatorState, state);
        }

        public void MoveToDir()
        {
            Vector3 movedis = cameraObject.rotation * new Vector3(moveDir.x, 0, moveDir.z);

            moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
            PlayerRotate();
        }

        private void PlayerRotate()
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
        }
    }

}