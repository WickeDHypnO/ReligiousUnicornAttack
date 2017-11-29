using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{

    public List<Transform> LeftAttackPoints;
    public List<Transform> RightAttackPoints;
    public List<Transform> LeftAttackPoints3;
    public List<Transform> RightAttackPoints3;
    public ParticleSystem FireAttack;
    public GameObject AttackParticle;
    public GameObject AttackParticle3;

    public void Attack()
    {
        int side = Random.Range(0, 2);
        if (side == 0) AttackLeft(); else AttackRight();
    }

    public void AttackLeft()
    {
        foreach (Transform t in LeftAttackPoints)
        {
            Instantiate(AttackParticle, t.position, AttackParticle.transform.rotation);
        }
    }

    public void AttackRight()
    {
        foreach (Transform t in RightAttackPoints)
        {
            Instantiate(AttackParticle, t.position, AttackParticle.transform.rotation);
        }
    }

    public void AttackFire()
    {
        FireAttack.Play();
    }

    public void Attack3Left()
    {
        foreach (Transform t in LeftAttackPoints3)
        {
            Instantiate(AttackParticle3, t.position, Quaternion.Euler(90, 0, 0));
        }
    }

    public void Attack3Right()
    {
        foreach (Transform t in RightAttackPoints3)
        {
            Instantiate(AttackParticle3, t.position, Quaternion.Euler(90, 0, 180));
        }
    }
}
