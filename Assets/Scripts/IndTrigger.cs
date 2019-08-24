using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
    This script's purpose is to dictate the individual triggering of the counters. It identifies which counter
    it's attached to and acts accordingly. As there are 3 counters, there are 3 stages of the game. The stage 
    is stored in the Counters script. It also handles detection of the player entering the range of the counters.
    
    The counters are meant to be sequential and each one takes longer than the last. After stealing money from
    each one, the stage goes up by one. Indicating to the rest of the game to spawn more enemies and enable the
    next counter.
 */
public class IndTrigger : MonoBehaviour
{
    public GameObject otherGameObj;

    private Counters crs;

    private bool bEnable;

    private bool bTrig = false;
    public float fCurrentTime; //Left public for debugging
    private bool bNext = true;

    public GameObject player;
    public int countNo;
    public GameObject[] spawns;
    public bool spawned;
    public GameObject enemy;
    public float waitTime;
    public bool locked;
    

    void Start()
    {
        otherGameObj = GameObject.Find("Triggers");

        crs = otherGameObj.GetComponent<Counters>();

        spawned = false;

        waitTime = 100;


        if (gameObject.tag == "Counter1" && crs.getOrder() == 0)
        {
            bEnable = true;
            fCurrentTime = 5.0f;
            bNext = false;
            countNo = 0;

        }
        if (gameObject.tag == "Counter2")
        {
            bEnable = false;
            fCurrentTime = 10.0f;
            bNext = true;
            countNo = 1;
            locked = true;
        }
        if (gameObject.tag == "Counter3")
        {
            bEnable = false;
            fCurrentTime = 15.0f;
            bNext = true;
            countNo = 2;
            locked = true;
        }
    }

    void Update()
    {
        if (bTrig && bEnable && spawned == false)
        {
            for (int i = 0; i < spawns.Length; i++)
            {
                Instantiate(enemy, spawns[i].transform.position, Quaternion.identity);
                Debug.Log("Spawned");
            }

            spawned = true;
        }

        if (bTrig && bEnable)
        {
            fCurrentTime = crs.Timers(fCurrentTime);
            player.GetComponent<UIController>().updateSlider(fCurrentTime, countNo);
        }

        if (fCurrentTime < 0 && !bNext)
        {
            //Debug.Log("Order +1");
            player.GetComponent<UIController>().updateMoney(countNo);
            player.GetComponent<UIController>().updateTimer(countNo);
            bNext = true;
            bNext = true;
            crs.incOrder();
        }

        if (crs.getOrder() == 1 && gameObject.tag == "Counter2" && locked == false)
        {
            bEnable = true;
            bNext = false;
            crs.resStolen();
        }
        if (crs.getOrder() == 2 && gameObject.tag == "Counter3" && locked == false)
        {
            bEnable = true;
            bNext = false;
            crs.resStolen();
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && bEnable)
        {
            bTrig = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && bEnable)
        {
            bTrig = false;
        }
    }

    public void unlock(bool Unl)
    {
        locked = Unl;
    }
}