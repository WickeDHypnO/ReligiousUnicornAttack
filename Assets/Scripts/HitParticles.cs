using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour {

    public GameObject hitParticles;

    private void OnDestroy()
    {
        //Spawn self-destroying particles after hit
        Instantiate(hitParticles, transform.position, hitParticles.transform.rotation);
    }
}
