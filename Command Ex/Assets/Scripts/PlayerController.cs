using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public float speed = 2.0f;
    public float rotationSpeed = 100.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void LateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
       
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (translation == 0.0f && rotation == 0.0f)
            anim.SetBool("isWalking", false);
        else
        {
            anim.SetBool("isWalking", true);
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
        }

        Color color = new Color(1.0f, 0.0f, 0.0f);
        Debug.DrawLine(transform.position + (Vector3.up * 1.0f), transform.position + transform.forward * 5.0f, color);

        //if (Input.GetKeyDown(KeyCode.P))
        //    anim.SetTrigger("isPunching");
        //else if (Input.GetKeyDown(KeyCode.K))
        //    anim.SetTrigger("isKicking");
    }
}
