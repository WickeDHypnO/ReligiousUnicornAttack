using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float shakeTime = 2f;
    public float shakeStrength;
    float timer;

	void OnDisable() {
        transform.position = new Vector3(0, 0, -10);
	}
	
	void Update () {
        timer += Time.deltaTime;
        transform.position = new Vector3(Random.Range(-shakeStrength, shakeStrength), Random.Range(-shakeStrength, shakeStrength), -10);
        if (timer >= shakeTime)
        {
            enabled = false;
        }
    }
}
