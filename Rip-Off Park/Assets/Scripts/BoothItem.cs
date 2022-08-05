using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoothItem : AbsBoothItem
{
    private Rigidbody objectRb;
    private bool isValid;

    public UnityEvent<BoothItem> Item_Invalidated;

    public override void StoreCurrentValues()
    {
        base.StoreCurrentValues();
        if (objectBody != null)
        {
            objectRb = objectBody.GetComponent<Rigidbody>();
        }

    }

    public override void InitValues()
    {
        base.InitValues();
        this.isValid = true; 
    }

    public override void ResetItem()
    {
        ResetPosition();
        // make rigidbody stop moving
        if (objectRb != null)
            objectRb.Sleep();
        if(isValid)
            Debug.Log("Booth item reset: " + gameObject.name);
    }

    public virtual void ValidateItem()
    {
        isValid = true;
    }

    public virtual void InvalidateItem()
    {
        if (IsValid())
        {
            isValid = false;
            Debug.Log("Item Invalidated: " + gameObject.name);
            Item_Invalidated.Invoke(this);
        }
    }

    public bool IsValid()
    {
        return isValid;
    }

  
}
