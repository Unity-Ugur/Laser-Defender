using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private float health = 100;
    [SerializeField] private int scoreValue = 150;
    
    [Header("Shooter")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = -10f;
    
    [Header("Sound Effects")]
    [SerializeField] GameObject explosionSparkles;
    [SerializeField] float durationOfExplosion = 1f;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] [Range(0, 1)] float soundVolume = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != "Shredder" && other.gameObject.name != "Player")
        {
            DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
            ProcessHit(damageDealer);
        }
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        damageDealer.Hit();
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            FindObjectOfType<GameSession>().AddToGameScore(scoreValue);
            GameObject explosion = Instantiate(explosionSparkles, transform.position, transform.rotation);
            Destroy(explosion, durationOfExplosion);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, soundVolume);
        }
    }
}