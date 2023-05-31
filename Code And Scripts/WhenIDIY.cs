using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhenIDIY : MonoBehaviour
{
    public GameObject selSquare;
    public AudioSource Source;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "1" && collision.name != "2")
        {
            Source.Play();
        }
    }
}
