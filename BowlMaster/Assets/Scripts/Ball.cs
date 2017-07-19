using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 startPosition;

    public Vector3 launchVelocity;
    public bool started = false;
    public bool inPlay;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;
        //Launch(launchVelocity);
    }

    public void Launch(Vector3 velocity)
    {
        if (!started)
        {            
            rigidBody.useGravity = true;
            rigidBody.velocity = velocity;
            playRollSound();
            started = true;
        }
        
    }

    public void Reset()
    {
        transform.position = startPosition;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
        started = false;

    }

    void playRollSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    

    // Update is called once per frame
    void Update () {
		
	}
}
