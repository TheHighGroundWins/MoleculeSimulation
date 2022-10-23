using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public static class SimulationPresets 
{
    public static Mode mode = Mode.ADD;
    //keeps track of the current molecule
    public static MoleculeController currentMolecule;
    
    //speed for all the molecule to make it easier for experiments
    public static float speed = 10;

    public static float defaultEnergy = 5;
}
