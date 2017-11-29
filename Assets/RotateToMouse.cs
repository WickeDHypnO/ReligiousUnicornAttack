using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour {

    public float maxRotation = 60;
    public Vector2 shotDirection;

	void FixedUpdate () {

        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        shotDirection = mousePos;

        if (Mathf.Abs(angle) < maxRotation && transform.parent.localScale.x > 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if (-Mathf.Abs(angle) < -maxRotation*2 && transform.parent.localScale.x < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        }
        
    }
}
