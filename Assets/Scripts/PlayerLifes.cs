using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifes : MonoBehaviour {

    public int lifes = 3;
    public List<GameObject> lifesUI;
    public float graceTime;
    private float graceTimer;
    private bool grace;

    private void Update()
    {
        //Do a grace timer, so the player cant be damaged instantly after hit
        if(grace)
        {
            graceTimer += Time.deltaTime;
            //Time passed? Player can now be hit
            if(graceTimer >= graceTime)
            {
                grace = false;
                graceTimer = 0;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    //Since only particles hurt us we're using this collsion method
    private void OnParticleCollision(GameObject other)
    {
        //Check if player is able to get damaged
        if (!grace)
        {
            lifes -= 1;
            lifesUI[lifes].SetActive(false);
            grace = true;
            //Show game over screen if player is out of lives
            if (lifes == 0)
                FindObjectOfType<UIController>().ShowGameOverUI(false);
            GetComponent<SpriteRenderer>().color = Color.white * 0.5f;
        }
    }
}
