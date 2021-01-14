using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] float shotCounter;

    [SerializeField] float minTimeBetweenShots = 0.2f;

    [SerializeField] float maxTimeBetweenShots = 3f;

    [SerializeField] GameObject obstacleBulletPrefab;

    [SerializeField] float obstacleBulletSpeed = 0.3f;

    [SerializeField] float health = 500f;

    [SerializeField] AudioClip ObstacleDeathSound;
    [SerializeField] [Range(0, 1)] float ObstacleDeathSoundVolume = 0.75f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] int scoreValue = 5;

    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();

        ProcessHit(dmgDealer);
    }

    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    private void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {

        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0f)
        {
            ObstacleFire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void ObstacleFire()
    {
        GameObject obstacleBullet = Instantiate(obstacleBulletPrefab, transform.position, Quaternion.identity) as GameObject;

        obstacleBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -obstacleBulletSpeed);
    }

    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();

        AudioSource.PlayClipAtPoint(ObstacleDeathSound, Camera.main.transform.position, ObstacleDeathSoundVolume);

        if (health <= 0)
        {
            Destroyed();
        }
    }

    private void Destroyed()
    {
        Destroy(gameObject);

        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(explosion, explosionDuration);

        FindObjectOfType<GameSession>().AddToScore(scoreValue);
    }
}
