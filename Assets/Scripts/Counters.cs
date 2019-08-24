using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This script handles the timers for each counter. It also has the public variable for the current stage,
    namely iOrder. 
*/

public class Counters : MonoBehaviour
{
    private bool bStolen = false;

    public int iOrder = 0;  //Access this for spawning the enemies!

    public float Timers(float fTime)
    {
        if (fTime > 0)
        {
            fTime -= Time.deltaTime;
           // Debug.Log(fTime); This was here for debugging
            return fTime;
        }
        else
        {
            return fTime;
        }
    }

    public void incOrder()
    {
        iOrder++;
    }
    public void decOrder()
    {
        iOrder--;
    }
    public int getOrder()
    {
        return iOrder;
    }

    public void resStolen()
    {
        bStolen = false;
    }

    void Start()
    {
    }

    void Update()
    {
    }

}