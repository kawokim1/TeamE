using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace player
{
    public class SprintState : PlayerState
    {
        PlayerInputSystem playerInputSystem;
        State state = State.SPRINT;
        private float moveSpeed = 8.0f;
        public SprintState(PlayerInputSystem playerInputSystem)
        {
            this.playerInputSystem = playerInputSystem;
        }

        public void EnterState()
        {
            playerInputSystem.playerCurrentStates = this;
            playerInputSystem.PlayerAnimoatrChage((int)state);
        }

        public void MoveLogic()
        {
            playerInputSystem.MoveToDir();
            playerInputSystem.PlayerMove(moveSpeed);
            playerInputSystem.PlayerAnimoatrChage((int)state);
        }

    }
}
