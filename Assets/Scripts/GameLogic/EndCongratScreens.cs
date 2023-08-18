using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCongratScreens : MonoBehaviour
{
    public bool isWin = false;
    public bool isEnd = false;
    [SerializeField] private GameObject CongratulationScreen;
    [SerializeField] private GameObject EndGameScreen;
    [SerializeField] private GameObject ChallengeMode;
    [SerializeField] private GameObject PointsManager;
    [SerializeField] private GameObject EndGameButton;

    public void OnNextLvlScreen()
    {
        isWin= true;
        CongratulationScreen.SetActive(true);
        ChallengeMode.SetActive(false);
        PointsManager.GetComponent<Points>().SetLastLvlWin();
        gameObject.transform.GetChild(0).GetComponent<LeanTweenAnim>().WinLvlScreenAnimation();
        EndGameButton.SetActive(false);
        gameObject.GetComponent<DisableMatches>().DisableOnClickMatches();
        StartCoroutine(LoadSceneWithDelay(2.0f));
    }

    public void OnEndGameScreen()
    {      
        isEnd = true;
        PointsManager.GetComponent<Points>().SetLastLvlEndGame();
        EndGameScreen.SetActive(true);
        ChallengeMode.SetActive(false);
        EndGameButton.SetActive(false);
        gameObject.GetComponent<DisableMatches>().DisableOnClickMatches();
        gameObject.transform.GetChild(0).GetComponent<LeanTweenAnim>().EndGameScreenAnimation();
    }
    public void PlayAgain()
    {
        StartCoroutine(LoadSceneWithDelay(.5f));
    }

    private IEnumerator LoadSceneWithDelay(float delay)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(delay);

        // Load the desired scene
        SceneManager.LoadScene(1);
    }



}
