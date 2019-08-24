using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire;
    public LayerMask NotToHit;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) {
            FireUp();
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            FireDown();
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            FireLeft();
        }

        if(Input.GetKeyDown(KeyCode.RightArrow)) {
            FireRight();
        }
    }
    //Function to fire upwards if arrow up is pressed.
    void FireUp ()
    {
        RaycastHit2D hit = Physics2D.Raycast(fire.position, new Vector2(0,1));

        //add if condition to check if anything was hit.

        if(hit)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().DestroyEnemy();
            }
        }
    }
    //Function to fire downwards if arrow down is pressed.
    void FireDown() {
        RaycastHit2D hit = Physics2D.Raycast(fire.position, new Vector2(0,-1));

        if(hit)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().DestroyEnemy();
            }
        }
    }
    //Function to fire left if arrow left is pressed.
    void FireLeft() {
        RaycastHit2D hit = Physics2D.Raycast(fire.position, new Vector2(-1,0));

        if(hit)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().DestroyEnemy();
            }
        }
    }
    //Function to fire right if arrow right is pressed.
    void FireRight() {
        RaycastHit2D hit = Physics2D.Raycast(fire.position, new Vector2(1, 0));
        if(hit)
        {
            Debug.Log(hit.transform.name);
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().DestroyEnemy();
            }
        }
    }
}
