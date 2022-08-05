using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanKnockDownBoothManager : BoothManager
{
    public ItemStackManager ballStack;
    public ItemStackManager canStack;

    public float waitDelay = 2f;

    // Start is called before the first frame update
   
    public override void InitBooth()
    {
        base.InitBooth();
        canStack.Stack_Exhausted.AddListener(DelayedEnd);
        ballStack.Stack_Exhausted.AddListener(DelayedEnd);
    }

    public override void GameStart()
    {
        base.GameStart();
    }
    public override void GameEnd()
    {
        Debug.Log( "Can Knockdown Score is : " + GetCurrScore().ToString());
        base.GameEnd();
        // TEMP - change later to whatever works best
    }

    private void DelayedEnd()
    {
        if (IsPlaying())
            StartCoroutine(WaitForFinish());
    }

    public IEnumerator WaitForFinish()
    {
        // TEMP to see if ended or is stuff still falling
        yield return new WaitForSeconds(waitDelay);
        GameEnd();
    }



}
