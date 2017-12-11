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
        //Set default position for better lerping later
        defaultPosition = transform.position.y;
    }

    private void FixedUpdate()
    {
        timer += Time.deltaTime * fallSpeed;
        //Lerp position of object to destination
        transform.position = Vector3.Lerp(
            new Vector3(transform.position.x, defaultPosition, transform.position.z),
            new Vector3(transform.position.x, defaultPosition - fallDistance, transform.position.z),
            timer);
    }
}
