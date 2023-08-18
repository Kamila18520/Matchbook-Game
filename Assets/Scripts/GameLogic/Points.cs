using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

odpowiada za przypisywanie pkt i ich zmiane podczas ustalania nowych rekordów w grze

----------------------------------------------------------------------------------------------------------- */
public class Points : MonoBehaviour
{
    public bool IsLastLvlIsHighestThanRecord;
    public int currentLvl;
    public int highestLvl;
    public int lastLvl;

    [SerializeField] private GameObject LevelText;
    [SerializeField] private GameObject GameOverText;


    [SerializeField] private string chosenMode;
    [SerializeField] private string difficulty;
   // [SerializeField] private GameObject PointsScreenViev;
    void Start()
    {
        chosenMode = ModeDifManager.mode;
        difficulty= ModeDifManager.difficulty;


        lastLvl = PlayerPrefs.GetInt("LastLvl");
        currentLvl = lastLvl + 1;

        GameOverText.GetComponent<TextMeshProUGUI>().text = "your lvl is\r\n" + lastLvl;

        // ustawianie highest lvl na podstawie trybu i poziomu trudnoœci
        if (chosenMode == "Peaceful" || chosenMode==null)
        {
            if (difficulty == "Easy")
            {
                highestLvl = PlayerPrefs.GetInt("PeacefulEasy");
            }
            else if (difficulty == "Medium")
            {
                highestLvl = PlayerPrefs.GetInt("PeacefulMedium");
            }
            else if (difficulty == "Hard")
            {
                highestLvl = PlayerPrefs.GetInt("PeacefulHard");
            }
        }
        else if (chosenMode == "Challenge")
        {
            if (difficulty == "Easy")
            {
                highestLvl = PlayerPrefs.GetInt("ChallengeEasy");
            }
            else if (difficulty == "Medium")
            {
                highestLvl = PlayerPrefs.GetInt("ChallengeMedium");
            }
            else if (difficulty == "Hard")
            {
                highestLvl = PlayerPrefs.GetInt("ChallengeHard");
            }
        }



        IsLastLvlIsHighestThanRecord = IsLastLvlTheHighest();


        if (lastLvl > highestLvl)
        {
            LevelText.GetComponent<TextMeshProUGUI>().text = "You're beating new record right now!" + "\r\n New Top Level: " + (currentLvl-1).ToString();

        }
        else if (lastLvl < highestLvl)
        {
            LevelText.GetComponent<TextMeshProUGUI>().text = "Last highest Lvl: " + highestLvl + "\r\nCurrent Lvl: " + currentLvl.ToString();
        }
        else if (lastLvl == highestLvl)
        {
            LevelText.GetComponent<TextMeshProUGUI>().text = "Last level to beat your old record! ";
        }



    }

    private bool IsLastLvlTheHighest()
    {
        if (lastLvl >= highestLvl) 
        { 
            SetHighestLevel();
            return true;
            
        }
        return false;
    
    
    }



    public void SetLastLvlWin()
    {
        PlayerPrefs.SetInt("LastLvl", currentLvl);

    }

    public void SetLastLvlEndGame()
    {
        PlayerPrefs.SetInt("LastLvl", 0);
        if(IsLastLvlIsHighestThanRecord = IsLastLvlTheHighest())
        {
            SetHighestLevel();
        }
    }

    private void SetHighestLevel()
   {
       if (chosenMode == "Peaceful")
       {
           if (difficulty == "Easy")
           {
 
               PlayerPrefs.SetInt("PeacefulEasy", lastLvl);
           }
           else if (difficulty == "Medium")
           {
 
               PlayerPrefs.SetInt("PeacefulMedium", lastLvl);
           }
           else if (difficulty == "Hard")
           {
               PlayerPrefs.SetInt("PeacefulHard", lastLvl);
           }
       }
       else if (chosenMode == "Challenge")
       {
           if (difficulty == "Easy")
           {
               PlayerPrefs.SetInt("ChallengeEasy", lastLvl);
           }
           else if (difficulty == "Medium")
           {
 
               PlayerPrefs.SetInt("ChallengeMedium", lastLvl);
           }
           else if (difficulty == "Hard")
           {
 
               PlayerPrefs.SetInt("ChallengeHard", lastLvl);
           }
       }
   }
 
 
}
