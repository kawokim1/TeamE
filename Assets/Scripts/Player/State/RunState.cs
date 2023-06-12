using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class RunState : PlayerState
    {
        PlayerInputSystem playerInputSystem;
        State state = State.RUN;
        private float moveSpeed = 5.0f;
        public RunState(PlayerInputSystem playerInputSystem)
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


