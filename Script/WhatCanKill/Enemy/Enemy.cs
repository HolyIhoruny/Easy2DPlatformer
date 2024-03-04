using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 5;

    public float walkSpeed, range /*timeBTWShots, shootSpeed*/;
    private float distToPlayer;

    public bool mustPatrol;
    private bool mustTurn /*canShoot*/;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;
    public Transform player /*shootPos*/;
    //public GameObject bullet;


    void Start()
    {
        mustPatrol = true;
        //canShoot = true;
    }

    void Update()
    {
        if (hp < 0)
        {
            Destroy(gameObject);
        }

        if (mustPatrol)
        {
            Patrol();
        }

        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= range)
        {
            if (player.position.x > transform.position.x && transform.localScale.x < 0
                || player.position.x < transform.position.x && transform.localScale.x > 0)
            {
                Flip();
            }

            mustPatrol = false;
            rb.velocity = Vector2.zero;

            //if (canShoot)
            //    StartCoroutine(Shoot());

        }

        else
        {
            mustPatrol = true;
        }
    }

    private void FixedUpdate()
    {
        mustTurn = !Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

    }

    void Patrol()
    {
        if (mustTurn || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            hp -= 2;
        }

        if (collision.CompareTag("Player"))
        {
            Health.health -= 1;
        }

    }
    //IEnumerator Shoot()
    //{
    //    canShoot = false;
    //    yield return new WaitForSeconds(timeBTWShots);
    //    GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);

    //    newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * walkSpeed * Time.fixedDeltaTime, 0f);
    //    canShoot = true;

    //}
}


