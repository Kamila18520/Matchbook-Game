using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanTweenAnim : MonoBehaviour
{
    [SerializeField] private GameObject WinLvlScreen;
    [SerializeField] private GameObject SettingsScoreScreen;
    [SerializeField] private GameObject EndGameScreen;


    public void EndGameScreenAnimation()
    {
        Vector3 localVector = EndGameScreen.transform.localScale;
        Debug.Log(localVector);
        float scalePercent = 1.3f;
        LeanTween.scale(EndGameScreen, new Vector3(localVector.x * scalePercent, localVector.y * scalePercent, localVector.z * scalePercent), 2f).setEase(LeanTweenType.easeOutElastic);
    }

    public void WinLvlScreenAnimation()
    {
       Vector3 localVector = WinLvlScreen.transform.localScale;
       Debug.Log(localVector);
       float scalePercent = 1.3f;
       LeanTween.scale(WinLvlScreen, new Vector3(localVector.x * scalePercent, localVector.y * scalePercent, localVector.z * scalePercent), 2f).setEase(LeanTweenType.easeOutElastic);
    }


    public void SettingsScoreScreenAnimation()
    {
        Vector3 localVector = SettingsScoreScreen.transform.localScale;

        SettingsScoreScreen.transform.localScale = localVector;
        float scalePercent = 1.3f;
        SettingsScoreScreen.transform.localScale = new Vector3(localVector.x * scalePercent, localVector.y * scalePercent, localVector.z * scalePercent);
        LeanTween.scale(SettingsScoreScreen, localVector, 2f).setEase(LeanTweenType.easeOutElastic);
    }
}
