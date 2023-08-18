using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject Mode;
    [SerializeField] GameObject Dif;
    [SerializeField] GameObject Settings;
    [SerializeField] GameObject Score;
    [SerializeField] GameObject back;

    List<Action> methodList = new List<Action>();
    private int methodNumber;

    public float maxScale = 1.15f;
    public float pulseDuration = 1.5f;

    private Vector3 originalScale;

    private void Start()
    {
        methodList.Add(() => ChoseMode());
        methodList.Add(() => ShowScore());
        methodList.Add(() => ShowSettings());
        methodList.Add(() => ChoseDif());
        methodList.Add(() => BackToMenu());
        originalScale = transform.localScale;
       

    }
    public void LoadLevel()
    {
        StartCoroutine(WaitForOneSec());
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator WaitForOneSec()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(1);
    }

    public void ChoseMode()
    {
        methodNumber = 0;
        StartCoroutine(Wait());

    }

    public void ShowScore() 
    {
        methodNumber = 1;
        StartCoroutine(Wait());

    }

    public void ShowSettings()
    {
        methodNumber = 2;
        StartCoroutine(Wait());

    }

    public void ChoseDif()
    {
        methodNumber = 3;
        StartCoroutine(Wait());
    }

    public void BackToMenu()
    {
        methodNumber = 4;
        StartCoroutine(Wait());

    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.3f);

        switch(methodNumber) 
        {
            case 0:
                
                Menu.SetActive(false);
                Mode.SetActive(true);
                foreach (Transform child in Mode.transform)
                {
                    if (child.GetComponent<ButtonsAnimation>() != null && child.GetComponent<ButtonsAnimation>().wasActive == true)
                    {
                        child.GetComponent<ButtonsAnimation>().StartAnim();
                    }
                }
                Dif.SetActive(false);
                back.SetActive(true);
                break;
                
            case 1:

                Menu.SetActive(false);
                Score.SetActive(true);
                back.SetActive(true);
                break;

            case 2:

                Menu.SetActive(false);
                Settings.SetActive(true);
                back.SetActive(true);
                break;

            case 3:

                Mode.SetActive(false);
                Dif.SetActive(true);
                foreach (Transform child in Dif.transform)
                {
                    if (child.GetComponent<ButtonsAnimation>() != null && child.GetComponent<ButtonsAnimation>().wasActive == true)
                    {
                        child.GetComponent<ButtonsAnimation>().StartAnim();
                    }
                }
                back.SetActive(true);
                break;

            case 4:

                Menu.SetActive(true);
             //  foreach (Transform child in Menu.transform)
             //  {
             //      if (child.GetComponent<ButtonsAnimation>() != null && child.GetComponent<ButtonsAnimation>().wasActive == true)
             //      {
             //          child.GetComponent<ButtonsAnimation>().StartAnim();
             //      }
             //  }
                Mode.SetActive(false);
                Dif.SetActive(false);
                Settings.SetActive(false);
                Score.SetActive(false);
                back.SetActive(false);
                break;


        }
    }





}
