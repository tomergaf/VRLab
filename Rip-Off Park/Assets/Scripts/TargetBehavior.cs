using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(HingeJoint))]
public class TargetBehavior : MonoBehaviour
{
    public ShootingRangeBoothManager manager;
    public GameObject rail;

    private AudioSource audioSource;
    
    public Collider baseCollider;
    public Collider targetCollider;

    private HingeJoint hinge;

    private bool wasHit = false;
    private bool isReady = false;

    public float rotateSpeed;
    public float rotateForce;
    public float targetPoints;
    public float foldDelay = 1f;

    public float moveSpeed;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        hinge = GetComponent<HingeJoint>();
        
    }

    void Start()
    {
        Debug.Log("Folding target on start: " + gameObject.name);
        FoldTarget();
    }

    public void MakeTargetReady()
    {
        InitValues();
        SetReadyTrue();
        UnFoldTarget();
    }

    public void MakeTargetNotReady()
    {
        SetReady(false);
        FoldTarget();
    }

    public void InitValues()
    {
        // will init other valus important for start
        isReady = true;
        wasHit = false;
    }
    public void TargetHit()
    {
        wasHit = true;
        manager.TargetHit(this);
        audioSource.Play();
        MakeTargetNotReady();

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Projectile" & isReady)
        {
            Debug.Log("Target hit: " + gameObject.name);
            TargetHit();
        }
        else Debug.Log("Target  hit not projectile or hit while not ready: " + gameObject.name);
    }

    private void FoldTarget()
    {
        SetMotor(true);
        hinge.useMotor = true;
    }
    private void UnFoldTarget()
    {
        SetMotor(false);
        hinge.useMotor = true ;
    }

    private void SetMotor(bool direction)
    {
        // sets the motor to use on the target
        float directionVal = direction ? 1 : -1; 
        JointMotor jointMotor = new JointMotor();
        jointMotor.targetVelocity = rotateSpeed * directionVal;
        jointMotor.force = rotateForce;
        hinge.motor = jointMotor;
    }

    private void SetColliders(bool value)
    {
        if (baseCollider.enabled == targetCollider.enabled)
        {
            baseCollider.enabled = value;
            targetCollider.enabled = value;
        }
        else
        {
            Debug.Log("Warning - Colliders in target: " + gameObject.name + " are mismatched");
        }

    }

    private void SetReady(bool readiness)
    {
        isReady = readiness;
        wasHit = !readiness;
        SetColliders(readiness);
    }

    private void SetReadyTrue()
    {
        SetReady(true);
    }

    public void ResetTargetUp()
    {
        // REMOVE - for debugging only
        UnFoldTarget();
        Invoke("SetReadyTrue", foldDelay);

    }

    public void ResetTargetDown()
    {
        MakeTargetNotReady();
    }

    public void RepositionAndWait()
    {
        // this makes the target move to an end while folded' and wait for the manager to instruct moving

    }

    public void EndReached()
    {
        //this lets the target know when its reached the end of the rail
    }

    
}
