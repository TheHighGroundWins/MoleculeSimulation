using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class SpeedTracker : MonoBehaviour
{
    //get the input field attached to the game object
    private TMP_InputField speedField;
    // Start is called before the first frame update
    void Start()
    {
        speedField = GetComponent<TMP_InputField>();
    }

    private void Update()
    {
        if(!speedField.text.Equals(""))
        SimulationPresets.speed = (float.Parse(speedField.text));
    }
}
