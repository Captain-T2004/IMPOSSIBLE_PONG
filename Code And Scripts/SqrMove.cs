using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SqrMove : MonoBehaviour
{
    [SerializeField] float Speed;
    [SerializeField] float Ang;
    public GameObject square;
    private int hitCount=0;
    private int Incharge = 0;
    public TextMeshProUGUI selTextL;
    public TextMeshProUGUI selTextR;
    public int scoreL, scoreR;
    public GameObject UI;
    public bool CanStart = false;
    private int[] AllowedValues = new int[] { -1, 1 };
    private void Start()
    {
        square.SetActive(true);
        Generate();
        square.transform.position = new Vector3(0, 0, 0);
        hitCount = 0;
        CanStart = UI.GetComponent<UI>().toStart;
    }
    private void Update()
    {
        CanStart = UI.GetComponent<UI>().toStart;
        if (CanStart)
        {
            if (hitCount > 2)
            {
                hitCount = 0;
                Speed += 0.0075f;
            }
            square.transform.position += new Vector3(Speed * Mathf.Cos(Mathf.PI * Ang / 180), Speed * Mathf.Sin(Mathf.PI * Ang / 180), 0f);
        }
        if (scoreL > 9 || scoreR > 9)
        {
            CanStart = false;
            SceneManager.LoadScene("SampleScene");
        }
        print(oneOrMone());
    }
    void Generate()
    {
        square.SetActive(true);
        Speed = 0.0325f;
        Ang = 180*Incharge + Random.Range(-150f, -175f)*oneOrMone();
        print(Ang);
        square.transform.position = new Vector3(0, Random.Range(-2.5f, 2.5f), 0);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Floor" || collision.gameObject.name == "Roof") 
        {
            Ang *= -1;
        }
        if (collision.gameObject.name == "PlayerL" || collision.gameObject.name == "PlayerR")
        {
            if (collision.gameObject.name == "PlayerL") { Incharge = 1; }
            if (collision.gameObject.name == "PlayerR") { Incharge = 0; }
            Ang = 180 - Ang;
            hitCount += 1;
        }
        if (collision.gameObject.name == "1" || collision.gameObject.name == "2")
        {
            if(collision.gameObject.name == "1") 
            {
                scoreR += 1;
                selTextR.text = scoreR.ToString(); 
            }
            if(collision.gameObject.name == "2")
            {
                scoreL += 1;
                selTextL.text = scoreL.ToString();
            }
            square.SetActive(false);
            Invoke("Generate",1.5f);
        }
    }


    ////////////////////////////////////////////////////
    ////////////////////////////////////////////////////
    ////////////////////////////////////////////////////
    ////////////////////////////////////////////////////
    private int oneOrMone()
    {
        var rand = new System.Random();
        return AllowedValues[rand.Next(AllowedValues.Length)];
    }
}
