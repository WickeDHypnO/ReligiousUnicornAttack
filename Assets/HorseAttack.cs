using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAttack : MonoBehaviour {

    public float up, right;
    public GameObject shotPrefab;
    public float shotDelay = 1f;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetAxis("AttackHorizontal") != 0)
        {
            right = Input.GetAxis("AttackHorizontal");
        }
        else
        {
            right = 0;
        }
        if (Input.GetAxis("AttackVertical") != 0)
        {
            up = Input.GetAxis("AttackVertical");
        }
        else
        {
            up = 0;
        }
    }

    private void FixedUpdate()
    {
        if (timer > shotDelay)
        {
            if(Input.GetMouseButton(0))
            { 
                var shot = Instantiate(shotPrefab, transform.position, shotPrefab.transform.rotation);
                shot.GetComponent<ShotMovement>().shotMovementDirection = GetComponent<RotateToMouse>().shotDirection.normalized;
                timer = 0;
            }
        }
    }
}
