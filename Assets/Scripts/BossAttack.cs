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
    public float attackDelay = 4f;
    public float gracePeriod = 1.5f;
    private int attack = 0;

    private void Start()
    {
        //Set attack to random, so we don't always start with the same attack
        attack = Random.Range(0, 2);
    }

    //Start attack couroutine
    public void StartAttacking()
    {
        StartCoroutine(ContinuousAttack());
    }

    //Stop all attacks
    public void StopAttack()
    {
        StopAllCoroutines();
    }

    //Main attack couroutine
    private IEnumerator ContinuousAttack()
    {
        while (true)
        {
            //Wait till can attack
            yield return new WaitForSeconds(attackDelay);

            //Choose attack, never choose the same twice
            if (attack == 0)
            {
                attack = Random.Range(1, 3);
            }
            else if (attack == 2)
            {
                attack = Random.Range(0, 2);
            }
            else
            {
                attack = Random.Range(0, 2) == 0 ? 0 : 2;
            }

            //Lets attack!
            if (attack == 0)
            {
                GetComponent<BossAnimation>().StartAttackAnimation(0);
                GetComponent<BossAttackIndication>().SpawnAttack2Particles();
                yield return new WaitForSeconds(gracePeriod);
                AttackFire();
                GetComponent<BossAnimation>().PlayIdleAnimation();
            }
            else if (attack == 1)
            {
                //Choose random side form which attack will be shot
                int rand = Random.Range(0, 2);
                GetComponent<BossAnimation>().StartAttackAnimation(attack + rand);
                GetComponent<BossAttackIndication>().SpawnAttackParticles();
                yield return new WaitForSeconds(gracePeriod);
                if (rand == 0) AttackRight(); else AttackLeft();
            }
            else
            {
                //Choose random side form which attack will be shot, we use 3 and 4 for better passing 
                //variable to animation method
                int rand = Random.Range(3, 5);
                GetComponent<BossAnimation>().StartAttackAnimation(rand);
                GetComponent<BossAttackIndication>().SpawnAttack3Particles();
                yield return new WaitForSeconds(gracePeriod);
                if (rand == 3) Attack3Right(); else Attack3Left();
                GetComponent<BossAnimation>().PlayIdleAnimation();
            }
        }
    }

    //Block of methos used for spawning attacks

    private void AttackLeft()
    {
        foreach (Transform t in LeftAttackPoints)
        {
            Instantiate(AttackParticle, t.position, AttackParticle.transform.rotation);
        }
    }

    private void AttackRight()
    {
        foreach (Transform t in RightAttackPoints)
        {
            Instantiate(AttackParticle, t.position, AttackParticle.transform.rotation);
        }
    }

    private void AttackFire()
    {
        FireAttack.Play();
    }

    private void Attack3Left()
    {
        foreach (Transform t in LeftAttackPoints3)
        {
            Instantiate(AttackParticle3, t.position, Quaternion.Euler(90, 0, 0));
        }
    }

    private void Attack3Right()
    {
        foreach (Transform t in RightAttackPoints3)
        {
            Instantiate(AttackParticle3, t.position, Quaternion.Euler(90, 0, 180));
        }
    }
}
