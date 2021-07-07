using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Update is called once per frame
    public GameObject ball;

    private void Start()
    {
        InvokeRepeating("SpawnBall", 0.1f, 0.1f);
    }

    void Update()
    {

    }

    void SpawnBall()
    {
        GameObject item = Pool.singleton.Get("Ball");
        if (item != null)
        {
            item.transform.position = transform.position;
            Vector3 randOffset = new Vector3(Random.Range(-transform.localScale.x, transform.localScale.x), 0,
                Random.Range(-transform.localScale.z, transform.localScale.z));
            item.transform.position += randOffset;
            item.SetActive(true);
        }
    }
}
