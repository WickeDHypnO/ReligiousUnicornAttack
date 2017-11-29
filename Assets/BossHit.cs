using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHit : MonoBehaviour
{

    public float bossLife = 100f;
    public Slider bossLifeUI;
    float maxLife;
    public GameObject endGameUI;
    public GameObject deathObject;

    private void Start()
    {
        maxLife = bossLife;
    }

    public void DealDamage()
    {
        if (bossLife > 0)
        {
            bossLife -= 1f;
            bossLifeUI.value = bossLife / maxLife;
        }
        if (bossLife == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        foreach (Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }
        GetComponent<TestAnimation>().StopAttack();
        GetComponent<Animator>().Play("BossDeath");
        endGameUI.SetActive(true);
        Instantiate(deathObject, deathObject.transform.position, deathObject.transform.rotation);
    }
}
