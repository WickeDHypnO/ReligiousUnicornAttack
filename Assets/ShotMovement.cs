using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

    public Vector2 shotMovementDirection;
    public float shotSpeed;
    Rigidbody2D rigid;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        rigid.AddForce(shotMovementDirection * shotSpeed);
	}
}
