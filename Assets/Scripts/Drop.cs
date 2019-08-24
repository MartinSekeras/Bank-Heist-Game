using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public int value;
    public SpriteRenderer sprite;
    public Sprite small, medium, big, medKit;

    // Start is called before the first frame update
    void Start()
    {
        value = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {
        // Script compares the value of the drop, and assignes the appropiate sprite to represent it's value
        if (value < 40)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = small;
        }
        else if (value < 70 && value >= 40)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = medium;
        }
        else if (value < 90 && value >= 70)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = big;
        }
        else if (value <= 100 && value >= 90)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = medKit;
        }
    }

    void OnTriggerEnter2D(Collider2D Player)
    {
        // When the player picks up the drop, it send the relevant info to the player so the game knows what to add to the health/ score
        if (Player.CompareTag("Player"))
        {
            if (value < 40)
            {
                Player.GetComponent<UIController>().pickupDrop("money", 10);
                Destroy(gameObject);
            }
            else if (value < 70 && value >= 40)
            {
                Player.GetComponent<UIController>().pickupDrop("money", 50);
                Destroy(gameObject);
            }
            else if (value < 90 && value >= 70)
            {
                Player.GetComponent<UIController>().pickupDrop("money", 100);
                Destroy(gameObject);
            }
            else if (value <=100 && value >= 90)
            {
                Player.GetComponent<UIController>().pickupDrop("med", 1);
                Destroy(gameObject);
            }
        }
    }
}