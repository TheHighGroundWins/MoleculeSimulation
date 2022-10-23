using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class DefaultEnergyTracker : MonoBehaviour
{
    //get the input field attached to the game object
    private TMP_InputField defaultEnergyField;
    // Start is called before the first frame update
    void Start()
    {
        defaultEnergyField = GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if(!defaultEnergyField.text.Equals(""))
        SimulationPresets.defaultEnergy = (float.Parse(defaultEnergyField.text));
    }
}
