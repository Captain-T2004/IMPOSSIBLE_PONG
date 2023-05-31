using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject selObject;
    public float ySpeed = 0.025f;

    void Update()
    {
        Move();        
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.W) && selObject.transform.position.y <= 2.9f)
        {
            selObject.transform.position += new Vector3(0f, ySpeed, 0f);
        }
        else if (Input.GetKey(KeyCode.S) && selObject.transform.position.y >= -2.9f)
        {
            selObject.transform.position -= new Vector3(0f, ySpeed, 0f);
        }
    }
}
