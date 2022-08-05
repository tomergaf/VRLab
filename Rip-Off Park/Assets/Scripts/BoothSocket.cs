using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoothSocket : AbsBoothItem
{
    public XRSocketInteractor socket;

   
 
    public override void ResetItem()
    {
        socket.StartManualInteraction((IXRSelectInteractable)socket.startingSelectedInteractable);
    }
}
