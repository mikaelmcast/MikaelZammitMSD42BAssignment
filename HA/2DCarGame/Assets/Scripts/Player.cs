﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin, xMax, yMin, yMax;
    float test = 5f;

    [SerializeField] float PlayerMovingSpeed = 10f;

    [SerializeField] float health = 500f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessHit(dmgDealer);
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        if (health <=0)
        {
            Destroyed();
        }
    }

    private void Destroyed()
    {
        Destroy(gameObject);

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(explosion, explosionDuration);

        FindObjectOfType<Level>().LoadGameOver();
    }




    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBounderies();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * PlayerMovingSpeed;

        var newXpos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);

        this.transform.position = new Vector2(newXpos, transform.position.y);
    }

    private void SetUpMoveBounderies()
    {
        Camera worldCamera = Camera.main;

        xMin = worldCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;

        xMax = worldCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        yMin = worldCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;

        yMax = worldCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }
}
