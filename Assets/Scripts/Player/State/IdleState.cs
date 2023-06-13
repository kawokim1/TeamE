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
        }

        public void MoveLogic()
        {

        }
    }
}
