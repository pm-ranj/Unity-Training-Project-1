using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float maxY = 4.4f, minY = -4.4f;
    public GameObject[] astroids = new GameObject[2];
    public GameObject enemyShip;
    private float pos_y;
    private float timer = 1.7f;

    void Start()
    {
        Invoke("enemySpawner", timer);
    }

    void enemySpawner()
    {
        pos_y = Random.Range(minY, maxY);
        Vector3 temp = transform.position;
        temp.y = pos_y;
        if (Random.Range(0, 2) > 0)
        {
            Instantiate(astroids[Random.Range(0, astroids.Length)], temp, Quaternion.identity);
        }
        else
        {
            Instantiate(enemyShip, temp, Quaternion.Euler(0f, 0f, 90f));
        }
        Invoke("enemySpawner", timer);
    }
}
