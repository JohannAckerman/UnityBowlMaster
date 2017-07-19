using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

    private Rigidbody rigidBody;

    public float standingThreshold = 10f;
    public float distanceToRaise = 60f;


    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public bool IsStanding()
    {
        float newX = 270f - transform.rotation.eulerAngles.x;
        float tiltX = (newX < 180f) ? newX : 360 - newX;
        float tiltZ = (transform.eulerAngles.z < 180f) ? transform.eulerAngles.z : 360 - transform.eulerAngles.z;
        if (tiltX > standingThreshold || tiltZ > standingThreshold)
        {
            if (tiltX > (standingThreshold * -1) || tiltZ > (standingThreshold * -1))
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
        else
        {
            return true;
        }
    }

    public void Raise()
    {
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            

            transform.Translate(new Vector3(0, distanceToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270, 0, 0);
        }
    }

    public void Lower()
    {
        transform.Translate(new Vector3(0, 40f * -1, 0), Space.World);
        rigidBody.useGravity = true;
    }
}
