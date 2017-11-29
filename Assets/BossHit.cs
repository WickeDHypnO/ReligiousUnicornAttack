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
            foreach(Collider2D col in GetComponents<Collider2D>())
            {
                col.enabled = false;
            }
            GetComponent<TestAnimation>().StopAttack();
            GetComponent<Animator>().Play("BossDeath");
            endGameUI.SetActive(true);
        }
    }
}
