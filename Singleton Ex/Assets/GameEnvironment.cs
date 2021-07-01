using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameEnvironment
{
    private static GameEnvironment instance;
    private List<GameObject> wayPoints = new List<GameObject>();
    private List<GameObject> items = new List<GameObject>();
    // Start is called before the first frame update
    public List<GameObject> Items
    {
        get
        {
            return items;
        }
    }

    public List<GameObject> WayPoints
    {
        get
        {
            return wayPoints;
        }
    }

    public static GameEnvironment Singleton
    {
        get
        {
            if(instance == null)
            {
                instance = new GameEnvironment();
                instance.WayPoints.AddRange(GameObject.FindGameObjectsWithTag("WayPoint"));
            }

            return instance;
        }
    }

    public void AddWayPoint(GameObject obj)
    {
        WayPoints.Add(obj);
    }

    public void RemoveWayPoint(GameObject obj)
    {
        int index = WayPoints.IndexOf(obj);
        wayPoints.RemoveAt(index);
        GameObject.Destroy(obj);
    }

    public void AddItem(GameObject obj)
    {
        items.Add(obj);
    }

    public void RemoveItem(GameObject obj)
    {
        int index = items.IndexOf(obj);
        items.RemoveAt(index);
        GameObject.Destroy(obj);
    }

    public GameObject GetRandomPoints()
    {
        int index = Random.Range(0, wayPoints.Count);
        return wayPoints[index];
    }

    public bool IsExist()
    {
        return items.Count > 0;
    }
}
