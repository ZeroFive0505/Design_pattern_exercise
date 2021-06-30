using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    private Text objectName;
    [SerializeField]
    private Text objectType;
    [SerializeField]
    private Image objectImage;

    public void SetUI(string objName, SObject.TYPE type, Image objImg)
    {
        objectName.text = objName.ToString();
        objectType.text = type.ToString();
        objectImage.sprite = objImg.sprite;
    }
}
