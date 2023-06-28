using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace player
{
    public class AttackState : PlayerState
    {
        //어택 0~4
        //강공격
        //대쉬 공격
        //애니메이터 오버라이딩
        //콤보 카운터
        int comboCount = 0;
        int maxComboCount = 4;

        float comboTimer = 0.0f;
        float maxComboTimer = 1.5f;

        private bool isAttack = false;

        PlayerInputSystem playerInputSystem;
        Animator animator;
        State state = State.Attack;

        public AttackState(PlayerInputSystem playerInputSystem, Animator animator)
        {
            this.playerInputSystem = playerInputSystem;
            this.animator = animator;
        }

        public void EnterState()
        {
            if(isAttack)
            {
                ComboAttack();
            }
            else
            {
                playerInputSystem.playerCurrentStates = this;
                isAttack = true;
                playerInputSystem.PlayerAnimoatrChage((int)state);
                //ComboAttack();
            }

        }
        public void ComboAttack()
        {
            if(comboCount < maxComboCount)
            {
                comboTimer = 0.0f;
                animator.SetInteger("ComboCount", comboCount++);
            }
        }

        public void MoveLogic()
        {
            //Debug.Log(isAttack);
            comboTimer += Time.deltaTime;
            //Debug.Log(comboTimer);
            if (comboTimer > maxComboTimer)
            {
                comboCount = 0;
                comboTimer = 0.0f;
                isAttack = false;
                playerInputSystem.PlayerEnterIdleState();
                
            }

            //적한테 살짝 접근
        }
    }
}

