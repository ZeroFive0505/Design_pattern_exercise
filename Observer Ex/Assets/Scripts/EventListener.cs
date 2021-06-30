using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public void OnEventOccurs(GameObject obj)
    {
        response.Invoke(obj);
    }
}
