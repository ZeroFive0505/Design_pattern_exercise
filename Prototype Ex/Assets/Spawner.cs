using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Material material;
    public GameObject sphere;
    public void SpawnSphere()
    {
        sphere = MakeSphere.GenerateSphere(transform.position);
        sphere.GetComponent<MeshRenderer>().sharedMaterial = material;
    }


}
