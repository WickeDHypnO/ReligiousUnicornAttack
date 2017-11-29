using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShift : MonoBehaviour
{

    public float maxShift;
    List<Transform> objects;
    public Rigidbody2D player;
    Vector3 vel;
    Vector3 lastRotation;

    void Update()
    {
        transform.eulerAngles = new Vector3(player.transform.position.y, player.transform.position.x, 0);
        //transform.eulerAngles = Vector3.SmoothDamp(lastRotation, new Vector3(player.velocity.y * maxShift, 0, 0) + new Vector3(0, player.velocity.x * maxShift, 0), ref vel, 12f, 0.03f);
        //lastRotation = new Vector3(player.velocity.y * maxShift, 0, 0) + new Vector3(0, player.velocity.x * maxShift, 0);
    }
}
