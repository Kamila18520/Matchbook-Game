using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:



----------------------------------------------------------------------------------------------------------- */

public class NumberPrefabController : MonoBehaviour
{
    public bool[] changedMatches= new bool[7];
    public bool[] oryginalMatches= new bool[7];
    public bool[] actualMatches= new bool[7];
    private bool[] checkMatches = new bool[7];

    List<Action> methodList = new List<Action>();

   // public bool isMatchesCorrect;
    public int changedNumber;
    public int oryginalNumber;
    public int actualNumber;
    // private bool[] iZero = new bool[7];
    // private bool[] iOne = new bool[7];
    // private bool[] iTwo = new bool[7];
    // private bool[] iThree = new bool[7];
    // private bool[] iFour = new bool[7];
    // private bool[] iFive = new bool[7];
    // private bool[] iSix = new bool[7];
    // private bool[] iSeven = new bool[7];
    // private bool[] iEight = new bool[7];
    // private bool[] iNine = new bool[7];


    void Start()
    {
        methodList.Add(() => Zero());
        methodList.Add(() => One());
        methodList.Add(() => Two());
        methodList.Add(() => Three());
        methodList.Add(() => Four());
        methodList.Add(() => Five());
        methodList.Add(() => Six());
        methodList.Add(() => Seven());
        methodList.Add(() => Eight());
        methodList.Add(() => Nine());



        methodList[oryginalNumber].Invoke();

        SetOryginalMatches();

        methodList[changedNumber].Invoke();

        SetChangedMatches();;

        SetActiveChildren();
    }

    public void SetActualMatches()
    {
        int index = 0;


      foreach(Transform child in transform) 
      {

            if (child.GetComponent<SpriteRenderer>().enabled==true)
          {
              actualMatches[index] = true;
          }
          else if(child.GetComponent<SpriteRenderer>().enabled == false)
          {

          actualMatches[index] = false;
          }
              
      index++;
      }

     for(int i=0; i <=9; i++) 
     {
       
         methodList[i].Invoke();
         if (checkMatches.SequenceEqual(actualMatches))
         {
             actualNumber = i;
             break;
         }
         else actualNumber = 10;
     }

    }

    private void SetChangedMatches()
    {
        int index = 0;
        foreach (bool match in checkMatches)
        {
            changedMatches[index] = checkMatches[index];
            actualMatches[index] = checkMatches[index];
            index++;
        }
    }

  // private void IsMatchesCorrect()
  // {
  //     if (oryginalNumber == changedNumber)
  //     {
  //         isMatchesCorrect = true;
  //     }
  //     else isMatchesCorrect = false;
  // }


    private void SetOryginalMatches()
    {
        int index = 0;
        foreach (bool match in checkMatches)
        {
            oryginalMatches[index] = checkMatches[index];
            index++;
        }

    }

    private void SetActiveChildren()
    {

        int index =0;

        foreach(bool match in changedMatches) 
        {

            if (!match) 
            {
                gameObject.transform.GetChild(index).gameObject.GetComponent<SpriteRenderer>().enabled = false;
               
            }
            index++;
        }
      
    }
  // public void CheckMatches()
  // {
  //
  // }

    private void Zero()
    {
        checkMatches[0]= true;
        checkMatches[1]= true;
        checkMatches[2]= true;
        checkMatches[3]= false;
        checkMatches[4]= true;
        checkMatches[5]= true;
        checkMatches[6]= true;
      //  iZero = checkMatches;
    }



    private void One()
    {
        checkMatches[0] = false;
        checkMatches[1] = false;
        checkMatches[2] = true;
        checkMatches[3] = false;
        checkMatches[4] = false;
        checkMatches[5] = false;
        checkMatches[6] = true;
       // iOne= checkMatches;
    }

    private void Two() 
    {
        checkMatches[0] = false;
        checkMatches[1] = true;
        checkMatches[2] = true;
        checkMatches[3] = true;
        checkMatches[4] = true;
        checkMatches[5] = true;
        checkMatches[6] = false;
      //  iTwo= checkMatches;
    }

    private void Three()
    {
        checkMatches[0] = false;
        checkMatches[1] = true;
        checkMatches[2] = true;
        checkMatches[3] = true;
        checkMatches[4] = false;
        checkMatches[5] = true;
        checkMatches[6] = true;
      //  iThree= checkMatches;
    }

    private void Four()
    {
        checkMatches[0] = true;
        checkMatches[1] = false;
        checkMatches[2] = true;
        checkMatches[3] = true;
        checkMatches[4] = false;
        checkMatches[5] = false;
        checkMatches[6] = true;
      //  iFour= checkMatches;
  
    }

    private void Five()
    {
        checkMatches[0] = true;
        checkMatches[1] = true;
        checkMatches[2] = false;
        checkMatches[3] = true;
        checkMatches[4] = false;
        checkMatches[5] = true;
        checkMatches[6] = true;
       // iFive= checkMatches;
    }
    
    private void Six()
    {
        checkMatches[0] = true;
        checkMatches[1] = true;
        checkMatches[2] = false;
        checkMatches[3] = true;
        checkMatches[4] = true;
        checkMatches[5] = true;
        checkMatches[6] = true;
      //  iSix= checkMatches;

    }

    private void Seven()
    {
        checkMatches[0] = false;
        checkMatches[1] = true;
        checkMatches[2] = true;
        checkMatches[3] = false;
        checkMatches[4] = false;
        checkMatches[5] = false;
        checkMatches[6] = true;
       // iSeven= checkMatches;

    }

    private void Eight()
    {
        checkMatches[0] = true;
        checkMatches[1] = true;
        checkMatches[2] = true;
        checkMatches[3] = true;
        checkMatches[4] = true;
        checkMatches[5] = true;
        checkMatches[6] = true;
       // iEight= checkMatches;

    }

    private void Nine()
    {
        checkMatches[0] = true;
        checkMatches[1] = true;
        checkMatches[2] = true;
        checkMatches[3] = true;
        checkMatches[4] = false;
        checkMatches[5] = true;
        checkMatches[6] = true;
       // iNine= checkMatches;
    }

    


}
