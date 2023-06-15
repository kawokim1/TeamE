namespace monster

{
    public class M_MeleeAttackState : MonsterState
    {
        MonsterTEST monster;
        State state = State.MELEE_ATTACK;
        public M_MeleeAttackState(MonsterTEST monsterTEST)
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

        }

    }
}