using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class WalkState : PlayerState
    {
        PlayerInputSystem playerInputSystem;
        State state = State.WALK;
        private float moveSpeed = 3.0f;
        public WalkState(PlayerInputSystem playerInputSystem)
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
            //playerInputSystem.PlayerAnimoatrChage((int)state);
        }

    }
}