using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject selObject;
    public GameObject selSquare;
    private float Speed = 0.025f;
    private int Direction;
    private bool CanStart;
    private float aiDeadZone = 0.85f;
    private void Start()
    {
        Speed = 0.02f;
    }
    void Update()
    {
        CanStart = selSquare.GetComponent<SqrMove>().CanStart;
        if (Mathf.Abs(selObject.transform.position.y - selSquare.transform.position.y) > aiDeadZone)
        {
            Direction = selObject.transform.position.y > selSquare.transform.position.y ? -1 : 1;
        }
        if (CanStart)
        {
            if(Direction == 1)
            {
                if(selObject.transform.position.y <= 2.9f) { Movee(Direction); }
            }
            if (Direction == -1)
            {
                if (selObject.transform.position.y >= -2.9f) { Movee(Direction); }
            }

        }
    }
    private void Movee(int Direction)
    {
        selObject.transform.position += new Vector3(0f, Speed * Direction, 0f);
    }
}
