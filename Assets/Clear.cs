using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{

    public void OnClick()
    {
        int i;
        GameObject[] allMolecules = GameObject.FindGameObjectsWithTag("Nucleus");
        for(i=0; i< allMolecules.Length; i++)
        {
            Destroy(allMolecules[i]);
        }
    }
}
