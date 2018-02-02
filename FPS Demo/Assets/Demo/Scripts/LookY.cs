using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 mouseDirectionY = transform.localEulerAngles;
        mouseDirectionY.x -= mouseY;
        transform.localEulerAngles = mouseDirectionY;
    }
}
