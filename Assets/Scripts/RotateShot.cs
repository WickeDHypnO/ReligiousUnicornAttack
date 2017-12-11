using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShot : MonoBehaviour {

    //Rotate shot cross continously
	private void FixedUpdate () {
        transform.Rotate(new Vector3(0, 0, 15f));
	}
}
