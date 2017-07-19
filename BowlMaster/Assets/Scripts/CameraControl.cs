using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;
    private float z;

	// Use this for initialization
	void Start () {
        offset = transform.position - ball.transform.position;
        

    }
	
	// Update is called once per frame
	void Update () {
        z = ball.transform.position.z;
        if (z <= 1829) // in front of head pin
        {
            transform.position = ball.transform.position + offset;
        }
	}
}
