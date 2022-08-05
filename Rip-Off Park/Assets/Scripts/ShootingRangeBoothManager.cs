using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRangeBoothManager : BoothManager
{
    public override void InitBooth()
    {
        base.InitBooth();
        ResetPressed();
    }
    public void TargetHit(TargetBehavior target)
    {
        Debug.Log("target: " + target.gameObject.name +" was hit");
        IncreaseScore(target.targetPoints);
        //will later use repositionandwait
        //temp invoke delayed to reset
        StartCoroutine(PrepareTarget(target));
    }

    public IEnumerator PrepareTarget(TargetBehavior targetBehavior)
    {
        //temp delay 
        float delay = 2f;
        yield return new WaitForSeconds(delay);
        Debug.Log("resetting target");
        targetBehavior.MakeTargetReady();
    }

    public override void GameEnd()
    {
        // stops all coroutines , saves score and iniitializes it
        Debug.Log("Score is : " +  GetCurrScore().ToString());
        base.GameEnd();
    }
}
