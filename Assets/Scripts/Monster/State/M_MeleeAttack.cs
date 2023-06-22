using player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
namespace monster

{
    public class M_MeleeAttackState : MonsterState
    {
        Monster monster;
        State state = State.MELEE_ATTACK;
        public M_MeleeAttackState(Monster monsterTEST)
        {
            this.monster = monsterTEST;
        }
        public void EnterState()
        {
            monster.monsterCurrentStates = this;
            monster.PlayerAnimoatrChage((int)state);
        }

        public void MoveLogic()
        {

            float distance = Vector3.Distance(monster.target.position, monster.transform.position);
            if (distance > monster.Distance)
            {
                monster.chaseState.EnterState();
            }
        }

    }
}