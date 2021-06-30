using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="Icon", menuName ="Icon", order = 51)]
public class Icon : ScriptableObject
{
    public Image icon;

    public Image GetIcon()
    {
        return icon;
    }
}
