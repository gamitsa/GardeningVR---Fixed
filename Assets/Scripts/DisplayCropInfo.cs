using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayCropInfo : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    [SerializeField] private CropDataSO cropData;
    [SerializeField] private int maxCropCount;
    private int currentCropCount = 0;
    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        if (textMeshPro != null && cropData != null)
        {
            textMeshPro.text = cropData.cropName + "s : " + currentCropCount + "/" + maxCropCount;
        }
        EventManager.instance.OnCropHarvested += OnCropHarvested;
    }

    private void OnCropHarvested(CropDataSO senderCropData)
    {
        if (cropData.Equals(senderCropData) && maxCropCount > currentCropCount)
        {
            if (textMeshPro != null && cropData != null)
            {
                currentCropCount++;
                textMeshPro.text = cropData.cropName + "s : " + currentCropCount + "/" + maxCropCount;
            }
        }
    }
}
