using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour {

    public GameObject destroyParticles;

    private void OnDestroy()
    {
        Instantiate(destroyParticles, transform.position, destroyParticles.transform.rotation);
    }
}
