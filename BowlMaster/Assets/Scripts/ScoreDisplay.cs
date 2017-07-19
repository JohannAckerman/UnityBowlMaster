using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

    public Text[] bowlScores, frameScores;

    private void Start()
    {
        
    }

    public void FillRollCard(List<int> rolls)
    {
        int bowlNumber = 0;
        int rollNumber = 0;

        foreach (int roll in rolls)
        {
            
            if (roll != 10)
            {
                
                if (bowlNumber % 2 != 0 && rolls[rollNumber] + rolls[rollNumber - 1] == 10)
                {
                    bowlScores[bowlNumber].text = "/";
                }
                else
                {
                    bowlScores[bowlNumber].text = roll.ToString();
                }                
                bowlNumber++;
            }
            else
            {
                bowlScores[bowlNumber].text = "X";
                if (bowlNumber != 18)
                {
                    bowlNumber += 2;
                }
                
            }
            rollNumber++;
        }
    }

    public void FillRolls(List<int> rolls)
    {
        string scoreString = FormatRolls(rolls);

        for (int i = 0; i < scoreString.Length; i++)
        {
            bowlScores[i].text = scoreString[i].ToString();
        }
    }

    public void FillFrames(List<int> scores)
    {
        for (int i = 0; i < scores.Count; i++)
        {
            frameScores[i].text = scores[i].ToString();
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";



        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;
            // j = bowlNumber i = rollNumber
            if (rolls[i] == 0)
            {
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i] + rolls[i - 1] == 10)
            {
                if (box == 20 && rolls[i-1] == 10) { output += rolls[i].ToString(); }
                else { output += "/"; }
                
            }
            else if(box >= 19 && rolls[i] == 10)
            {
                output += "X";
            }
            else if (rolls[i] == 10)
            {
                output += "X ";
            }
            else
            {
                output += rolls[i].ToString();
            }


        }





        //for (int i = 0, j = 1; i < rolls.Count; i++, j+=2)
        //{
        //    if (rolls[i] != 10)
        //    {
        //        // j = bowlNumber i = rollNumber
        //        if (j % 2 == 0 && rolls[i] + rolls[i - 1] == 10)
        //        {
        //            output += "/";
        //        }
        //        else
        //        {
        //            if (rolls[i] == 0)
        //            {
        //                output += "-";
        //            }
        //            else
        //            {
        //                output += rolls[i].ToString();
        //            }
                    
        //        }
        //        j--;
        //    }
        //    else
        //    {
        //        if (j % 2 == 0)
        //        {
        //            output += "/";
        //        }
        //        else
        //        {
        //            output += "X ";
        //        }
                
        //        if (j == 18) { j--; }

        //    }

            
        //}
        


        return output;
    }
}
