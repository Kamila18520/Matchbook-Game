using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:



----------------------------------------------------------------------------------------------------------- */
public class MarkMatches : MonoBehaviour
{
    public bool isPressed;

    public int ClickController;
    public int ClickCounter;

    public string difficulty;


    public void Start()
    {
        difficulty = ModeDifManager.difficulty;
        ClickController = 1;
        ClickCounter = 0;
        isPressed= false;
    }

    public void EnableIfIsPressed()
    {
        foreach (Transform child in transform)
        {
            foreach(Transform grandchild in child)
            {
                if(grandchild.GetComponent<ClickController>()!=null) 
                { 
                    if(grandchild.GetComponent<ClickController>().isPressed)
                    {
                        grandchild.GetComponent<ClickController>().isPressed=false;
                        grandchild.GetComponent<ClickController>().StopAnimation();

                    }
                    
                   
                
                }
            }
    
    
        }
    }

    public void DisableMatchIfIsPressed()
    {
        foreach (Transform child in transform) 
        {
            foreach (Transform grandchild in child)
            {
                if (grandchild.GetComponent<ClickController>() != null)
                {
                    if (grandchild.GetComponent<ClickController>().isPressed)
                    {
                        grandchild.GetComponent<ClickController>().isPressed = false;
                        grandchild.GetComponent<ClickController>().StopAnimation();
                        grandchild.GetComponent<SpriteRenderer>().enabled=false;

                    }

                }
            }

        }
    }

}
