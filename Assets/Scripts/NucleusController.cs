using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NucleusController : MonoBehaviour
{
    //total number of electrons
    private int electrons=0;
    
    //list of electrons within the detected radius
    public Dictionary<int,ElectronInfo> connectedElectrons = new Dictionary<int,ElectronInfo>();
    
    //outer collider
    private Collider2D outerCollider;
    //inner collider
    private Collider2D innerCollider;

    private Rigidbody2D nucleusBody;

    private void Start()
    {
       //save reference to the inner and outer colliders
       int i;

       Collider2D[] localColliders = GetComponentsInChildren<Collider2D>();
       
       //loop and seperate the component in child and in parent
       for (i = 0; i < localColliders.Length; i++)
       {
           if (localColliders[i].tag == "OuterCollider")
           {
               outerCollider = localColliders[i];
           }
           else if (localColliders[i].tag == "InnerCollider")
           {
               innerCollider = localColliders[i];
           }
       }

       //save reference to the rigibody
       nucleusBody = GetComponent<Rigidbody2D>();
    }

    //when an electron is found nearby pull it towards closest point
    private void OnTriggerEnter2D(Collider2D electronCollider)
    {
        //seperate outer and inner colliders
        if (electronCollider.IsTouching(outerCollider) && 
            !electronCollider.IsTouching(innerCollider))
        {
            //add the electron to your dictionary of electrons
            connectedElectrons.Add(
                electronCollider.GetInstanceID(),
                new ElectronInfo(electronCollider.gameObject, true,
                    electronCollider.gameObject.GetComponent<ElectronManager>(),
                    electronCollider.gameObject.GetComponent<Rigidbody2D>()));
            electrons++;
            connectedElectrons[electronCollider.GetInstanceID()].electronManager.power += electrons;
        }
    }
    
    //when an electron is ripped off then remove contact from it
    private void OnTriggerExit2D(Collider2D electronCollider)
    {
        if (electronCollider.IsTouching(GetComponent<Collider2D>()))
        {
            connectedElectrons[electronCollider.GetInstanceID()].electronManager.power -= electrons;
            electrons--;
            //remove the electron from the list of electrons
            connectedElectrons.Remove(electronCollider.GetComponent<Collider>().GetInstanceID());
        }
    }

    // Update is called once per frame
    void Update()
    {
       //keep pulling the electron towards you
       //as long as you have greater power
       int i;
       
       //make a list so that you can loop through the dictionary
       //of electrons
       List<int> electronColliders = new List<int>(connectedElectrons.Keys);

       //do this for every electron in list
       //except for no int the valence shell (add electrons in more inner shells)

    /*
       for (i = 0; i < electronColliders.Count; i++)
       {
           //if our molecule is more electronegative or
           //the electron is lone then pull it towards us
           if (connectedElectrons[electronColliders[i]].electronManager.power < electrons ||
               connectedElectrons[electronColliders[i]].electronManager.power == 1)
           {


               //if the electron is within the outer radius
               if (connectedElectrons[electronColliders[i]].inOuterRadius)
               {
                   connectedElectrons[electronColliders[i]].electronRigidbody.AddForce(new Vector2(
                           (transform.position.x -
                            connectedElectrons[electronColliders[i]].electron.transform.position.x),
                           (transform.position.y -
                            connectedElectrons[electronColliders[i]].electron.transform.position.y))
                       .normalized * 2, ForceMode2D.Force);
               }
           }
           /*
            * if theres a bigger molecule or a molecule with the same
            * electronegativity then move towards in and rotate while doing so
            * also rotate all the connected electrons as well and move them
            * all accordingly as well
            * (maybe only rotate the electrons idk)
            */
            
/*

           else if (connectedElectrons[electronColliders[i]].electronManager.power >
                    electrons - connectedElectrons[electronColliders[i]].electronManager.power)
           {
               //move towards the electron a.k.a bigger molecule
               nucleusBody.AddForce(new Vector2(
                       (connectedElectrons[electronColliders[i]].electron.transform.position.x
                        - transform.position.x),
                       (connectedElectrons[electronColliders[i]].electron.transform.position.y
                        - transform.position.y))
                   .normalized * 2, ForceMode2D.Force);
           }
           
       }*/
    }
}
