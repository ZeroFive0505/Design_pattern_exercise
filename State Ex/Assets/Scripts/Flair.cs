using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flair : State
{
    public Flair(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.FLAIR;
        agent.speed = 0.0f;
        agent.isStopped = true;
    }

    public override void Enter()
    {
        anim.SetTrigger("flair");
        base.Enter();
    }

    public override void Update()
    {
        if(Random.Range(0, 5000) < 5)
        {
            nextState = new Idle(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("flair");
        base.Exit();
    }
}