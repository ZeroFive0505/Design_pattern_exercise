using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{

    private GameObject[] points;
    private NavMeshAgent agent;
    private Vector3 lastPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.FindGameObjectsWithTag("WayPoint");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(GameEnvironment.Singleton.GetRandomPoints().transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameEnvironment.Singleton.IsExist())
        {
            float dist = Mathf.Infinity;
            GameObject target = null;
            foreach(GameObject obj in GameEnvironment.Singleton.Items)
            {
                if(Vector3.Distance(transform.position, obj.transform.position) < dist)
                {
                    dist = Vector3.Distance(transform.position, obj.transform.position);
                    target = obj;
                }
            }

            if (target != null)
                agent.SetDestination(target.transform.position);

            if (Vector3.Distance(transform.position, target.transform.position) < 1.5f)
                GameEnvironment.Singleton.RemoveItem(target);

            return;
        }

        if (!agent.hasPath)
            GoToLastPosition();

        if (agent.remainingDistance < 1.0f)
        {
            lastPoint = agent.destination;
            agent.SetDestination(GameEnvironment.Singleton.GetRandomPoints().transform.position);
        }
    }

    public void GoToLastPosition()
    {
        if (lastPoint != Vector3.zero)
            agent.SetDestination(lastPoint);
        else
            agent.SetDestination(GameEnvironment.Singleton.GetRandomPoints().transform.position);
    }
}
