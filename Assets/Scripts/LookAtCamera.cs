using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private GameObject thisGameObject;
    public Transform head;

    private void Start()
    {
        thisGameObject = gameObject;
    }
    private void Update()
    {
        thisGameObject.transform.LookAt(new Vector3(head.position.x, thisGameObject.transform.position.y, head.position.z));
        thisGameObject.transform.forward *= -1;
    }
}