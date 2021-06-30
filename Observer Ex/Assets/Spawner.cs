using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject redCube;
    public GameObject blueCube;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnCube();
    }

    public void SpawnCube()
    {
        Vector3 randOffset = new Vector3(Random.Range(-transform.localScale.x, transform.localScale.x), 0,
            Random.Range(-transform.localScale.z, transform.localScale.z));
        int randNum = Random.Range(0, 2);
        GameObject obj = null;
        switch(randNum)
        {
            case 0:
                obj = Instantiate(redCube, transform.position + randOffset, Quaternion.identity);
                break;
            case 1:
                obj = Instantiate(blueCube, transform.position + randOffset, Quaternion.identity);
                break;
        }
    }
}
