using player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace monster

{
    public class M_BackState : MonsterState
    {
        State state = State.BACK;
        Monster monster;
        public M_BackState(Monster monster)
        {
            this.monster = monster;
        }

        public void EnterState()
        {
            monster.monsterCurrentStates = this;
            monster.PlayerAnimoatrChage((int)state);
            monster.startpoint.position = monster.spawnPosition;
        }

        public void MoveLogic()
        {
            
            //Transform recog = monster.transform.GetChild(2);

            // Collider recogArea = recog.GetComponent<Collider>();

            // recogArea.enabled = false;

            Vector3 direction = monster.spawnPosition - monster.transform.position;
            direction.y = 0;
            //if (direction != Vector3.zero)
            //{
            //    monster.spawnRotation = Quaternion.LookRotation(direction);
            //    monster.transform.rotation = Quaternion.Slerp(monster.transform.rotation, monster.spawnRotation, monster.rotationSpeed * Time.deltaTime);
            //}

            float distance = Vector3.Distance(monster.spawnPosition, monster.transform.position);
            if (distance > 1)
            {
                direction = (monster.spawnPosition - monster.transform.position).normalized;


                if (monster.characterController.isGrounded == false)
                {
                    direction.y += monster.gravity * Time.fixedDeltaTime;
                }

                monster.nav.SetDestination(monster.startpoint.position);
                // monster.characterController.Move(direction * monster.speed * Time.fixedDeltaTime);
            }
            if (distance <= 1)
            {
                // recogArea.enabled = true;
               
               monster.StopCoroutine(monster.BackToSpawn());
                monster.StartCoroutine(monster.OnMove());
               
            }
        }
    }
}

