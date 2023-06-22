using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace player
{
    public class AttackState : MonoBehaviour, PlayerState
    {
        //어택 0~4
        //강공격
        //대쉬 공격
        //애니메이터 오버라이딩
        //콤보 카운터
        public int comboCount = 0;

        PlayerInputSystem playerInputSystem;
        State state = State.Attack;

        public AttackState(PlayerInputSystem playerInputSystem)
        {
            this.playerInputSystem = playerInputSystem;
        }
        private void Update()
        {
            //강공격 타이머, 콤보공격 타이머
        }

        public void EnterState()
        {
            playerInputSystem.playerCurrentStates = this;
        }

        public void MoveLogic()
        {

        }
    }
}

