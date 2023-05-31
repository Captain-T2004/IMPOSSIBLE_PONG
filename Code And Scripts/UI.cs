using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject selMenuObj;
    public bool toStart=false;
    private void Start()
    {
        selMenuObj.SetActive(true);
    }
    public void OnStartClick()
    {
        toStart = true;
        selMenuObj.SetActive(false);
    }
    public void OnExitClick()
    {
        Application.Quit();
    }
    private void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            toStart=false;
            selMenuObj.SetActive(true);
        }
    }
}
