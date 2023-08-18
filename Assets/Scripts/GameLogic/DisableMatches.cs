using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

uniemo¿liwia klikniêcie na zapalki po wygranej/przegranej


----------------------------------------------------------------------------------------------------------- */

public class DisableMatches : MonoBehaviour
{
    [SerializeField] GameObject NumbersContainer;



    public void DisableOnClickMatches()
    {
        foreach(Transform child in NumbersContainer.transform) 
        { 
            foreach(Transform grandchild in child)
            {
                if(grandchild.GetComponent<BoxCollider2D>() != null)
                {
                    grandchild.GetComponent<BoxCollider2D>().enabled= false;
                }
            }
        }

    }
}
