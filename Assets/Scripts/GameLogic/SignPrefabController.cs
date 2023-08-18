using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

przypisuje znak do klonu

----------------------------------------------------------------------------------------------------------- */

public class SignPrefabController : MonoBehaviour
{
    public char oryginalChar;
    public char changedChar;
    public char actualChar;

    public void ActualChar()
    {
        bool isEabled = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled;
        if (isEabled) 
        { 
            if(oryginalChar == '+' || oryginalChar == '-')
            {
                actualChar = '+';
            }
            else if( oryginalChar == 'x' || oryginalChar == '/')
            {
                actualChar = 'x';
            }
        
        }
        else
        {
            {
                if (oryginalChar == '+' || oryginalChar == '-')
                {
                    actualChar = '-';
                }
                else if (oryginalChar == 'x' || oryginalChar == '/')
                {
                    actualChar = '/';
                }

            }
        }
    }
}
