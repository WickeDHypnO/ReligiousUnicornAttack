using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Enemy")
        {
            col.collider.GetComponent<BossHit>().DealDamage();
        }
        Destroy(gameObject);
    }
}
