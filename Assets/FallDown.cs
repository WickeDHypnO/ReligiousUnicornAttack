using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public float fallDistance;
    public float fallSpeed = 1f;
    float timer;
    float defaultPosition;

    private void OnEnable()
    {
        defaultPosition = transform.position.y;
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime * fallSpeed;
        transform.position = Vector3.Lerp(
            new Vector3(transform.position.x, defaultPosition, transform.position.z),
            new Vector3(transform.position.x, defaultPosition - fallDistance, transform.position.z),
            timer);
    }
}
