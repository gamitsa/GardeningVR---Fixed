using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

interface IInteractable
{
    public void Interact();
}

public class RightPrimaryButton : MonoBehaviour
{
    public Transform camera_;
    [SerializeField] private InputActionProperty inputActionReference_PrimaryButton;
    private void OnEnable()
    {
        inputActionReference_PrimaryButton.action.performed += OnPrimaryButton;
    }
    private void OnDisable()
    {
        inputActionReference_PrimaryButton.action.performed -= OnPrimaryButton;
    }
    private void OnPrimaryButton(InputAction.CallbackContext obj)
    {
        Ray ray = new Ray(camera_.position, camera_.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
            {
                interactable.Interact();
            }
        }
    }
}
