using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Ball ball;
    private float startTime, endTime, dragDuration;
    private Vector3 startPosition, endPosition, launchVelocity;

	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}
	
    public void DragStart()
    {
        startTime = Time.time;
        startPosition = Input.mousePosition;
        // Capture time and position of drag start
    }

    public void DragEnd()
    {
        float x, z;
        endPosition = Input.mousePosition;
        endTime = Time.time;
        dragDuration = endTime - startTime;
        x = (endPosition.x - startPosition.x) / dragDuration;
        z = (endPosition.y - startPosition.y) / dragDuration;
        if (z > 1000){ z = 1000; }
        x /= 100;
        if (x > 100){ x = 100; }else if (x < -100) { x = -100; }
        launchVelocity = new Vector3(x,0,z);
        ball.Launch(launchVelocity);
        // Launch ball
    }

    public void MoveStart(float xNudge)
    {
        if (!ball.started)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + xNudge, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;
            ball.transform.position = new Vector3(xPos, yPos, zPos);            
        }
    }
}
