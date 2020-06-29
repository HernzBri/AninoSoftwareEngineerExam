using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using System.Threading;

public class GameControl : MonoBehaviour
{
    public static event Action SpinClicked = delegate { };



    [SerializeField]
    private AudioClip buttonClick;
    [SerializeField]
    private AudioClip buttonError;
    [SerializeField]
    private AudioClip betIncrease;
    [SerializeField]
    private AudioClip betDecrease;
    [SerializeField]
    AudioSource audioSource;

    [SerializeField]
    private TextMeshProUGUI prizeText;
    [SerializeField]
    TextMeshProUGUI betText;

    [SerializeField]
    private ReelSpin[] reelSpins;

    private int prizeValue;
    private int betPool;

    private int[,] row_and_reels = new int [3,5];

    private bool resultsChecked;


    void Start()
    {
        betPool = 5000;
        betText.text = betPool.ToString();
    }
    void Update()
    {
        if(!reelSpins[0].reelStopped || !reelSpins[1].reelStopped || !reelSpins[2].reelStopped || !reelSpins[3].reelStopped || !reelSpins[4].reelStopped)
        {
            prizeValue = 0;
            prizeText.enabled = false;
            resultsChecked = false;
        }

        if (reelSpins[0].reelStopped && reelSpins[1].reelStopped && reelSpins[2].reelStopped && reelSpins[3].reelStopped && reelSpins[4].reelStopped) 
        {
            //check results

            for(int i = 0; i < reelSpins.Length; i++)
            {
                SymbolToArray(i);
            }

            prizeText.enabled = true;
            prizeText.text = "Prize: " + prizeValue;

        }


    }
    public void PlayUIsounds()
    {
        audioSource.Play();
    }
    public void BetMax() 
    {
        betPool = 80000;
        betText.text = betPool.ToString();
        audioSource.clip = betDecrease;
    }
    public void BetChange(bool add)
    {
       
            if (add)
            {
                if (betPool != 80000)
                {
                    betPool += 5000;
                    betText.text = betPool.ToString();
                    audioSource.clip = betIncrease;
                }
                else
                    audioSource.clip = buttonError;
            }
            else
            {
                if (betPool != 5000)
                {
                    betPool -= 5000;
                    betText.text = betPool.ToString();
                    audioSource.clip = betDecrease;
                }
                else
                    audioSource.clip = buttonError;
            }
    }
    public void Spin()
    {
        bool canBclicked = true;
        prizeValue = 0;
        audioSource.clip = buttonClick;
        for (int i = 0; i < reelSpins.Length; i++)
        {
            if (!reelSpins[i].reelStopped)
            {
                canBclicked = false;
                break;
            }
        }

        if(canBclicked)
            SpinClicked();  
        //spin
    }

    public void SymbolToArray(int reel)
    {
        int nextID = reelSpins[reel].stoppedID_Top;
        for (int row = 0; row < 3; row++)
        {
            if (reelSpins[reel].stoppedID_Top == 6 && row == 1) 
            {
                nextID = 0;
            }

            row_and_reels[row , reel] = nextID;
            nextID += 1;
        }
    }

}
