using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.GetComponent<ObjectInfo>())
        {
            hit.gameObject.GetComponent<ObjectInfo>().SetUI();
        }
    }
}
