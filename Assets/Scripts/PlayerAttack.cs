using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public GameObject shotPrefab;
    public float shotDelay = 1f;
    private float timer;

    //Add time to factor delay
    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void LateUpdate()
    {
        //if we can shoot...
        if (timer > shotDelay)
        {
            //...and mouse button is pressed...
            if(Input.GetMouseButton(0))
            { 
                //...shoot!
                var shot = Instantiate(shotPrefab, transform.position, shotPrefab.transform.rotation);
                //Set movement direction for shot
                shot.GetComponent<ShotMovement>().SetShotMovementDirection(GetShotVector());
                timer = 0;
            }
        }
    }

    //Method for getting vector of shot according to mouse position
    private Vector2 GetShotVector()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 shotSpawnPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 shotDirection = new Vector2(mousePosition.x - shotSpawnPosition.x, mousePosition.y - shotSpawnPosition.y);
        return shotDirection.normalized;
    }
}
