using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballBoothManager : BoothManager
{
    public int basketWorth = 2;
    public AudioClip scoreAudio;
    public void BasketScored()
    {
        if (IsPlaying())
        {
            Debug.Log("Basket was scored");
            IncreaseScore(basketWorth);
        }
        audioSource.PlayOneShot(scoreAudio);
    }

    public override void GameEnd()
    {
        Debug.Log("Score Is: " + GetCurrScore());
        base.GameEnd();
    }
}
