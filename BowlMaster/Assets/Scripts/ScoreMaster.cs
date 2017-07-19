using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreMaster {

    //Returns a list of cumulative scores, like a normal score card.
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int totalScore = 0;
        foreach (int frame in ScoreFrames(rolls))
        {
            totalScore += frame;
            cumulativeScores.Add(totalScore);
        }




        //int frameScore = 0;
        //int currentScore = 0;
        //int rollNumber = 1;
        //int previousRoll = 0;
        //foreach (int roll in rolls)
        //{
        //    if (rollNumber % 2 != 0)
        //    {
        //        currentScore = roll;
        //    }else
        //    {
        //        frameScore = currentScore + roll;
        //    }
        //    rollNumber++;
        //}
        return cumulativeScores;
    }

    // Return a list of individual frame scores
	public static List<int> ScoreFrames (List<int> rolls)
    {
        List<int> frameList = new List<int>();

        int rollNumber = 0;
                          
        while (rollNumber < rolls.Count-1)                                                              // if only 1 roll the while does not fire off
        {
            if (frameList.Count == 10) { break; }                                                       // Prevent 11th Frame score
            int sum = 0;            
            
            if (rolls[rollNumber] == 10 || rolls[rollNumber] + rolls[rollNumber + 1] == 10)             // Strike or Spare
            {
                if (rolls.Count - (rollNumber+1) <= 1) { break; }                                       // initially used -1s to check if the next 2 rolls existed to avoid look-ahead issues
                sum = rolls[rollNumber] + rolls[rollNumber + 1] + rolls[rollNumber + 2];
                frameList.Add(sum);
            }
            else
            {
                sum = rolls[rollNumber] + rolls[rollNumber + 1];                                        // Normal frame
                frameList.Add(sum);
            }
            
            if (rolls[rollNumber] == 10)
            {   
                rollNumber--;                
            }
            rollNumber += 2;
        }

        return frameList;
    }

}
