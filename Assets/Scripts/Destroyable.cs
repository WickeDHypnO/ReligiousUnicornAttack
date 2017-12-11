using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Decoy class for detecting destroyable blocks
public class Destroyable : MonoBehaviour {

    public GameObject destroyParticles;

    private void OnDestroy()
    {
        //Spawn rubble after destroying
        Instantiate(destroyParticles, transform.position, destroyParticles.transform.rotation);
    }
}
