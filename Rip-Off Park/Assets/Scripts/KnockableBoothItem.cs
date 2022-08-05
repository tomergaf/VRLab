using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockableBoothItem : BoothItem
{
    public override void InitValues()
    {
        base.InitValues();
        ValidateItem();
    }
    private void OnTriggerEnter(Collider other)
    {
        // TEMP make a safelist later
        string colliderTag = other.gameObject.tag;
        if (colliderTag != "ThrowableTarget" && colliderTag != "ThrowableObject")
        {
            InvalidateItem();
        }
    }
}
