using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleculeController : MonoBehaviour
{
    //pulls and pushes
    private CircleCollider2D nucleusCollider;
    //repels
    private CircleCollider2D electronCollider;

    // Start is called before the first frame update
    void Start()
    {
        //counter for seperating colliders
        int i = 0;
        CircleCollider2D[] colliders = GetComponentsInChildren<CircleCollider2D>();
        for (i = 0; i < colliders.Length; i++)
        {
            //seperate the two colliders in order to differentiate collision
            if (colliders[i].name == "Nucleus")
            {
                nucleusCollider = colliders[i];
            }

            if (colliders[i].name == "Electron")
            {
                electronCollider = colliders[i];
            }
        }

    }
    
    /*
     * for both of these
     * theres 3 different attractions
     * Coulumbic
     * Van der Vals
     * and electron
     *
     * Coulombic:
     * product of the two molecule energies over distance between them
     * (can be be attractive or repulsive force)
     *
     * Van der Vals:
     * 1/half the distance between two molecule
     * (always attraction of inverse distance)
     *
     * electron:
     * just push any electrons
     * (always repulsive)
     */

    private void OnTriggerEnter2D(Collider2D moleCollider2D)
    {
    }
    
    void OnTriggerStay2D(Collider2D moleculeCollider)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
