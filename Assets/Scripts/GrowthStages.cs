using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
public enum CropState
{
Stage0,
Stage1,
Stage2,
Stage3
}

public class GrowthStages : MonoBehaviour, IInteractable
{
    private CropDataSO cropData;
    [SerializeField] private Transform spawnPoint;
    [HideInInspector] public CropState currentState = CropState.Stage0;
    private DiggingAndPlanting diggingAndPlanting;
    private bool cropPlanted = false;
    private int currentGrowthStage = 0;
    private GameObject currentGrowthStageObject;
    [HideInInspector] public Outline outline;
    public GameObject instructionsUI;
    private void Start()
    {
        Stage0();
        diggingAndPlanting = gameObject.GetComponent<DiggingAndPlanting>();
        outline = gameObject.GetComponent<Outline>();
        outline.enabled = false; 
        instructionsUI.SetActive(false);
    }

    void IInteractable.Interact()
    {
        if (currentState == CropState.Stage3)
        {
            Harvest();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (diggingAndPlanting.currentState == PlanterBoxState.Planted && currentState == CropState.Stage0 || diggingAndPlanting.currentState == PlanterBoxState.Digged && currentState == CropState.Stage0)
        {
            if(collision.gameObject.GetComponent<SeedPlanted>() != null)
            {
                cropData = collision.gameObject.GetComponent<SeedPlanted>().GetCropDataSO();
                PlantCrop();
            }
        }
    }
    private void PlantCrop()
    {
        Debug.Log(cropData.cropName + " planted!");
        cropPlanted = true;
        currentGrowthStage = 0;
        currentState = CropState.Stage1;
        InstantiateGrowthStage(cropData.growthStagePrefabs[currentGrowthStage]);
        StartCoroutine(GrowToNextStage(cropData));
    }
    private IEnumerator GrowToNextStage(CropDataSO cropData)
    {
        yield return new WaitForSeconds(cropData.growthTimes[currentGrowthStage]);

        if (cropPlanted)
        {

            currentGrowthStage++;

            if (currentGrowthStage < cropData.growthStagePrefabs.Length)
            {
                InstantiateGrowthStage(cropData.growthStagePrefabs[currentGrowthStage]);
                StartCoroutine(GrowToNextStage(cropData));
            }
            else
            {
                currentState = CropState.Stage3;
            }
        }
    }
    private void InstantiateGrowthStage(GameObject prefab)
    {
        if (currentGrowthStageObject != null)
        {
            Destroy(currentGrowthStageObject);
        }

        currentGrowthStageObject = Instantiate(prefab, spawnPoint);
        currentGrowthStageObject.SetActive(true);
    }
    private void Stage0()
    {
        instructionsUI.SetActive(false);
        currentState = CropState.Stage0;

        // Destroy all existing growth stage GameObjects
        foreach (Transform child in spawnPoint)
        {
            Destroy(child.gameObject);
        }
        currentGrowthStage = 0;
    }

    private void Harvest()
    {

        Debug.Log("Harvested!");
        EventManager.instance.TriggerHarvestEvent(cropData);
        diggingAndPlanting.currentState = PlanterBoxState.Digged;
        cropPlanted = false;
        Stage0();
    }
}
