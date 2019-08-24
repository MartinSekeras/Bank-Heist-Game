using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform playerPos;
    public float speed;
    public float rateOfFireReset;
    private Animator animator;
    private float rateOfFire;
    public GameObject projectile;
    public GameObject Drop;
    public string EnemyType;

    public Sprite Up_Sprite;
    public Sprite Down_Sprite;
    public Sprite Left_Sprite;
    public Sprite Right_Sprite;
    public Sprite Idle_Sprite;


    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        rateOfFire = rateOfFireReset;
    }

    // Update is called once per frame
    void Update()
    {
        // This handeles the enemy movement. It checks if the player is more than 10 units away, if it is it will move towards them.
        if (Vector2.Distance(transform.position, playerPos.position) > 0.2)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            // Multiplying 2 by deltatime will stop higher processing computers moving the enemy faster in runtime
        }
        else if (Vector2.Distance(transform.position, playerPos.position) < 0.2)
        {
            // Stops the enemy from moving
            transform.position = this.transform.position;
        }

        // This part handeles the shooting
        if (rateOfFire <= 0 && Vector2.Distance(transform.position, playerPos.position) < 0.5)
        {
            // Instantiate is being used to spawn a gameobject, Quaternion spawns it with no assigned rotation
            Instantiate(projectile, transform.position, Quaternion.identity);
            rateOfFire = rateOfFireReset;
        }
        else
        {
            // We are using deltatime instead of 1, again to keep the timing consistant accross hardware
            rateOfFire -= Time.deltaTime;
        }
    }

    // This is used to destroy the Enemy
    public void DestroyEnemy()
    {
        //Spawns money for the player to collect then destroys the enemy
        Instantiate(Drop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
