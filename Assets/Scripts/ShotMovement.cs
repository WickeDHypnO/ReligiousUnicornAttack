using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour {

    public float shotSpeed;
    private Vector2 movementDirection;
    private Rigidbody2D rigid;

    //Method for setting shot movement direction
    public void SetShotMovementDirection(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void OnEnable()
    {
        //Get rigidbody so we can change position
        rigid = GetComponent<Rigidbody2D>();
    }

    //Move shot using rigidbody and specified vector
    private void FixedUpdate () {
        rigid.AddForce(movementDirection * shotSpeed);
	}
}
