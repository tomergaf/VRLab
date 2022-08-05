using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehavior : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondHand.transform.rotation = (Quaternion.Euler(System.DateTime.Now.Second*6  ,hourHand.transform.rotation.y, 0));
        minuteHand.transform.rotation = (Quaternion.Euler(System.DateTime.Now.Minute*6 , hourHand.transform.rotation.y, 0));
        hourHand.transform.rotation = (Quaternion.Euler(System.DateTime.Now.Hour*30, hourHand.transform.rotation.y, 0));

    }
}
