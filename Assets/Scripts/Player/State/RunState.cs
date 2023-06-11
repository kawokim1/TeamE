using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : PlayerState
{
    PlayerInputSystem playerInputSystem;
    private float moveSpeed = 5.0f;
    public RunState(PlayerInputSystem playerInputSystem)
    {
        this.playerInputSystem = playerInputSystem;
    }
    public void MoveLogic()
    {
        playerInputSystem.MoveToDir();
        playerInputSystem.PlayerMove(moveSpeed);
    }

}

