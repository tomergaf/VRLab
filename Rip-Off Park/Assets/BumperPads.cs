using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperPads : MonoBehaviour
{
    private HashSet<GameObject> touchingItems = new HashSet<GameObject>();
    private ThrowableBoothItem dummy;

    public float timeoutSecondsStatic=2f;
    public float staticThreshold = 0.5f;
    public float pushForce = 1f;
    [Tooltip("Direction to push in - True for left false for right")]
    public bool direction = false;
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.TryGetComponent<ThrowableBoothItem>(out dummy))
            touchingItems.Add(collision.gameObject);
        StartCoroutine(WaitStaticTime(collision.gameObject));
    }

    private void OnCollisionExit(Collision collision)
    {
        touchingItems.Remove(collision.gameObject);
    }

    public IEnumerator WaitStaticTime(GameObject collidingObject)
    {
        //push ball a bit if static
        yield return new WaitForSeconds(timeoutSecondsStatic);
        if (touchingItems.Contains(collidingObject))
        {
            Rigidbody rb = collidingObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude < staticThreshold)
            {
                if(direction)
                    rb.AddForce(Vector3.back * pushForce, ForceMode.Impulse);
                else
                    rb.AddForce(Vector3.forward * pushForce, ForceMode.Impulse);
            }
                

        }

    }

}
