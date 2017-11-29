using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetToMap : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = new Vector3(collision.transform.position.x, -4.5f, 0);
    }
}
