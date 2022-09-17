using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronInfo
{
   //reference to the individial electron
   public GameObject electron;
   //wether or not the electron is in the outer
   //or inner radius
   public bool inOuterRadius = true;
   //reference to the electron manager
   public ElectronManager electronManager;
   //reference to the rigidbody2d of the electron
   public Rigidbody2D electronRigidbody;
   
   //constructor to setup the information of the electron
   //for easy physics management
   public ElectronInfo(GameObject electron, bool inOuterRadius, 
      ElectronManager electronManager, Rigidbody2D electronRigidbody)
   {
      this.electron = electron;
      this.inOuterRadius = inOuterRadius;
      this.electronManager = electronManager;
      this.electronRigidbody = electronRigidbody;
   }
}
