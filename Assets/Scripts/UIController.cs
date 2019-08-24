using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    public int health;
    public int healthMax;
    public int money;
    public Image[] healthSprites;
    public Text moneyAmount;
    public Sprite medkitEmpty;
    public Sprite medkitFull;
    public Slider[] progressBar;
    public Text timer;
    public float time;
    public GameObject secondCounter;
    public GameObject thirdCounter;
    public int nextToUnlock;

    void Start()
    {
        progressBar[0].gameObject.SetActive(true);
        progressBar[1].gameObject.SetActive(false);
        progressBar[2].gameObject.SetActive(false);
        nextToUnlock = -1;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < healthSprites.Length; i++)
        {
            // Checking to see if health is greater than the max allowed, if so it sets it to the max allowed
            if (health > healthMax)
            {
                health = healthMax;
            }

            // For each element of the array, it checks if the health is greater than the current "i". If health is greater than "i" it means that it needs to show a full med kit for that int of health represented in the array
            if (i < health)
            {
                healthSprites[i].sprite = medkitFull;
            }
            // If "i" is larger than health then it means that portion of health represented in the image array is empty and needs to be represented as so
            else
            {
                healthSprites[i].sprite = medkitEmpty;
            }

            // This is to add more med kit images to the array if needed (the images need to be manually added in the UI editor as well)
            if (i < healthMax)
            {
                healthSprites[i].enabled = true;
            }
            else
            {
                healthSprites[i].enabled = false;
            }

            // Timers used to unlock the next counter
            if (time <= 0 && nextToUnlock == 0)
            {
                secondCounter.gameObject.GetComponent<IndTrigger>().unlock(false);
                time = 0;
            }
            else if (time <= 0 && nextToUnlock == 1)
            {
                thirdCounter.gameObject.GetComponent<IndTrigger>().unlock(false);
                time = 0;
            }
            else if (time > 0)
            {
                time -= Time.deltaTime;
            }
        }

        // Find a way to append later, currently sets the number of total money after the $ sign
        moneyAmount.text = money.ToString();
        timer.text = time.ToString();
    }

    // Damages the player
    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Damaged");
    }

    // Function for adding money or meds to the player, depending on what values were set in the drop
    public void pickupDrop(string type, int amount)
    {
        if (type == "money")
        {
            money += amount;
        }
        if (type == "med")
        {
            health += amount;
        }
    }

    public void updateSlider(float sliderAmount, int sliderNo)
    {
        progressBar[sliderNo].value = sliderAmount;
        if (progressBar[sliderNo].value <= 0)
        {
            progressBar[sliderNo].gameObject.SetActive(false);
            progressBar[sliderNo += 1].gameObject.SetActive(true);
        }
    }

    public void updateMoney(int amount)
    {
        if (amount == 0)
        {
            money += 1000;
        }

        if (amount == 1)
        {
            money += 5000;
        }

        if (amount == 2)
        {
            money += 10000;
        }
    }

    // Timer between unlocking the counters NEEDS ADDITIONAL ENEMY SPAWNING
    public void updateTimer(int unlock)
    {
        time = 100;
        nextToUnlock = unlock;
    }
}
