using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AbsBoothManager : MonoBehaviour
{
    public UnityEvent On_Reset_Pressed;

    public virtual void ResetPressed()
    {
        Debug.Log("reset pressed");
        On_Reset_Pressed.Invoke();
    }

    public virtual void StartRound()
    {
        Debug.Log("Round Starting");
    }
}
