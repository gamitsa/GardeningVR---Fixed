using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftPrimaryButton : MonoBehaviour
{
    public event EventHandler OnLeftPrimaryButton;
    [SerializeField] private InputActionProperty inputActionReference_PrimaryButton;
    private void OnEnable()
    {
        inputActionReference_PrimaryButton.action.performed += Action_performed;
    }
    private void OnDisable()
    {
        inputActionReference_PrimaryButton.action.performed -= Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        OnLeftPrimaryButton?.Invoke(this, EventArgs.Empty);
    }
}
