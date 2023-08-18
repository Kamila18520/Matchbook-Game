using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Sprawdza czy ulozone zapalki tworza logiczne rownanie matematyczne


----------------------------------------------------------------------------------------------------------- */

public class CheckIfWin : MonoBehaviour
{
   
    public bool isWin = false;
    public string equal;
    public char[] equalChars;

    [SerializeField] GameObject points;

    //kazdy numer posiada 7 dzieci
    private int childCount = 7;
    public string difficulty;
    private int countTry;
    private int howManyMatchesMayBeChange;
    [SerializeField] private GameObject ScreenController;
    [SerializeField] private TextMeshProUGUI shiftedMatchesText;

    private void Start()
    {
        countTry = 0;
        difficulty = ModeDifManager.difficulty;
        howManyMatchesMayBeChange = ModeDifManager.maxChangeMatches;
        SetText();
    }

    public void Check()
    {
        
        //Ustawia aktualne pozycje zapalek
        SetActualMatchesMethod();

        //Sprawdza czy aktualne ulozenie jest logiczne. Jesli tak sprawdza czy to ulozenie tworzy poprawne rownanie
        DownloadEqual();

        countTry= CountCheck();
        Debug.Log("[Check If Win] Liczba zmienionych zapalek: "+ countTry);
        SetText();


        if (isWin && countTry >= howManyMatchesMayBeChange)
        {
            points.GetComponent<Points>().SetLastLvlWin();
            ScreenController.GetComponent<EndCongratScreens>().OnNextLvlScreen();
  
        }
        else if( !isWin && countTry >= howManyMatchesMayBeChange)
        {
            StartCoroutine(WaitForOneSec());
        }



    }

    private void SetText()
    {       
        shiftedMatchesText.text = "you must move at least "+ howManyMatchesMayBeChange +" matches || shifted matches: " + countTry +"/"+  howManyMatchesMayBeChange;
    }

    private int CountCheck()
    {
        int changeMatches=0;
        foreach (Transform child in transform)
        {
           for(int i=0; i< childCount;i++)
            {
                if (child.GetComponent<NumberPrefabController>() != null && child.GetComponent<NumberPrefabController>().actualMatches[i] != child.GetComponent<NumberPrefabController>().changedMatches[i])
                {
                    changeMatches++;
                }
            }
        }
        if(changeMatches%2 !=0) 
        {
            changeMatches++;
        }
        changeMatches = changeMatches / 2;
        return changeMatches;
    }

    private void DownloadEqual()
    {
        isWin = false;
        int index = 0;
        equalChars = new char[transform.childCount];


     foreach (Transform child in transform)
     {
         if (child.GetComponent<NumberPrefabController>() != null)
         {
             if (child.GetComponent<NumberPrefabController>().actualNumber >= 10)
             {
                 equalChars = null;
                 break;
             }
    
             equalChars[index] = child.GetComponent<NumberPrefabController>().actualNumber.ToString()[0];
    
         }
         else if (child.GetComponent<SignPrefabController>() != null)
         {
             equalChars[index] = child.GetComponent<SignPrefabController>().actualChar;
    
         }
         else if (child.GetComponent<NumberPrefabController>() == null && child.GetComponent<SignPrefabController>() == null)
         {
             equalChars[index] = '=';
         }
    
         index++;
     }

        if (equalChars != null)
        {
            CheckEqual();
        }
        else
        {
            Debug.Log("[Check If Win] Nie wszytskie zapalki ukladaja sie w liczbe");
         
        }

    }


    private void CheckEqual()
    {
        char sign = 'o';
        int index = 0;
        int[] numbers = new int[3];

        for (int i = 0; i < equalChars.Length; i++)
        {

            if (!char.IsDigit(equalChars[i]) && equalChars[i] != '=')
            {
                sign = equalChars[i];
                index = 1;
            }
            else if (equalChars[i] == '=')
            {
                index = 2;
            }
            else if (char.IsDigit(equalChars[i]))
            {
                int charToInt = (int)equalChars[i] - (int)'0'; ;
                numbers[index] = (numbers[index] * 10) + charToInt;
            }
        }



        bool isWrong = true;

        if (sign == '+' && (numbers[0] + numbers[1] == numbers[2]))
        {
            isWrong = false;

        }
        else if (sign == '-' && (numbers[0] - numbers[1] == numbers[2]))
        {
            isWrong = false;

        }
        else if (sign == 'x' && (numbers[0] * numbers[1] == numbers[2]))
        {
            isWrong = false;

        }
        else if (sign == '/' && numbers[1] >=1 && (numbers[0] / numbers[1] == numbers[2]) )
        {
            isWrong = false;

        }
        else if(sign == '/' &&  numbers[1] < 1)
        {
            isWrong = true;

        }

        if (isWrong)
        {
            Debug.Log("[Check If Win] Zakonczenie gry niewykryte");
        }
        else if (!isWrong)
        {
            Debug.Log("[Check If Win] Zakonczenie gry wykryte. Gracz wygral runde.");
            isWin = true;

        }

    }

    private void SetActualMatchesMethod()
    {



        foreach (Transform child in transform)
        {
            if (child.GetComponent<NumberPrefabController>() != null)
            {
                child.GetComponent<NumberPrefabController>().SetActualMatches();

            }
            else if (child.GetComponent<SignPrefabController>() != null)
            {
                child.GetComponent<SignPrefabController>().ActualChar();
            }
        }
    }


    private IEnumerator WaitForOneSec()
    {
        yield return new WaitForSeconds(0.5f);
        BackToOriginalSetting();
    }


    //Przywraca zapalki do pierwotnej pozycji
    public void BackToOriginalSetting()
    {
        countTry = 0;
        Debug.Log("[Check If Win] Zapalki zostaly przywrocone do pierwotnej pozycji");
        foreach(Transform child in transform)
        {

            if (child.GetComponent<NumberPrefabController>() != null)
            {
                    for (int i = 0; i < childCount; i++)
                    {


                     child.GetChild(i).GetComponent<SpriteRenderer>().enabled = child.GetComponent<NumberPrefabController>().changedMatches[i];

                    if (child.GetComponent<NumberPrefabController>().actualMatches[i] != child.GetComponent<NumberPrefabController>().changedMatches[i] )
                              {
                                      child.GetChild(i).GetComponent<ClickController>().PutMatchAnimation();
                              }

                    }


            }
            else if(child.GetComponent<SignPrefabController>())
            {
                if(child.GetComponent<SignPrefabController>().changedChar =='x' || child.GetComponent<SignPrefabController>().changedChar == '+')
                {
                     child.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = true;
                }
                else if (child.GetComponent<SignPrefabController>().changedChar == '-' || child.GetComponent<SignPrefabController>().changedChar == '/')
                {
                     child.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;

                }
                   
            }
        }
        SetText();
        SetActualMatchesMethod();
    }
}
