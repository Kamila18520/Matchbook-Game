using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsScreen : MonoBehaviour
{
    [SerializeField] private int challengeEasy;
    [SerializeField] private int challengeMedium;
    [SerializeField] private int challengeHard;
    [SerializeField] private int peacefulEasy;
    [SerializeField] private int peacefulMedium;
    [SerializeField] private int peacefulHard;
    [SerializeField] private GameObject ScorePeaceful;
    [SerializeField] private GameObject ScoreChallenge;
    private string mode;
    [SerializeField] TextMeshProUGUI easyText;
    [SerializeField] TextMeshProUGUI mediumText;
    [SerializeField] TextMeshProUGUI hardText;
    [SerializeField] TextMeshProUGUI modeText;
    // [SerializeField] private TextMeshProUGUI[] LvlButtons;
    // [SerializeField] private GameObject test;
    // [SerializeField] private GameObject GameManager;
    //  public string chosenMode;

    // Start is called before the first frame update
    public void Start()
    {



        challengeEasy = PlayerPrefs.GetInt("ChallengeEasy");
        challengeMedium = PlayerPrefs.GetInt("ChallengeMedium");
        challengeHard = PlayerPrefs.GetInt("ChallengeHard");
        peacefulEasy = PlayerPrefs.GetInt("PeacefulEasy");
        peacefulMedium = PlayerPrefs.GetInt("PeacefulMedium");
        peacefulHard = PlayerPrefs.GetInt("PeacefulHard");

        ScorePeaceful.GetComponent<TextMeshProUGUI>().text = "Peaceful Mode:\r\nEasy:\r\n" + PlayerPrefs.GetInt("PeacefulEasy") + "\r\nMedium:\r\n" + PlayerPrefs.GetInt("PeacefulMedium") + "\r\nHard:\r\n" + PlayerPrefs.GetInt("PeacefulHard");
        ScoreChallenge.GetComponent<TextMeshProUGUI>().text = "Challenge Mode:\r\nEasy:\r\n" + PlayerPrefs.GetInt("ChallengeEasy") + "\r\nMedium:\r\n" + PlayerPrefs.GetInt("ChallengeMedium") + "\r\nHard:\r\n" + PlayerPrefs.GetInt("ChallengeHard");




    }


    public void ButtonPacefulText()
    {
            easyText.text = "Easy\r\n highest lvl: " + peacefulEasy;
            mediumText.text = "Medium\r\n highest lvl: " + peacefulMedium;
            hardText.text = "Hard\r\n highest lvl: " + peacefulHard;
        Mode();
    }

    public void ButtonChallengeText()
    {
            easyText.text = "Easy\r\n highest lvl: " + challengeEasy;
            mediumText.text = "Medium\r\n highest lvl: " + challengeMedium;
            hardText.text = "Hard\r\n highest lvl: " + challengeHard;
        Mode();
    }

    private void Mode()
    {

        modeText.text = "mode: \r\n" + ModeDifManager.mode;
    }
}
