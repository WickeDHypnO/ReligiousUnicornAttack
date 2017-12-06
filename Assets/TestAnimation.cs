using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimation : MonoBehaviour
{

    public float defaultHeight;
    public float risingSpeed;
    float startPosition;
    float timer;
    public GameObject attackParticles;
    public GameObject attackParticles2;
    public GameObject attackParticles3;
    public List<Transform> attackParticlePoints;
    public List<Transform> attackParticlePoints2;
    public List<Transform> attackParticlePoints3;
    int atk;
    bool startedAttacking;
    public float attackDelay = 4f;
    public float gracePeriod = 1.5f;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position.y;
        atk = Random.Range(0, 2);
    }

    public void StopAttack()
    {
        StopAllCoroutines();
    }

    public void Update()
    {
        if (!startedAttacking)
        {
            if (!GetComponentInChildren<AudioSource>().isPlaying)
            GetComponentInChildren<AudioSource>().Play();
            timer += Time.deltaTime * risingSpeed;
            transform.position = Vector3.Lerp(new Vector3(0, startPosition, 1), new Vector3(0, defaultHeight, 1), timer);
            if (transform.position.y >= defaultHeight)
            {
                startedAttacking = true;
                StartCoroutine(Attack());
                GetComponentInChildren<AudioSource>().Stop();
            }
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);
            if (atk == 0)
            {
                atk = Random.Range(1, 3);
            }
            else if (atk == 2)
            {
                atk = Random.Range(0, 2);
            }
            else
            {
                atk = Random.Range(0, 2) == 0 ? 0 : 2;
            }

            if (atk == 0)
            {
                GetComponent<Animator>().Play("BossAttack2", 0);
                SpawnAttack2Particles();
                yield return new WaitForSeconds(gracePeriod);
                GetComponent<BossAttack>().AttackFire();
                GetComponent<Animator>().Play("Idle", 0);
            }
            else if (atk == 1)
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                GetComponent<Animator>().Play("BossAttack", 0);
                SpawnAttackParticles();
                yield return new WaitForSeconds(gracePeriod);
                if (rand == 0) GetComponent<BossAttack>().AttackRight(); else GetComponent<BossAttack>().AttackLeft();

            }
            else
            {
                int rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    GetComponent<SpriteRenderer>().flipX = true;
                }
                else
                {
                    GetComponent<SpriteRenderer>().flipX = false;
                }
                GetComponent<Animator>().Play("BossAttack3", 0);
                SpawnAttack3Particles();
                yield return new WaitForSeconds(gracePeriod);
                if (rand == 0) GetComponent<BossAttack>().Attack3Right(); else GetComponent<BossAttack>().Attack3Left();
                GetComponent<Animator>().Play("Idle", 0);
            }
        }
    }

    void SpawnAttackParticles()
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

    void SpawnAttack2Particles()
    {
        Instantiate(attackParticles2, attackParticlePoints2[1].position, Quaternion.identity);
        Instantiate(attackParticles2, attackParticlePoints2[0].position, Quaternion.identity);
    }
    void SpawnAttack3Particles()
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
