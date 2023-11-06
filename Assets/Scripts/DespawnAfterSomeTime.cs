using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnAfterSomeTime : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyObject", 10f);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
