using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackIndication : MonoBehaviour {

    //Decalre particles we show when indicating
    public GameObject attackParticles;
    public GameObject attackParticles2;
    public GameObject attackParticles3;
    public List<Transform> attackParticlePoints;
    public List<Transform> attackParticlePoints2;
    public List<Transform> attackParticlePoints3;

    //Show which attack were doing
    public void SpawnAttackParticles()
    {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            Instantiate(attackParticles, attackParticlePoints[1].position, Quaternion.identity);
        }
        else
        {
            Instantiate(attackParticles, attackParticlePoints[0].position, Quaternion.identity);
        }
    }

    //Show which attack were doing
    public void SpawnAttack2Particles()
    {
        Instantiate(attackParticles2, attackParticlePoints2[1].position, Quaternion.identity);
        Instantiate(attackParticles2, attackParticlePoints2[0].position, Quaternion.identity);
    }

    //Show which attack were doing
    public void SpawnAttack3Particles()
    {
        if (GetComponent<SpriteRenderer>().flipX)
        {
            Instantiate(attackParticles3, attackParticlePoints3[1].position, Quaternion.identity);
        }
        else
        {
            Instantiate(attackParticles3, attackParticlePoints3[0].position, Quaternion.identity);
        }
    }
}
