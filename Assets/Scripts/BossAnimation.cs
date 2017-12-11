using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    public float defaultHeight;
    public float risingSpeed;
    private float startPosition;
    private float timer;
    private bool startedAttacking;

    private void Start()
    {
        //Get starting position for lerping
        startPosition = transform.position.y;
    }

    public void Update()
    {
        //Rise boss to fight!
        if (!startedAttacking)
        {
            //Earthquake sound
            if (!GetComponentInChildren<AudioSource>().isPlaying)
                GetComponentInChildren<AudioSource>().Play();
            timer += Time.deltaTime * risingSpeed;
            transform.position = Vector3.Lerp(new Vector3(0, startPosition, 1), new Vector3(0, defaultHeight, 1), timer);
            if (transform.position.y >= defaultHeight)
            {
                startedAttacking = true;
                //Start main attack coroutine
                GetComponent<BossAttack>().StartAttacking();
                GetComponentInChildren<AudioSource>().Stop();
            }
        }
    }

    //Main attack animation
    public void StartAttackAnimation(int attack)
    {
        //Play animation according to chosen attack
        if (attack == 0)
        {
            GetComponent<Animator>().Play("BossAttack2", 0);
        }
        else if (attack == 1 || attack == 2)
        {
            //Flip sprite if attack is not from desired side
            if (attack == 1)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Animator>().Play("BossAttack", 0);
        }
        else
        {
            //Flip sprite if attack is not from desired side
            if (attack == 3)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            GetComponent<Animator>().Play("BossAttack3", 0);
        }
    }

    //Play idle animation (breathing)
    public void PlayIdleAnimation()
    {
        GetComponent<Animator>().Play("Idle", 0);
    }

    //Play boss death animation
    public void PlayDeathAnimation()
    {
        GetComponent<Animator>().Play("BossDeath",0);
    }

}
