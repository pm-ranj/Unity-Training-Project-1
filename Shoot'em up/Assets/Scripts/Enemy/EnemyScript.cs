﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] public float speed = 5f;
    [SerializeField] public float rotateSpeed = 50f;
    public bool canShoot;
    public bool canRotate;
    public bool canMove = true;
    public AudioSource laserSound;
    public AudioSource explosionSound;
    public float bound_x = -11f;

    [SerializeField] public Transform attackPoint;
    [SerializeField] private GameObject enemyBullet;

    private Animator anim;
    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        AudioSource[] Sounds = GetComponents<AudioSource>();
        laserSound = Sounds[0];
        explosionSound = Sounds[1];
        if (canRotate && Random.Range(0,2) > 0)
        {
            rotateSpeed = Random.Range(rotateSpeed, rotateSpeed + 40f);
            rotateSpeed *= -1f;
        }
        if (canShoot)
        {
            Invoke("Shoot", Random.Range(1f, 2f));
        }
    }
    void Update()
    {
        Move();
        Roatate();
    }
    void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= Time.deltaTime * speed;
            transform.position = temp;
            if (temp.x < bound_x)
            {
                gameObject.SetActive(false);
            }
        }
    }
    void Roatate()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * rotateSpeed), Space.World);
        }
    }
    void Shoot()
    {
        laserSound.Play();
        GameObject bullet = Instantiate(enemyBullet, attackPoint.position, Quaternion.identity);
        bullet.GetComponent<PlayerBullet>().isEnemyBullet = true;
        if (canShoot)
        {
            Invoke("Shoot", Random.Range(1f, 2f));
        }
    }

    void DestroyObject()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Bullet")
        {
            canMove = false;
            if (canShoot)
            {
                canShoot = false;
                CancelInvoke("Shoot");
            }
            anim.Play("enemyExplosion");
            explosionSound.Play();
            Invoke("DestroyObject", 1f);
            FindObjectOfType<Score>().AddScore();
        }
    }
}
