using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float Speed = 5f;
    [SerializeField] float Max_y, Min_y;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxis("Vertical") > 0f)
        {
            Vector3 temp = transform.position;
            temp.y += Time.deltaTime * Speed;
            if (temp.y > Max_y)
            {
                temp.y = Max_y;
            }
            transform.position = temp;
            
        }

        else if (Input.GetAxis("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= Time.deltaTime * Speed;
            if (temp.y < Min_y)
            {
                temp.y = Min_y;
            }
            transform.position = temp;
            
        }
    }
}
