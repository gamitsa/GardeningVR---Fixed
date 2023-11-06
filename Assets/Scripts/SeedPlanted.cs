using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPlanted : MonoBehaviour
{
    [SerializeField] private CropDataSO cropData;
    public CropDataSO GetCropDataSO() { return cropData; }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlanterBox"))
        {
            Destroy(gameObject, 0.1f);
        }
    }
}
