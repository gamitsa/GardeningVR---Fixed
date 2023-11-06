using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CropData", menuName = "Custom/Crop Data")]
public class CropDataSO : ScriptableObject
{
    public string cropName;
    public GameObject[] growthStagePrefabs;
    public float[] growthTimes; // Only 2 needed
}
