using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordRotate : MonoBehaviour
{
    public bool yAxis;
    public bool xAxis;
    public bool zAxis;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(speed * (xAxis ? 1: 0) * Time.deltaTime, speed * (yAxis ? 1 : 0) * Time.deltaTime, speed * (zAxis ? 1 : 0) * Time.deltaTime));
    }

    public void ToggleStartStop()
    {
        if (this.enabled)
            this.enabled = false;
        else this.enabled = true; ;
    }
}
