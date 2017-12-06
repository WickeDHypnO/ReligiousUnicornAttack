using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticles : MonoBehaviour {

    public GameObject hitParticles;

    private void OnDestroy()
    {
        Instantiate(hitParticles, transform.position, hitParticles.transform.rotation);
    }
}
