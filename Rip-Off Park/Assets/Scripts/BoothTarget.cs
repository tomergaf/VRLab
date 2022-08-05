using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TargetBehavior))]
public class BoothTarget : AbsBoothItem
{
    private TargetBehavior targetBehavior;

    public override void InitializeItem()
    {
        base.InitializeItem();
        targetBehavior = GetComponent<TargetBehavior>();
    }
    public override void ResetItem()
    {
        base.ResetItem();
        targetBehavior.ResetTargetDown();
    }

    public override void GameEnd()
    {
        base.GameEnd();
        //temporary game end - permanent one will use target method
        targetBehavior.MakeTargetNotReady();
    }

    public override void GameStart()
    {
        base.GameStart();
        targetBehavior.MakeTargetReady();

    }

}
