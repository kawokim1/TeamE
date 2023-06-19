using player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace monster

{
    public class M_ChaseState : MonsterState
    {

        Monster monster;
        State state = State.CHASE;
        public M_ChaseState(Monster monsterTEST)
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
            Vector3 direction = monster.target.position - monster.transform.position;
            direction.y = 0;
            monster.targetRotation = Quaternion.LookRotation(direction);
            monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation, monster.targetRotation, monster.rotationSpeed * Time.deltaTime);

            float distance = Vector3.Distance(monster.target.position, monster.transform.position);
            if (distance > monster.Distance)
            {
                direction = (monster.target.position - monster.transform.position).normalized;

                if (monster.characterController.isGrounded == false)
                {
                    direction.y += monster.gravity * Time.fixedDeltaTime;
                }


                monster.characterController.Move(direction * monster.speed * Time.fixedDeltaTime);

            }
            if(distance <= monster.Distance) 
            {
                monster.melee_AttackState.EnterState();
            }
           
        }

    }
}

