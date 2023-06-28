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


        bool isAttack = true;
        public M_MeleeAttackState(Monster monster)
        {
            
            this.monster = monster;
        }
        public void EnterState()
        {
            monster.monsterCurrentStates = this;
             monster.PlayerAnimoatrChage((int)state);
          
        }
        
        public void MoveLogic()
        {

            Vector3 direction = monster.target.position - monster.transform.position;
            monster.targetRotation = Quaternion.LookRotation(direction);
            monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation, monster.targetRotation, monster.rotationSpeed * Time.deltaTime);
            
            float distance = Vector3.Distance(monster.target.position, monster.transform.position);
            if (distance > monster.Distance && isAttack)
            {
              
                if (monster.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                {
                    isAttack = false;
                    monster.chaseState.EnterState();
                }
               
            }
        }

     
    }
}