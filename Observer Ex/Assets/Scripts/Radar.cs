using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RadarObject
{
    public Image icon { get; set; }

    public GameObject owner { get; set; }
}

public class Radar : MonoBehaviour
{
    public Transform playerPos;

    float mapScale = 2.0f;

    public static List<RadarObject> radarObjects = new List<RadarObject>();

    public static void RegisterRadarObject(GameObject obj, Image img)
    {
        Image image = Instantiate(img);
        radarObjects.Add(new RadarObject() { owner = obj, icon = image });
    }

    public static void RemoveRadarObject(GameObject obj)
    {
        List<RadarObject> newList = new List<RadarObject>();

        for(int i = 0; i < radarObjects.Count; i++)
        {
            if (radarObjects[i].owner == obj)
            {
                Destroy(radarObjects[i].icon);
                continue;
            }
            else
                newList.Add(radarObjects[i]);
        }

        radarObjects.RemoveRange(0, radarObjects.Count);
        radarObjects.AddRange(newList);
    }

    private void DrawRadarDots()
    {
        foreach(RadarObject ro in radarObjects)
        {
            Vector3 radarPos = (ro.owner.transform.position - playerPos.position);
            float distToObject = Vector3.Distance(playerPos.position, ro.owner.transform.position) * mapScale;
            float deltaY = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg - 270 - playerPos.eulerAngles.y;
            radarPos.x = distToObject * Mathf.Cos(deltaY * Mathf.Deg2Rad) * -1;
            radarPos.z = distToObject * Mathf.Sin(deltaY * Mathf.Deg2Rad);

            ro.icon.transform.SetParent(this.transform);
            RectTransform rt = this.GetComponent<RectTransform>();
            ro.icon.transform.position = new Vector3(radarPos.x + rt.pivot.x, radarPos.z + rt.pivot.y, 0) + transform.position;
        }
    }

    public void ItemDropped(GameObject obj)
    {
        Debug.Log("Item Dropped");
        RegisterRadarObject(obj, obj.GetComponent<Item>().GetIcon());
    }

    public void ItemPickedUp(GameObject obj)
    {
        RemoveRadarObject(obj);
    }

    private void Update()
    {
        DrawRadarDots();
    }
}
