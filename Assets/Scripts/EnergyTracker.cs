using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class EnergyTracker : MonoBehaviour
{
    //get the input field attached to the game object
    private TMP_InputField energyField;
    // Start is called before the first frame update
    void Start()
    {
        energyField = GetComponent<TMP_InputField>();
    }

    public void InitEnergy(float startEnergy)
    {
        energyField.text = startEnergy.ToString();
    }

    private void Update()
    {
        if(!energyField.text.Equals(""))
        SimulationPresets.currentMolecule.SetEnergy(float.Parse(energyField.text));
    }
}
