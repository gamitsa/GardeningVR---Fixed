using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UISwitcherActivate : MonoBehaviour
{
    [SerializeField] private InputActionProperty inputActionReference_UISwitcher;
    //[SerializeField] private GameObject UIObject;
    private void Awake()
    {
        //UIObject.SetActive(false);
    }
    private bool UIActive = false;
    private void OnEnable()
    {
        inputActionReference_UISwitcher.action.performed += OnUISwitcher;
    }
    private void OnDisable()
    {
        inputActionReference_UISwitcher.action.performed -= OnUISwitcher;
    }
    private void OnUISwitcher(InputAction.CallbackContext obj)
    {
/*        if (UIActive)
        {
            UIObject.SetActive(false);
            UIActive = false;
        }
        else
        {
            UIObject.SetActive(true);
            UIActive = true;
        }*/
    }
}
