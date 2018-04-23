using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    //update
	void Update () {

        //scroll camera in and out
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && Camera.main.fieldOfView > 5)
        {
            Camera.main.fieldOfView -= 5;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && Camera.main.fieldOfView < 95)
        {
            Camera.main.fieldOfView += 5;
        }

        //move camera
        if (Input.GetMouseButton(0))
        {
            transform.LookAt(new Vector3(210, 0, 290));
            transform.RotateAround(new Vector3(210, 0, 290), Vector3.up, Input.GetAxis("Mouse X") * 2);
        }
    }
}
