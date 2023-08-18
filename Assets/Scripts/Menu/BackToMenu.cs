using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{

    public void BackToMenuByButton()
    {
        StartCoroutine(WaitForOneSec());
        

    }

    private IEnumerator WaitForOneSec()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene(0);
    }
}
