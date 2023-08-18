using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

timer trybu Challenge
jesli czas si� sko�czy to wy�wietla sie GameOver



----------------------------------------------------------------------------------------------------------- */

public class Timer : MonoBehaviour
{
    [SerializeField] string chosenMode;
    [SerializeField] float countdownTime = 30.0f;
    [SerializeField] int timeInInt;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] private GameObject timer;
    [SerializeField] private float initialScaleX;
    [SerializeField] private float initialScaleY;
    [SerializeField] private float targetScaleX = 0f;
    [SerializeField] private float scaleDuration;
    public GameObject points;
    [SerializeField] private GameObject ScreenController;


    private Vector3 initialScale;
    private float elapsedTime;

    private Transform firstChild;

    void Start()
    {
        initialScaleX = gameObject.transform.GetChild(0).localScale.x;
        initialScaleY = gameObject.transform.GetChild(0).localScale.y;

        scaleDuration = countdownTime;

        chosenMode = ModeDifManager.mode;

        if (chosenMode == "Peaceful")
        {
            gameObject.SetActive(false);
        }

        initialScale = transform.localScale;
        firstChild = transform.GetChild(0);
    }

    void Update()
    {
        countdownTime -= Time.deltaTime; // Odejmowanie czasu odliczania
        timeInInt = Mathf.RoundToInt(countdownTime);
        timer.GetComponent<TextMeshProUGUI>().text = timeInInt.ToString();

        if (countdownTime <= 0f)
        {
            countdownTime = 0f; // Zapobieganie ujemnemu czasowi odliczania
            Debug.Log("CHALLENGE MODE: Czas minal!"); // Wy�wietlenie komunikatu po zako�czeniu odliczania

            ScreenController.GetComponent<EndCongratScreens>().OnEndGameScreen();
           
            timer.SetActive(false);
            

        }
        else
        {
            Debug.Log("CHALLENGE MODE: Gra trwa!");
            // Skalowanie pierwszego dziecka wzd�u� osi X wraz z up�ywem czasu
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / scaleDuration);
            float scaleX = Mathf.Lerp(initialScaleX, targetScaleX, t);
            firstChild.localScale = new Vector3(scaleX, initialScaleY, initialScale.z);
        }
    }


  // public void WinGame()
  // {
  //     gameObject.SetActive(false);
  // }
}
