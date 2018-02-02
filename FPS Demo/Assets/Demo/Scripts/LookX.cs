using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float mouseX = Input.GetAxis("Mouse X");
        Vector3 mouseDirectionX = transform.localEulerAngles;
        mouseDirectionX.y += mouseX;
        transform.localEulerAngles = mouseDirectionX;
    }
}
