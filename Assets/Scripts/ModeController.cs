using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class ModeController : MonoBehaviour
{
    private TMP_Text buttonText;

    //link the text mesh pro to the text variable
    void Start()
    {
        buttonText = GetComponentInChildren<TMP_Text>();
    }

    //switch the mode to add or delete mode depending on the current state
    //and switch the text to imply so
    public void OnButtonClick()
    {
        if (SimulationPresets.mode == Mode.ADD)
        {
            SimulationPresets.mode = Mode.DELETE;
            buttonText.text = "Delete mode";
        }
        else
        {
            SimulationPresets.mode = Mode.ADD;
            buttonText.text = "Add mode";
        }
    }
}
