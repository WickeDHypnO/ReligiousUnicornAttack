using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour {

    public float up, right;
    public float movementSpeed = 1f;
    Rigidbody2D rigid;
    // Update is called once per frame

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update () {
		if(Input.GetAxis("Horizontal") != 0)
        {
            right = Input.GetAxis("Horizontal");
        }
        else
        {
            right = 0;
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            up = Input.GetAxis("Vertical");
        }
        else
        {
            up = 0;
        }
    }

    private void FixedUpdate()
    {
        if(right != 0)
        {
            rigid.AddForce(Vector2.right * right * movementSpeed);
        }
        if (up > 0)
        {
            rigid.AddForce(Vector2.up * up * movementSpeed);
        }
    }
}
