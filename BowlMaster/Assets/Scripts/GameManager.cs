using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {



    private ScoreDisplay scoreDisplay;
    private PinSetter pinSetter;
    private Ball ball;
    private List<int>  pinFalls = new List<int>();

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    private void Update()
    {

    }

    public void getPinFall(int pinFall)
    {
        // Get pinFalls from PinCounter
        pinFalls.Add(pinFall);
        handlePinFall();
    }

    private void handlePinFall()
    {
        // Send List of pinFalls to ActionMaster and ScoreMaster
        // Receive action and scores
        // send action to pinSetter/Animator
        pinSetter.performAction(ActionMaster.NextAction(pinFalls));
        scoreDisplay.FillRolls(pinFalls);                                  // individual rolls
        foreach (int roll in pinFalls)
        {
            Debug.Log(roll);
        }
        
        Debug.Log(ScoreDisplay.FormatRolls(pinFalls));
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(pinFalls));    // cumulative score

        ball.Reset();        
    }
}
