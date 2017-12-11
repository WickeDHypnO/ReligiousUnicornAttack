using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShift : MonoBehaviour
{
    public Rigidbody2D player;

    private void Update()
    {
        //Rotate map accroding to players position, creates fake parallax effect on foreground
        transform.eulerAngles = new Vector3(player.transform.position.y, player.transform.position.x, 0);
    }
}
