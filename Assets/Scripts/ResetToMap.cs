using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToMap : MonoBehaviour {

    //Simple safelock method, sometimes Unity physics system didn't do well with fast-falling unicorn
    //so we reset player when he's out of bounds
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(collision.transform.position.x, -4.5f, 0);
    }
}
