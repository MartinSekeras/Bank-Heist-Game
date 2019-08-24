using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float projectileSpeed;
    public int damage;
    private Transform playerPos;
    private Vector2 target;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        // Gets the targeting infomation form the player. This value will not change
        target = new Vector2(playerPos.position.x, playerPos.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Projectile moves towards the set target location. Replace "Target" with playerPos.position to add tracking
        transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);

        // Calls when the position of the projectile matches the target position
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
    }

    void OnTriggerEnter2D(Collider2D Player)
    {
        // If it hits the player, it will refrence the player health script and subtract an amount of damage
        if (Player.CompareTag("Player"))
        {
            Player.GetComponent<UIController>().takeDamage(1);
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
