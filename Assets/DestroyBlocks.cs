using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.GetComponent<Destroyable>())
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
