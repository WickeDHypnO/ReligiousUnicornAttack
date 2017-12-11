using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBlocks : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Check if object is destroyable, if so destroy it
        if(collision.collider.GetComponent<Destroyable>())
        {
            Destroy(collision.collider.gameObject);
        }
    }
}
