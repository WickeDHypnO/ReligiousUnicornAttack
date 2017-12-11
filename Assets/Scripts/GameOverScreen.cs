using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;

	private void OnEnable () {
        //Diable player, we force user to press button with mouse
        player.SetActive(false);
        //Stop all attacks from boss
        enemy.GetComponent<BossAttack>().StopAttack();
        enemy.GetComponent<BossAnimation>().StartAttackAnimation(0);
    }
}
