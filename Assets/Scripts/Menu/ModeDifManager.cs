using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:



----------------------------------------------------------------------------------------------------------- */
public class ModeDifManager : MonoBehaviour
{
    public static string difficulty;
    public static string mode;
    public static int maxChangeMatches;



    public void ChallengeMode()
    {
        
        mode = "Challenge";
        Debug.Log("Tryb: CHALLENGE");


    }


    public void PeacefulMode()
    {
        
        mode = "Peaceful";
        Debug.Log("Tryb: Peaceful");

    }

    public void EasyDiff()
    {
        
        maxChangeMatches = 1;
        difficulty = "Easy";
        PlayerPrefs.SetInt("LastLvl", 0);



    }


    public void MediumDiff()
    {
        
        maxChangeMatches = 2;
        difficulty = "Medium";
        PlayerPrefs.SetInt("LastLvl", 0);


    }

    public void HardDiff()
    {
        
        maxChangeMatches = 3;
        difficulty = "Hard";
        PlayerPrefs.SetInt("LastLvl", 0);


    }
}
