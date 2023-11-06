using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToBrokenDependingOnVelocity : MonoBehaviour
{
    public float activationThreshold = 2f;
    public GameObject brokenObject;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float relativeVelocity = collision.relativeVelocity.magnitude;
        if (relativeVelocity > activationThreshold*1.5f)
        {
            SetToBroken();
        }
        if (rb.velocity.magnitude > activationThreshold)
        {
            SetToBroken();
        }
    }

    public void SetToBroken()
    {
        if (brokenObject != null)
        {
            brokenObject.transform.parent = null;
            brokenObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}