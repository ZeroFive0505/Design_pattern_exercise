# State 패턴
## State 패턴을 이용한 AI

State에는 Enter, Update, Exit이라는 세가지 단계가 있어서 Enter에서는 변수 초기화 등의 준비 작업을 주로하고 Update에서는 해당 State에서의 로직이 주를 이룬다. 그리고 Exit에서는
변수의 초기화나 에니메이터의 트리거를 리셋한다.

```C#
public enum STATE
{
    IDLE, PATROL, PURSUE, ATTACK, DEFEATED, RUNAWAY, FLAIR
};
    ...
```
해당 예제에서는 7가지 State가 있다.

```C#
public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Animator _anim, Transform _player) : base(_npc, _agent, _anim, _player)
    {
        name = STATE.IDLE;
    }

    public override void Enter()
    {
        anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {
        if(CanSeePlayer())
        {
            nextState = new Pursue(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

        if(Random.Range(0, 1000) < 10)
        {
            nextState = new Patrol(npc, agent, anim, player);
            stage = EVENT.EXIT;
            return;
        }

        if(Random.Range(0, 5000) < 10)
        {
            nextState = new Flair(npc, agent, anim, player);
            stage = EVENT.EXIT;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isIdle");
        base.Exit();
    }
}

```
Idle State를 예로 들면 Enter에서는 에니메이터 트리거 값을 초기화 하고 Update에서는 난수 값이 조건을 만족한다면 새로운 State로 들어가고 Idle State를 나간다. Idle State를 나갈때는 
트리거 값을 초기화한다. 나머지 State도 비슷한 방식으로 작성되어 있다.

![ezgif-3-de7f6577dc7d](https://user-images.githubusercontent.com/39051679/124546016-f9901f80-de64-11eb-82e9-22ed6f680e6e.gif)

댄스킹 팔라딘 선생님을 예로 만들었다. 6개의 큐브는 정찰 지점 그리고 오른쪽에 하나 따로 있는 것은 안전 지대이다. 팔라딘은 이 정찰 지점을 순회하다가 플레이어가 만약 뒤에서 부터 다가온다면 겁을 먹고 
안전지대로 도망가고 분해하는 애니메이션을 재생한다. 그리고 다시 Idle 상태로 돌아오고 정찰을 시작한다. 만약 플레이어가 눈에 보인다면 플레이어에게 다가와 춤을 춘다...

![ezgif-3-2993b6f96786](https://user-images.githubusercontent.com/39051679/124546291-5d1a4d00-de65-11eb-8716-42b2fde97623.gif)


따라오면서 춤을 추는 모습이다.

 
![bandicam 2021-07-06 14-07-12-784](https://user-images.githubusercontent.com/39051679/124546392-889d3780-de65-11eb-9902-139ecfeed8bf.jpg)


마지막으로 애니메이터의 설정은 다음과 같다.
