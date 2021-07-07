using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Rigidbody rb;

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        Vector3 randomOffset = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));

        Vector3 bounceDir = (normal + randomOffset).normalized;

        rb.AddForce(bounceDir * speed, ForceMode.Impulse);
    }

    private void OnBecameInvisible()
    {
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
