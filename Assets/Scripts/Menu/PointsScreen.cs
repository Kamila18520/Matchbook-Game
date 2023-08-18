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
   // [SerializeField] private TextMeshProUGUI[] LvlButtons;
    // [SerializeField] private GameObject test;
   // [SerializeField] private GameObject GameManager;
  //  public string chosenMode;

    // Start is called before the first frame update
    void Start()
    {



        challengeEasy = PlayerPrefs.GetInt("ChallengeEasy");
        challengeMedium = PlayerPrefs.GetInt("ChallengeMedium");
        challengeHard = PlayerPrefs.GetInt("ChallengeHard");

        peacefulEasy = PlayerPrefs.GetInt("PeacefulEasy");
        peacefulMedium = PlayerPrefs.GetInt("PeacefulMedium");
        peacefulHard = PlayerPrefs.GetInt("PeacefulHard");

        ScorePeaceful.GetComponent<TextMeshProUGUI>().text = "Peaceful Mode:\r\nEasy:\r\n" + PlayerPrefs.GetInt("PeacefulEasy") + "\r\nMedium:\r\n" + PlayerPrefs.GetInt("PeacefulMedium") + "\r\nHard:\r\n" + PlayerPrefs.GetInt("PeacefulHard"); ;
        ScoreChallenge.GetComponent<TextMeshProUGUI>().text = "Challenge Mode:\r\nEasy:\r\n" + PlayerPrefs.GetInt("ChallengeEasy") + "\r\nMedium:\r\n" + PlayerPrefs.GetInt("ChallengeMedium") + "\r\nHard:\r\n" + PlayerPrefs.GetInt("ChallengeHard");


    }
}
