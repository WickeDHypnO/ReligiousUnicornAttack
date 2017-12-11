using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHit : MonoBehaviour
{
    public float bossLife = 100f;
    public UIController uiController;
    public GameObject deathObject;
    public GameObject rageParticles;
    private float maxLife;
    private bool reducedTimers;

    private void Start()
    {
        //Set max boss life to current life, for sending values to update UI
        maxLife = bossLife;
    }

    //Deal damage to boss, update UI
    public void DealDamage()
    {
        if (bossLife > 0)
        {
            bossLife -= 1f;
            uiController.SetBossHealthUI(bossLife / maxLife);
        }
        //When boss life is lower than 50%, RAGE!
        if (bossLife / maxLife < 0.5f && !reducedTimers)
        {
            GetComponent<BossAttack>().gracePeriod *= 0.5f;
            GetComponent<BossAttack>().attackDelay *= 0.5f;
            rageParticles.SetActive(true);
            reducedTimers = true;
        }
        //Die if life is zero
        if (bossLife == 0)
        {
            Die();
        }
    }

    //Trigger boss death, update UI
    private void Die()
    {
        FindObjectOfType<MusicController>().ChangeToMenuTheme();
        rageParticles.SetActive(false);
        foreach (Collider2D col in GetComponents<Collider2D>())
        {
            col.enabled = false;
        }
        GetComponent<BossAttack>().StopAttack();
        GetComponent<BossAnimation>().PlayDeathAnimation();
        FindObjectOfType<UIController>().ShowGameOverUI(true);
        //Spawn BIG cross to crush boss
        Instantiate(deathObject, deathObject.transform.position, deathObject.transform.rotation);
    }
}
