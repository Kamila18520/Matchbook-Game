using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

odpowiada za klonowanie znakow i liczb


----------------------------------------------------------------------------------------------------------- */

public class ClonePrefab : MonoBehaviour
{
    [SerializeField] private GameObject MeschSpawnArea;
    [SerializeField] private GameObject CointainerForNumbers;
    [SerializeField] private GameObject MatchPrefab;
    [SerializeField] private GameObject EqualPrefab;
    [SerializeField] private GameObject PlusMinusPrefab;
    [SerializeField] private GameObject MultiplicationPrefab;

    public float meshSpawnAreaSize;

    public char[] charsRandomEquation;
    public char[] charsChangedRandomEquation;

    public string RandomEquation;
    public string ChangedRandomEquation;


    public void Start()
    {
        Renderer MeschSpawnAreaRenderer = MeschSpawnArea.GetComponent<Renderer>();

        meshSpawnAreaSize = MeschSpawnAreaRenderer.bounds.size.x;

        Split();
        DuplicatePrefab(charsChangedRandomEquation, charsRandomEquation);
        
        

    }

    private void Split()
    {

        RandomEquation = gameObject.GetComponent<DownloadNumbers>().RandomEquation;
        ChangedRandomEquation = gameObject.GetComponent<DownloadNumbers>().ChangedRandomEquation;


        charsRandomEquation = RandomEquation.ToCharArray();
        charsChangedRandomEquation = ChangedRandomEquation.ToCharArray();


    }


    private void DuplicatePrefab(char[] charsChangedEquation, char[] charsRandomEquation)
    {
        for(int i=0; i<charsChangedEquation.Length; i++)
        { 

            Vector3 PrefabPosition = GetPrefabPosition(i);


            if (charsChangedEquation[i] =='+' || charsChangedEquation[i]=='-')
            {
                GameObject MatchPrefabClone = GameObject.Instantiate(PlusMinusPrefab, PrefabPosition, PlusMinusPrefab.transform.rotation, CointainerForNumbers.transform);

                MatchPrefabClone.GetComponent<SignPrefabController>().oryginalChar = charsRandomEquation[i];
                MatchPrefabClone.GetComponent<SignPrefabController>().changedChar = charsChangedEquation[i];
                MatchPrefabClone.GetComponent<SignPrefabController>().actualChar = charsChangedEquation[i];

                if (charsChangedEquation[i] == '-')
                {
                    MatchPrefabClone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    MatchPrefabClone.GetComponent<SignPrefabController>().oryginalChar = charsRandomEquation[i];
                    MatchPrefabClone.GetComponent<SignPrefabController>().changedChar = charsChangedEquation[i];
                    MatchPrefabClone.GetComponent<SignPrefabController>().actualChar = charsChangedEquation[i];

                }
            }

            else if (charsChangedEquation[i] == '=')
            {
                GameObject MatchPrefabClone = GameObject.Instantiate(EqualPrefab, PrefabPosition, EqualPrefab.transform.rotation, CointainerForNumbers.transform);
            }
            else if (charsChangedEquation[i]=='x' || charsChangedEquation[i] =='/')
            {
                GameObject MatchPrefabClone = GameObject.Instantiate(MultiplicationPrefab, PrefabPosition, MultiplicationPrefab.transform.rotation, CointainerForNumbers.transform);
                MatchPrefabClone.GetComponent<SignPrefabController>().oryginalChar = charsRandomEquation[i];
                MatchPrefabClone.GetComponent<SignPrefabController>().changedChar = charsChangedEquation[i];
                MatchPrefabClone.GetComponent<SignPrefabController>().actualChar = charsChangedEquation[i];

                if (charsChangedEquation[i] == '/')
                {
                    MatchPrefabClone.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    MatchPrefabClone.GetComponent<SignPrefabController>().oryginalChar = charsRandomEquation[i];
                    MatchPrefabClone.GetComponent<SignPrefabController>().changedChar = charsChangedEquation[i];
                    MatchPrefabClone.GetComponent<SignPrefabController>().actualChar = charsChangedEquation[i];

                }
            }
            else if (char.IsDigit(charsChangedEquation[i]))
            {
            GameObject MatchPrefabClone = GameObject.Instantiate(MatchPrefab, PrefabPosition, MatchPrefab.transform.rotation, CointainerForNumbers.transform) ;
            MatchPrefabClone.GetComponent<NumberPrefabController>().changedNumber = int.Parse(charsChangedEquation[i].ToString());
            MatchPrefabClone.GetComponent<NumberPrefabController>().oryginalNumber = int.Parse(charsRandomEquation[i].ToString());
            MatchPrefabClone.GetComponent<NumberPrefabController>().actualNumber = int.Parse(charsChangedEquation[i].ToString());
            }
          
        }

    }

    private Vector3 GetPrefabPosition(int index)
    {
        float partsSize = meshSpawnAreaSize / (charsRandomEquation.Length + 2);
        Vector3 areaSizeMin = MeschSpawnArea.GetComponent<Renderer>().bounds.min;
        Vector3 areaSizeCenter = MeschSpawnArea.GetComponent<Renderer>().bounds.center;


        float positionX = areaSizeMin.x;
        float positionY = areaSizeCenter.y;

        Vector3 position = new Vector3(positionX + ((index + 1) *partsSize) + (partsSize/2),positionY,0);

        return position;

    }
}
