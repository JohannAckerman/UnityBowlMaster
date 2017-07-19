using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

    public Text standingDisplay;
    public GameObject touchInput;
    private PinSetter pinSetter;
    private GameManager gameManager;

    private PinArea pinArea;
    public int lastSettledCount = 10;

    private int lastStandingCount = -1;
    private float lastChangeTime;    
    private bool ballhasLeftBox = false;



    private Pin pin;
    private Ball ball;

    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        pinArea = GameObject.FindObjectOfType<PinArea>();
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();

    }

    private void Update()
    {
        standingDisplay.text = CountStanding().ToString();
        if (ballhasLeftBox)
        {
            standingDisplay.color = Color.red;
            updateStandingCountText();
        }
        if (pinSetter.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            touchInput.SetActive(true);
        }
        else
        {
            touchInput.SetActive(false);
        }


        if (ball.started && !ballhasLeftBox && ball.GetComponent<Rigidbody>().velocity.magnitude < 2)
        {
            standingDisplay.color = Color.red;
            updateStandingCountText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Bowling Ball")
        {
            ballhasLeftBox = true;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    public void updateCountText()
    {
        standingDisplay.text = CountStanding().ToString();
    }

    public void updateStandingCountText()
    {
        checkStanding();
    }


    void checkStanding()
    {
        //update lastStandingCount
        int currentStandingCount = CountStanding();

        if (currentStandingCount != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStandingCount;
            return;
        }


        float settleTime = 3f; // How long to wait to consider pins as settled

        if (Time.time - lastChangeTime >= settleTime)
        {

            int standingCount = CountStanding();
            int pinFall = lastSettledCount - standingCount;
            lastSettledCount = standingCount;

            // Send pinFall to GameManager
            Debug.Log("adding PinFall: " + pinFall);
            gameManager.getPinFall(pinFall);
            lastStandingCount = -1;
            standingDisplay.color = Color.green;
            ballhasLeftBox = false;
        }
    }


    int CountStanding()
    {
        int currentStanding = 0;
        foreach (GameObject pin in pinArea.insideMe)
        {
            
            foreach (Pin newPin in GameObject.FindObjectsOfType<Pin>())
            {
                if (newPin.name == pin.name)
                {
                    if (newPin.IsStanding())
                    {
                        currentStanding++;
                    }
                }
            }
        }
        //foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        //{
        //    if (pin.IsStanding())
        //    {
        //        currentStanding++;
        //    }
        //}
        return currentStanding;
    }
}
