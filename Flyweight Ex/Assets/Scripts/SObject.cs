using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Objectdata", menuName ="Object Data", order = 51)]
public class SObject : ScriptableObject
{
    public enum TYPE { BOX, STAIR, STRUCTURE, WALL, TUNNEL };

    [SerializeField]
    private TYPE objectType;
    [SerializeField]
    private Image icon;

    public TYPE Type
    {
        get
        {
            return objectType;
        }
    }

    public Image Icon
    {
        get
        {
            return icon;
        }
    }
}
