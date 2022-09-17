using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerCollider : MonoBehaviour
{
    //list of electrons within the detected radius
    public Dictionary<int,ElectronInfo> connectedElectrons = new Dictionary<int,ElectronInfo>();
    
    //reference to our collider
    private Collider2D ourCollider;
    
    // Start is called before the first frame update
    void Start()
    {
        //link the connected electron references to the parent electron references
        connectedElectrons = GetComponentInParent<NucleusController>().connectedElectrons;
        //get reference to the collider
        ourCollider = GetComponent<Collider2D>();
    }

    //disable movement of electrons once they're inside inner circle
    private void OnTriggerEnter2D(Collider2D electronCollider)
    {
        if (electronCollider.IsTouching(ourCollider))
        {
            if (electronCollider.tag == "Electron")
            {
                connectedElectrons[electronCollider.GetInstanceID()].inOuterRadius = false;
                connectedElectrons[electronCollider.GetInstanceID()].electronRigidbody.velocity = Vector2.zero;
            }
        }
    }
    
    //enable movement of electrons once they're outside inner circle
    private void OnTriggerExit2D(Collider2D electronCollider)
    {
        if (electronCollider.IsTouching(GetComponent<Collider2D>()))
        {
            //allow the electron to be able to move again
            if (electronCollider.tag == "Electron")
            {
                connectedElectrons[electronCollider.GetInstanceID()].inOuterRadius = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
