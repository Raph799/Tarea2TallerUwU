using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 5f;
    public float fireRate = 1f;
    public float bulletLifetime = 5f;

    private Transform player;
    private float nextFireTime;

    void Start()
    {
        FindPlayer();
    }

    void Update()
    {

        FindPlayer();

        if (player == null)
            return;

        Vector2 direction = (player.position - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 180;

        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = direction * bulletSpeed;
            Destroy(bullet, bulletLifetime);
        }
    }

    void FindPlayer()
    {
        // Buscar el objeto con el tag "Human"
        player = GameObject.FindGameObjectWithTag("Human").transform;

        // Si no se encuentra el objeto con el tag "Human", buscar el objeto con el tag "Plane"
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Plane").transform;

        // Si no se encuentra el objeto con el tag "Plane", buscar el objeto con el tag "Ship"
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Ship").transform;

        // Si no se encuentra el objeto con el tag "Ship", buscar el objeto con el tag "Ball"
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Ball").transform;
    }
}
