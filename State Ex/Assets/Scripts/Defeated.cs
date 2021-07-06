using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Defeated : State
{
    public Defeated(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.DEFEATED;
        agent.speed = 0;
        agent.isStopped = true;
    }

    public override void Enter()
    {
        anim.SetTrigger("defeated");
        base.Enter();
    }

    public override void Update()
    {
        if(Random.Range(0, 10000) < 10)
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("defeated");
        base.Exit();
    }
}