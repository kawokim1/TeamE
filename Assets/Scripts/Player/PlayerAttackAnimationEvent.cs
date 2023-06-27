using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttackAnimationEvent : MonoBehaviour
{
    public PlayerInputSystem playerInputSyatem;
    public CharacterController characterController;


    private void Awake()
    {
        playerInputSyatem = GetComponent<PlayerInputSystem>();
        characterController = GetComponent<CharacterController>();
    }


    //전진과 콜리더 생성 제거
    public void AttackAnimation(float attackForwardMoveSpeed, Vector3 moveTargetDir)
    {
        characterController.Move(attackForwardMoveSpeed * Time.fixedDeltaTime * moveTargetDir);
    }

}

