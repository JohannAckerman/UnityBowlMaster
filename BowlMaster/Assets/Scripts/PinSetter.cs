using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

    public GameObject PinSet;

    public Animator animator;
    private PinCounter pinCounter;
    private PinArea pinArea;
    private Pin pin;

    // Use this for initialization
    void Start () {

        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        pinArea = GameObject.FindObjectOfType<PinArea>();
    }


    // Update is called once per frame
    void Update () {
        

        //if (hasEntered || ballhasLeftBox)
        //{
        //    standingDisplay.color = Color.red;
        //    updateStandingCountText();
        //}

        //if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        //{
        //    touchInput.SetActive(true);
        //}
        //else
        //{
        //    touchInput.SetActive(false);
        //}
       

        //if (ball.started && !ballhasLeftBox && ball.GetComponent<Rigidbody>().velocity.magnitude < 2)
        //{
        //    standingDisplay.color = Color.red;
        //    updateStandingCountText();
        //}
        
    }

    public void RaisePins()
    {
        foreach (GameObject pin in pinArea.insideMe)
        {

            foreach (Pin newPin in GameObject.FindObjectsOfType<Pin>())
            {
                if (newPin.name == pin.name)
                {
                    if (newPin.IsStanding())
                    {
                        newPin.Raise();
                    }
                }
            }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(PinSet);
        newPins.transform.position += new Vector3(0, 5, 0);
    }


    public void performAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("tidyTrigger");

        }
        else if (action == ActionMaster.Action.Reset)
        {
            
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();

        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("resetTrigger");
            pinCounter.Reset();

        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("Don't know how to handle EndGame yet!");
        }
    }

    //void checkStanding()
    //{
    //    // update lastStandingCount
    //    // Call PinsHaveSettled() when they have
    //    int currentStandingCount = CountStanding();
        
    //    if (currentStandingCount != lastStandingCount)
    //    {
    //        lastChangeTime = Time.time;
    //        lastStandingCount = currentStandingCount;
    //        return;
    //    }
        

    //    float settleTime = 3f; // How long to wait to consider pins as settled

    //    if (Time.time - lastChangeTime >= settleTime)
    //    {
    //        PinsHaveSettled();
    //    }
    //}

    //void PinsHaveSettled()
    //{

    //    int standingCount = CountStanding();
    //    int pinFall = lastSettledCount - standingCount;
    //    lastSettledCount = standingCount;
    //    Debug.Log("Bowl# " + actionMaster.bowl + " Pinfall: " + pinFall);
    //    ActionMaster.Action action = actionMaster.Bowl(pinFall);
    //    Debug.Log("Action: " + action);

    //    if (action == ActionMaster.Action.Tidy)
    //    {
    //        animator.SetTrigger("tidyTrigger");

    //    }
    //    else if (action == ActionMaster.Action.Reset)
    //    {
    //        lastSettledCount = 10;
    //        animator.SetTrigger("resetTrigger");
            
    //    }
    //    else if (action == ActionMaster.Action.EndTurn)
    //    {
    //        lastSettledCount = 10;
    //        animator.SetTrigger("resetTrigger");
    //    }
    //    else if (action == ActionMaster.Action.EndGame)
    //    {
    //        throw new UnityException("Don't know how to handle EndGame yet!");
    //    }
    //    lastStandingCount = -1;
    //    ball.Reset();
    //    standingDisplay.color = Color.green;
        
    //    hasEntered = false;
    //    ballhasLeftBox = false;

    //}

    //int CountStanding()
    //{
    //    int currentStanding = 0;
    //    foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
    //    {
    //        if (pin.IsStanding())
    //        {
    //            currentStanding++;
    //        }
    //    }
    //    return currentStanding;
    //}
}
