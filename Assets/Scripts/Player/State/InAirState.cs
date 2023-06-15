using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class InAirState : PlayerState
    {
        PlayerInputSystem playerInputSystem;
        CharacterController characterController;
        State state = State.InAir;
        private float jumpForce = 3.0f;
        float lastSpeed = 0.0f;

        public InAirState(PlayerInputSystem playerInputSystem, CharacterController characterController)
        {
            this.playerInputSystem = playerInputSystem;
            this.characterController = characterController;
        }

        public void EnterState()
        {
            playerInputSystem.playerCurrentStates = this;
            lastSpeed = playerInputSystem.lastMemorySpeed;
            playerInputSystem.PlayerAnimoatrChage((int)state);
        }
        public void EnterState(bool jump = false)
        {
            EnterState();
            if(jump)
                playerInputSystem.moveDirection.y = jumpForce;
        }

        public void MoveLogic()
        {
            characterController.Move(
              new Vector3(playerInputSystem.moveDirection.x * lastSpeed,
              playerInputSystem.moveDirection.y * jumpForce,
              playerInputSystem.moveDirection.z * lastSpeed)
              * Time.fixedDeltaTime);

            playerInputSystem.UseGravity();
        }
    }

}
