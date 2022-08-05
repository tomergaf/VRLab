using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class ThrowableBoothItem : BoothItem
{
    private bool wasPickedUp;
    private bool isPrimed;
    public bool revalidateOnPickup = false;

    public HashSet<string> safeList = new HashSet<string>();

    private void Start()
    {
        safeList.Add("Counter");
        safeList.Add("ThrowableObject");
        safeList.Add("ThrowableTarget");
        safeList.Add("Player");
    }

    public override void InitializeItem()
    {
        base.InitializeItem();
        wasPickedUp = false;
        isPrimed = false;
    }

    public void WasPickedUp()
    {
        if (revalidateOnPickup) {
            if (!IsValid())
                ValidateItem();
        }
        Debug.Log("Item was picked up: " + gameObject.name);
        wasPickedUp = true;
    }

    public void WasLetGo()
    {
        Debug.Log("Item was let go: " + gameObject.name);
        if (wasPickedUp && IsValid())
            isPrimed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // TEMP later make a safelist
        string collisionTag = collision.gameObject.tag;
        if (!safeList.Contains(collisionTag))
            InvalidateItem();
        if(IsValid() && isPrimed && tag=="ThrowableTarget")
        {
            HitTarget(collision.gameObject);
        }
    }

    public virtual void HitTarget(GameObject hitObject)
    {
        Debug.Log("Throwable: " + gameObject.name + " hit: " + hitObject.name);
    }

    public bool IsPrimed()
    {
        return isPrimed;
    }

    public void setPrimed(bool value)
    {
        isPrimed = value;
    }

}
