using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DigProgressUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject child;
    [SerializeField] private DiggingAndPlanting diggingAndPlanting;
    private void Awake()
    {
        slider.maxValue = diggingAndPlanting.digAmountRequired;
    }
    private void Update()
    {
        slider.value = diggingAndPlanting.digAmount;

            if (slider.maxValue == slider.value || slider.value == 0f)
            {
                HideChild();
            }
            else
            {
                ShowChild();
            }
    }
    private void HideChild()
    {
        child.gameObject.SetActive(false);
    }
    private void ShowChild()
    {
        child.gameObject.SetActive(true);
    }
}
