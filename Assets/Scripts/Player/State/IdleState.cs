using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace player
{
    public class IdleState : PlayerState
    {
        PlayerInputSystem playerInputSystem;
        State state = State.IDLE;
        public IdleState(PlayerInputSystem playerInputSystem)
        {
            this.playerInputSystem = playerInputSystem;
        }

        public void EnterState()
        {
            playerInputSystem.playerCurrentStates = this;
            playerInputSystem.PlayerAnimoatrChage((int)state);
            playerInputSystem.lastMemorySpeed = 0.0f;
            playerInputSystem.moveDirection = Vector3.zero;
        }

        public void MoveLogic()
        {

        }
    }
}
