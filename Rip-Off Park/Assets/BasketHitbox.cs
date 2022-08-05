using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketHitbox : MonoBehaviour
{
    public BasketballBoothManager boothManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Item thrown in basket: " + other.gameObject.name);
        ThrowableBoothItem throwable = other.gameObject.GetComponentInParent<ThrowableBoothItem>();
        if (throwable != null)
        {
            Debug.Log("Throwable thrown in basket: " + other.gameObject.name + "prime state is: " + throwable.IsPrimed().ToString()) ;
            if (throwable.IsPrimed())
            {
                boothManager.BasketScored();
                throwable.setPrimed(false);
            }
        }
        
    }

}
