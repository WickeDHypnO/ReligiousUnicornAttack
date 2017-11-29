using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseLegController : MonoBehaviour
{

    public List<GameObject> legs;
    public Vector2 movementVector;
    public List<Vector2> legsDefaultPosition;
    public List<Quaternion> legsDefaultRotation;
    public float maxLegMovement;

    private void Start()
    {
        foreach (GameObject leg in legs)
        {
            legsDefaultPosition.Add(leg.transform.localPosition);
            legsDefaultRotation.Add(leg.transform.localRotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movementVector = movementVector.normalized;
        if (movementVector == Vector2.zero)
        {
            int iter = 0;
            foreach (GameObject leg in legs)
            {
                leg.transform.localPosition = legsDefaultPosition[iter];
                leg.transform.localRotation = Quaternion.identity;
                iter++;
            }
        }
        else
        {
            foreach (GameObject leg in legs)
            {
                if (movementVector.x > 0 && movementVector.y > 0)
                    leg.transform.eulerAngles = new Vector3(0, 0, 45);
                else if (movementVector.x > 0 && movementVector.y < 0)
                    leg.transform.eulerAngles = new Vector3(0, 0, -45);
                else if (movementVector.x < 0 && movementVector.y < 0)
                    leg.transform.eulerAngles = new Vector3(0, 0, 45);
                else if (movementVector.x < 0 && movementVector.y > 0)
                    leg.transform.eulerAngles = new Vector3(0, 0, -45);
                else if (movementVector.x != 0 && movementVector.y == 0)
                    leg.transform.eulerAngles = new Vector3(0, 0, 0);
                else if (movementVector.x == 0 && movementVector.y != 0)
                    leg.transform.eulerAngles = new Vector3(0, 0, 90);
            }
        }
    }
}
