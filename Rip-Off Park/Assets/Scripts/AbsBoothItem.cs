using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbsBoothItem : MonoBehaviour
{

    protected Vector3 originalPos;
    protected Quaternion originalRot;

    public GameObject objectBody = null;
    


    void Awake()
    {
        InitializeItem();
        
    }

    public virtual void InitializeItem()
    {
        if (objectBody == null)
        {
            objectBody = gameObject;
        }
        StoreCurrentValues();
    }
    public virtual void StoreCurrentValues()
    {
            originalPos = objectBody.transform.position;
            originalRot = objectBody.transform.rotation;
    }

    protected void ResetPosition()
    {
        objectBody.transform.position = originalPos;
        objectBody.transform.rotation = originalRot;
    }

    public virtual void ResetItem()
    {
        Debug.Log("Item Reset:" + gameObject.name);
        ResetPosition();
    }

    public virtual void GameEnd()
    {
        Debug.Log("Game Ended: " + gameObject.name);
    }

    public virtual void GameStart()
    {
        Debug.Log("Game Started: " + gameObject.name);
    }

    public virtual void InitValues()
    {
        Debug.Log("Initializing values for: " + gameObject.name);
    }



}
