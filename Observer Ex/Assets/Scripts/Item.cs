using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Event dropped;
    public Event pickUp;
    public Icon icon;

    private void Start()
    {
        dropped.Occured(gameObject);
    }

    public Image GetIcon()
    {
        return icon.GetIcon();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUp.Occured(gameObject);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 2.0f);
        }
    }
}
