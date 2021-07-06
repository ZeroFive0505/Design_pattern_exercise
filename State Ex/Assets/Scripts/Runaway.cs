using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Runaway : State
{
    public Runaway(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.RUNAWAY;
        agent.speed = 7.0f;
        agent.isStopped = false;
    }

    public override void Enter()
    {
        anim.SetTrigger("isRunning");
        agent.SetDestination(GameEnvironment.Singleton.SafePoint.transform.position);
        base.Enter();
    }

    public override void Update()
    {
        if(agent.remainingDistance < 1.0f)
        {
            nextState = new Defeated(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isRunning");
        base.Exit();
    }
}