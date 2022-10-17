using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEditor;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    //save the prefab of the molecule
    private GameObject moleculePrefab;

    //lazy so just set the object from the ui
    [SerializeField] private GameObject energyTrackerObject;
    private EnergyTracker energyTrackerScript;

    private void Start()
    {
        //save reference to the molecule prefab
        moleculePrefab = Resources.Load<GameObject>("Prefabs/Molecule");
        
        energyTrackerScript = energyTrackerObject.GetComponent<EnergyTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        //use a raycast to get the molecule under the mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
        
        //detect a left click on a mouse
        if (Input.GetMouseButtonDown(0))
        {
                //delete the object thats attatched to the collider
                if (hit.collider!=null)
                {
                    MoleculeController molControl = hit.collider.gameObject.transform.parent.gameObject
                        .GetComponent<MoleculeController>();
                    energyTrackerScript.InitEnergy(molControl.GetEnergy());
                    SimulationPresets.currentMolecule = molControl;
                }
        }
        
        //detect a right click on a mouse
        //add or delete a molecule depending on the current mode
        if (Input.GetMouseButtonDown(1))
        {
            if (SimulationPresets.mode == Mode.ADD)
            {
                GameObject moleculeInstance = Instantiate(moleculePrefab);
                //set molecule to the mouse's position
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;
                moleculeInstance.transform.position = mousePos;
            }
            else
            {
                //use a raycast to delete the molecule under the mouse
                
                //delete the object thats attatched to the collider
                if (hit.collider!=null)
                {
                    Destroy(hit.collider.gameObject.transform.parent.gameObject);
                }
            }
        }
    }
}
