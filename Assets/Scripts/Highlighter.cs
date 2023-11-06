using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    public LayerMask highlightableLayer;
    public float interactionRange = 10f;
    [SerializeField] private Transform camera_;
    private GameObject currentHighlightedObject;

    void Update()
    {
        // Cast a ray from the camera's position forward
        Ray ray = new Ray(camera_.position, camera_.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, highlightableLayer))
        {
            // Check if the hit object has an Outline component
            GrowthStages growthStages = hit.collider.gameObject.GetComponent<GrowthStages>();
            if (growthStages.currentState == CropState.Stage3)
            {
                growthStages.outline.enabled = true;
                growthStages.instructionsUI.SetActive(true);
                // If there was a previously highlighted object, disable its outline
                if (currentHighlightedObject != null && currentHighlightedObject != growthStages.outline.gameObject)
                {
                    currentHighlightedObject.GetComponent<Outline>().enabled = false;
                    growthStages.instructionsUI.SetActive(false);
                }

                currentHighlightedObject = growthStages.outline.gameObject;
            }
            if (growthStages.currentState != CropState.Stage3)
            {
                growthStages.outline.enabled = false;
                growthStages.instructionsUI.SetActive(false);
            }
        }
        else
        {
            if (currentHighlightedObject != null)
            {
                currentHighlightedObject.GetComponent<Outline>().enabled = false;
                currentHighlightedObject.GetComponent<GrowthStages>().instructionsUI.SetActive(false);
                currentHighlightedObject = null;
            }
        }
    }
}
