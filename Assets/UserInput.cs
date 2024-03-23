using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public static UserInput instance;

    [HideInInspector] public Default_Inputs default_Inputs;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnEnable()
    {
        default_Inputs.Enable();
    }

    private void OnDisable()
    {
        default_Inputs.Disable();
    }
}
