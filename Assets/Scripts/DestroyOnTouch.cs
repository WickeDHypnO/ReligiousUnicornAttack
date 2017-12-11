using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D collision)
    {
        //Play sound of destruction of object
        GameObject.Find("HitSound").GetComponent<AudioSource>().Play();
        if (collision.collider.tag == "Enemy")
        {
            collision.collider.GetComponent<BossHit>().DealDamage();
        }
        Destroy(gameObject);
    }
}
