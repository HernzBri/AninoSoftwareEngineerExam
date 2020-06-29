using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelSpin : MonoBehaviour
{
    private int randVal;
    private float timeInterval;

    [HideInInspector]
    public bool reelStopped;
    public string stoppedReel;
    [HideInInspector]
    public int stoppedID_Top;

    void Start()
    {
        reelStopped = true;
        GameControl.SpinClicked += StartReelSpin;

    }
    public void SPIN()
    {
        
        StartReelSpin();
    }

    private void StartReelSpin()
    {
        stoppedReel = "";
        StartCoroutine("SpinReel");
    }

    private IEnumerator SpinReel()
    {
        reelStopped = false;

        for (int i = 0; i < 30; i++)
        {
            if (transform.position.y <= -3.5f)
                transform.position = new Vector2(transform.position.x, 1.75f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            yield return new WaitForSeconds(timeInterval);
        }

        randVal = Random.Range(60, 100);

        switch (randVal % 3)
        {
            case 1:
                randVal += 2;
                break;

            case 2:
                randVal += 1;
                break;

        }

        for (int i = 0; i < randVal; i++)
        {
            if (transform.position.y <= -3.5f)
                transform.position = new Vector2(transform.position.x, 1.75f);

            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randVal * 0.25f))
                timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randVal * 0.5f))
                timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randVal * 0.75f))
                timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randVal * 0.95f))
                timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }

        // check what icon stopped
        if (transform.position.y == -3.5f)
        {
            stoppedID_Top = 0;
        }
        else if (transform.position.y == -2.75f)
        {
            stoppedID_Top = 1;
        }
        else if (transform.position.y == -2f)
        {
            stoppedID_Top = 2;
        }
        else if (transform.position.y == -1.25f)
        {
            stoppedID_Top = 3;
        }
        else if (transform.position.y == -0.5f)
        {
            stoppedID_Top = 4;
        }
        else if (transform.position.y == 0.25f)
        {
            stoppedID_Top = 5;
        }
        else if (transform.position.y == 1f)
        {
            stoppedID_Top = 6;
        }
        else if (transform.position.y == -1.75f)
        {
            stoppedID_Top = 0;
        }


        reelStopped = true;
        timeInterval = 0f;
    }
}
