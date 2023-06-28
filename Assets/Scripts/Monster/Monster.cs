using player;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace monster
{
    enum State
    {
        IDLE = 0,
        WALK,
        CHASE,
        BACK,
        MELEE_ATTACK,
        LONG_ATTACK,
        Die
    }
    public class Monster : MonoBehaviour
    {
        public Transform target;                       //���Ͱ� �i�� ��ǥ(�÷��̾�)
        public float speed { get; private set; } = 2.0f;                  //���� �ӵ�
        public float backSpeed { get; private set; } = 4.0f;              //���Ͱ� �������������� ���ư��� �ӵ�
        public float gravity { get; private set; } = -9.81f;                     // �߷�
        public Quaternion targetRotation;                                //�÷��̾��� ���� ��� ����
        public float rotationSpeed { get; private set; } = 5.0f;          //Ÿ���� �Ĵٺ��µ� �ɸ��� �ӵ�
        public float Distance { get; private set; } = 1.5f;                  //���Ϳ� �÷��̾��� �ִ� ���� �Ÿ� �� ���ݹߵ� �Ÿ�
        public Quaternion spawnRotation;                                 //������������ ����
        float wait;
        public Vector3 spawnPosition;
        public Vector3 dir;
        public Vector3 moveDirection;
        public Vector3 targetPosition;
        
        public Vector3 direction;
        PlayerInputSystem player;
        Monster_FOV FOV1;
        Monster_FOV_1 FOV2;
       public NavMeshAgent nav;
        public CharacterController characterController;
        public Animator animator;
        readonly int AnimatorState = Animator.StringToHash("State");
        //���� ����
        public bool onMove = false;
        public bool isAttack = true;
        
        public MonsterState monsterCurrentStates;
        MonsterState idleState;              //0
        MonsterState walkState;       //1
        public MonsterState chaseState;             //2
        MonsterState backState;              //3
        public MonsterState melee_AttackState;      //4
        MonsterState long_AttacktState;      //5
        MonsterState dieState;               //6
        public Transform startpoint;
        public Transform endpoint;
        public void Awake()
        {
            startpoint = transform;
            nav = GetComponent<NavMeshAgent>();
            FOV1 = FindObjectOfType<Monster_FOV>();
            FOV2= FindObjectOfType<Monster_FOV_1>();
            player = FindObjectOfType<PlayerInputSystem>();
            target = player.transform;
            animator = GetComponent<Animator>();
            characterController = GetComponent<CharacterController>();
            spawnPosition = transform.position;

            idleState = new M_IdleState(this);
            walkState = new M_WalkState(this);
            chaseState = new M_ChaseState(this);
            backState = new M_BackState(this);
            melee_AttackState = new M_MeleeAttackState(this);
            long_AttacktState = new M_LongAttackState();
            dieState = new M_DieState();


            monsterCurrentStates = idleState;
            PlayerAnimoatrChage(0);
        }
        private void Start()
        {
            //detectedArea.SetActive(false);
            onMove = true;
            isAttack = false;
            StartCoroutine(OnMove());
        }
        public void PlayerAnimoatrChage(int state)
        {
            animator.SetInteger(AnimatorState, state);
        }
       
       

        private void FixedUpdate()
        {

            Detected();
            //Debug.Log(monsterCurrentStates);
            monsterCurrentStates.MoveLogic();
        }

     public IEnumerator OnMove()
        {
            wait = Random.Range(3, 7);
            while (true)
            {
                idleState.EnterState();
                yield return new WaitForSeconds(wait * 0.5f);
                walkState.EnterState();
                yield return new WaitForSeconds(wait);
              
            }

        }

        /// <summary>
        /// ���Ͱ� ������������ ���� �Ѵ� �ڷ�ƾ
        /// </summary>
        /// <returns></returns>
       public IEnumerator BackToSpawn()
        {
            yield return new WaitForSeconds(3);
            backState.EnterState();
           // detectedArea.SetActive(false);
        }

        private void Detected()
        {
            if ((FOV1.isCollision || FOV2.isCollision) && onMove)
            {
                StopAllCoroutines();
                onMove = false;
                chaseState.EnterState();
               // detectedArea.SetActive(true);
            }
            if (!FOV1.isCollision && !FOV2.isCollision && onMove == false)
            {
                StartCoroutine(BackToSpawn());
                onMove = true;
                
            }
            




        }
    }
}

