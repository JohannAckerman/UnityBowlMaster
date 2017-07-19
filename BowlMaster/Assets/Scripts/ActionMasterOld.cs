using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster3 {

    public enum Action { Tidy, Reset, EndTurn, EndGame };
    
    private int[] bowls = new int[21];
    private int frameNumber = 1;
    public int bowl = 1;
    private int currentFramePins = 0;

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMaster3 am = new ActionMaster3();
        Action currentAction = new Action();
        foreach (int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }

        return currentAction;
    }

    private Action Bowl (int pins)
    {
        if (pins > 10) { throw new UnityException("Invalid pin count!"); }

        

        if (bowl == 21)
        {
            return Action.EndGame;
        }

        addPinCount(pins);

        if (bowl == 19 && pins == 10)
        {
            addBowlCount(pins);
            currentFramePins = 0;
            return Action.Reset;
        } else if (bowl == 20)
        {
            addBowlCount(pins);
            if (currentFramePins == 10)
            {
                currentFramePins = 0;
                return Action.Reset;
            }
            else if (currentFramePins == 0)
            {
                return Action.Tidy;
            }
            else if (Bowl21Awarded())
            {
                return Action.Tidy;
            } else
            {
                return Action.EndGame;
            }
        }


        //if (bowl == 19 && Bowl21Awarded())
        //{
        //    addBowlCount(pins);
        //    goToNextFrame();
        //    return Action.Reset;
        //}else if (bowl == 20 && !Bowl21Awarded())
        //{
        //    return Action.EndGame;
        //}

        if (pins == 10)
        {
            addBowlCount(pins);
            goToNextFrame();
            return Action.EndTurn;
        }

        // if first bowl of frame
        if (bowl % 2 != 0)
        {
            
            addBowlCount(pins);
            return Action.Tidy;
        }
        else
        {
            addBowlCount(pins);
            goToNextFrame();
            return Action.EndTurn;
        }

        

        throw new UnityException("Not sure what action to return!");
    }

    private bool Bowl21Awarded()
    {
        return (bowls[19 - 1] + bowls[20 - 1] >= 10);
    }

    private void addPinCount(int pins)
    {
        currentFramePins += pins;
        bowls[bowl-1] = pins;

        if (currentFramePins > 10) { throw new UnityException("Max pin count exceeded!"); }
    }

    private void addBowlCount(int pins)
    {        
        if (bowl % 2 != 0) {
            if (pins == 10 && !Bowl21Awarded()) {
                bowl += 2;
            }
            else { bowl++; }
        }
        else { bowl++; }
    }

    private void goToNextFrame()
    {
        frameNumber++;
        currentFramePins = 0;
        
    }
}
