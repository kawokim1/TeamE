using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace monster

{
    public class M_WalkState : MonsterState 
    {
        State state = State.WALK;
        MonsterTEST monster;
        public M_WalkState(MonsterTEST monsterTEST)
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
            SetMove();
            monster.moveDirection.y = 0;
            monster.targetRotation = Quaternion.LookRotation(monster.moveDirection);
            monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation, monster.targetRotation, monster.rotationSpeed * Time.deltaTime);

            if (monster.characterController.isGrounded == false)
            {
                monster.moveDirection.y += monster.gravity * Time.fixedDeltaTime;
            }

            monster.characterController.Move(monster.dir * monster.speed * Time.fixedDeltaTime);


            if (monster.transform.position.z > monster.areaMax.z)
            {
                SetMove();
            }
            else if (monster.transform.position.z < monster.areaMin.z)
            {
                SetMove();
            }

        }

        public void SetMove()
        {
            float x;
            float z;

            x = Random.Range(monster.areaMin.x, monster.areaMax.x);
            if (monster.transform.position.z > 5)
            {
                z = monster.areaMin.z;
            }
            else
            {
                z = monster.areaMax.z;
            }
            monster.targetPosition = new Vector3(x, 0, z);
            monster.moveDirection = monster.targetPosition - monster.transform.position;
            monster.dir = monster.moveDirection.normalized;

        }
    }
}

    
