using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager instance;
    private void Awake()
    {
        instance = this;
    }
    public event Action<CropDataSO> OnCropHarvested;
    public void TriggerHarvestEvent(CropDataSO cropData)
    {
        OnCropHarvested?.Invoke(cropData);
    }
}
