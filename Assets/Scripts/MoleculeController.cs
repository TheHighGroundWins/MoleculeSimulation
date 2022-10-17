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

    [SerializeField]
    private float energy = 5f;
    
    [SerializeField]
    private float electronPush = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //counter for seperating colliders
        int i = 0;
        CircleCollider2D[] colliders = GetComponentsInChildren<CircleCollider2D>();
        for (i = 0; i < colliders.Length; i++)
        {
            //seperate the two colliders in order to differentiate collision
            if (colliders[i].tag == "Nucleus")
            {
                nucleusCollider = colliders[i];
            }

            if (colliders[i].tag == "Electron")
            {
                electronCollider = colliders[i];
            }
        }

    }
    
    //get and set functions
    public float GetEnergy()
    {
        return energy;
    }

    public void SetEnergy(float energy)
    {
        this.energy=energy;
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
     * Van der Waals:
     * 1/half the distance between two molecule
     * (always attraction of inverse distance)
     *
     * electron:
     * just push any electrons
     * (always repulsive)
     */

    private void OnTriggerEnter2D(Collider2D moleculeCollider2D)
    {
        MoleculeBehavior(moleculeCollider2D);
    }
    
    void OnTriggerStay2D(Collider2D moleculeCollider)
    {
        MoleculeBehavior(moleculeCollider);
    }
    

    void MoleculeBehavior(Collider2D moleculeCollider)
    {
        //get difference between the two positions and normalize them
        Vector2 direction = (transform.position - moleculeCollider.transform.position).normalized;

        //variable to hold distance between two point
        float distance = 0;
        
        //coulombic and van der waals reaction
        if (moleculeCollider.IsTouching(nucleusCollider) && 
            !moleculeCollider.IsTouching(electronCollider) && moleculeCollider.tag=="Nucleus")
        {
            //calculate the absolute value distance between two points
            distance = Vector2.Distance(moleculeCollider.transform.position, transform.position);

            //coulombic
            moleculeCollider.GetComponent<Rigidbody2D>().AddForce
                (SimulationPresets.temp*direction*((energy*
              nucleusCollider.GetComponent<MoleculeController>().GetEnergy()) /distance));
          
          
            
            //van der waals
            moleculeCollider.GetComponent<Rigidbody2D>().AddForce
                (SimulationPresets.temp*direction*(-1/(distance/2)));

        }
        
        
        //electron reaction
        if (moleculeCollider.tag == "Electron" && moleculeCollider.IsTouching(electronCollider))
        {
            //repulsive/push force
            moleculeCollider.GetComponentInParent<Rigidbody2D>().AddForce(SimulationPresets.temp*direction*-electronPush); 
        }
    }
}
