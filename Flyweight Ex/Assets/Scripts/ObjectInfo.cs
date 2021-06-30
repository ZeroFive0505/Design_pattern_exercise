using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    [SerializeField]
    private SObject sObject;
    [SerializeField]
    private GameObject UICanvas;
    private void Start()
    {
        
    }
    public void SetUI()
    {
        UICanvas.GetComponent<UI>().SetUI(gameObject.name, sObject.Type, sObject.Icon);
    }
}
