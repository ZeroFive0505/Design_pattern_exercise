# Observer 패턴

## Observer 패턴을 이용한 레이더

크게 2가지 구조로 만들어졌다. Event와 그 Event를 구독하는 EventListener가 있다. 
아래는 Event의 Scriptable object이다.
```C#
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event", menuName ="Game Event", order = 52)]
public class Event : ScriptableObject
{
    // 현재 이 이벤트를 듣는 구독자들의 리스트
    private List<EventListener> eventListeners = new List<EventListener>();

    // 구독한다.
    public void Register(EventListener listener)
    {
        eventListeners.Add(listener);
    }
    
    // 구독을 취소한다.
    public void UnRegister(EventListener listener)
    {
        eventListeners.Remove(listener);
    }

    // 이벤트가 발생했을시 모든 구독자들에게 알린다.
    public void Occured(GameObject obj)
    {
        for(int i = 0; i < eventListeners.Count; i++)
        {
            eventListeners[i].OnEventOccurs(obj);
        }
    }
}
```

```C#
using UnityEngine;
using UnityEngine.Events;

// 보이드 형태의 이벤트가 아닌 GameObject를 받는 이벤트를 만듦.
[System.Serializable]
public class UnityGameObjectEvent : UnityEvent<GameObject>
{

}

public class EventListener : MonoBehaviour
{
    public Event item;
    public UnityGameObjectEvent response = new UnityGameObjectEvent();

    private void OnEnable()
    {
        item.Register(this);
    }

    private void OnDisable()
    {
        item.UnRegister(this);
    }
    
    // 이벤트가 발생했을시 동작한다. GameObject를 변수로 받는다.
    public void OnEventOccurs(GameObject obj)
    {
        response.Invoke(obj);
    }
}
```

예제에서는 빨간 큐브와 파란 큐브가 이벤트 발생의 주체가 되며, 이 이벤트를 듣는 객체는 레이더가 된다.

![bandicam 2021-06-30 11-26-38-478](https://user-images.githubusercontent.com/39051679/123892698-0ceb4880-d996-11eb-922a-41b52ff608b7.jpg)

레이더는 두개의 리스너를 가지고 있으며 아이템이 들어가는 공간에는 각각 다른 이벤트가 들어있다. 그리고 각각 이벤트가 발생했을시에 위의 `OnEventOccurs`가 호출이된다. 각각 이벤트마다
레이더에 있는 다른 함수를 호출하게 된다.

![ezgif-7-7a9c3961acd9](https://user-images.githubusercontent.com/39051679/123892960-7d926500-d996-11eb-9eee-b1a7cff5afdd.gif)

마우스를 누를때마다 랜덤한 위치에서 큐브가 드랍되며 드랍되는 순간 레이더에 `ItemDropped`가 호출되며 만약 유저가 픽업을 했을시에는 `ItemPickedUp`이 호출된다.
