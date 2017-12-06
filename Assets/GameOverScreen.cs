using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;

	// Use this for initialization
	void OnEnable () {
        player.SetActive(false);
        enemy.GetComponent<TestAnimation>().StopAttack();
        enemy.GetComponent<Animator>().Play("BossAttack2", 0);
    }
}
