using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour {

    public int lifes = 3;
    public List<GameObject> lifesUI;
    public float graceTime;
    float graceTimer;
    bool grace;
    public GameObject EndGameUI;

    private void Update()
    {
        if(grace)
        {
            graceTimer += Time.deltaTime;
            if(graceTimer >= graceTime)
            {
                grace = false;
                graceTimer = 0;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!grace)
        {
            lifes -= 1;
            lifesUI[lifes].SetActive(false);
            grace = true;
            if (lifes == 0)
                EndGameUI.SetActive(true);
            GetComponent<SpriteRenderer>().color = Color.white * 0.5f;
        }
    }
}
