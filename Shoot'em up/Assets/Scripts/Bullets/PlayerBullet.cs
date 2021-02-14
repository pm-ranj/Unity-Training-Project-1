using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] public float speed = 7f;
    private float destroyTime = 3f;
    [HideInInspector] public bool isEnemyBullet = false;
    void Start()
    {
        if (isEnemyBullet)
        {
            speed *= -1f;
        }
        Invoke("DestroyBullet", destroyTime);
    }

    void Update()
    {
        Move();
    }
     void Move()
    {
        Vector3 temp = transform.position;
        temp.x += Time.deltaTime * speed;
        transform.position = temp;
    }
    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }
    
}
