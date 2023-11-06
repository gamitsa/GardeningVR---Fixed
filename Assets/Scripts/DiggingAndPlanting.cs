using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public enum PlanterBoxState
{
    Undigged,
    Digged,
    Planted
}
public class DiggingAndPlanting : MonoBehaviour
{
    public PlanterBoxState currentState = PlanterBoxState.Undigged;
    public int digAmountRequired = 10;
    public int digAmount = 0;
    [SerializeField] private GameObject planterBoxUndigged;
    [SerializeField] private GameObject planterBoxDigged;
    [SerializeField] private GameObject planterBoxPlanted;
    private void Start()
    {
        planterBoxUndigged.SetActive(true);
        planterBoxDigged.SetActive(false);
        planterBoxPlanted.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shovel") && currentState == PlanterBoxState.Undigged)
        {
            digAmount++;
            if (digAmount >= digAmountRequired)
            {
                currentState = PlanterBoxState.Digged;
                Debug.Log("Digged");
            }
        }
        else if (collision.gameObject.CompareTag("Seed") && currentState == PlanterBoxState.Digged)
        {
            currentState = PlanterBoxState.Planted;
            Debug.Log("Planted");
        }
    }

    private void Update()
    {
        switch (currentState)
        {
            case PlanterBoxState.Undigged:
                planterBoxUndigged.SetActive(true);
                planterBoxDigged.SetActive(false);
                planterBoxPlanted.SetActive(false);
                break;
            case PlanterBoxState.Digged:
                planterBoxDigged.SetActive(true);
                planterBoxUndigged.SetActive(false);
                planterBoxPlanted.SetActive(false);
                break;
            case PlanterBoxState.Planted:
                planterBoxUndigged.SetActive(false);
                planterBoxDigged.SetActive(false);
                planterBoxPlanted.SetActive(true);
                break;
        }
    }
}
