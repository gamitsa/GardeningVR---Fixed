using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinousSound : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
