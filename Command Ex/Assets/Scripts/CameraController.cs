using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float distance = 10.0f;
    public float height = 5.0f;
    public Vector3 lookOffset = new Vector3(0, 1, 0);
    float camSpeed = 100.0f;
    float camRotSpeed = 100.0f;

    private void FixedUpdate()
    {
        if(player)
        {
            Vector3 lookPosition = player.position + lookOffset;
            Vector3 relativePos = lookPosition - transform.position;
            Quaternion rot = Quaternion.LookRotation(relativePos);

            transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * camRotSpeed * 0.1f);
            Vector3 targetPos = player.transform.position + player.transform.up * height - player.transform.forward * distance;

            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * camSpeed * 0.1f);
        }
    }
}
