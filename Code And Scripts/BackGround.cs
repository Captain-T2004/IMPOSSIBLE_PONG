using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public GameObject selMenuObj;
    public AudioSource Source1;
    public void Update()
    {
        if (selMenuObj.activeSelf)
        {
            Source1.Play();
        }
    }
}
