using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class StartExperimentSceneScript : MonoBehaviour
{
    public TextMeshProUGUI testing;
    public TextMeshProUGUI probeAlertText;
    private Coroutine experimentCountdownCoroutine;

    void Start()
    {
        probeAlertText.enabled = false; //keep alert hidden till a probe occurs
    }

    public void OnSelectEntered(SelectEnterEventArgs _)
    {
        testing.text = "started";
        if(experimentCountdownCoroutine != null)
        {
            StopCoroutine(experimentCountdownCoroutine);
            experimentCountdownCoroutine = null;
        }
        experimentCountdownCoroutine = StartCoroutine(countDownFunction());
        //gameObject.SetActive(false);
        //set global variable to start experiment sequence


    }

    IEnumerator countDownFunction()
    {
        //testing.text = "starting in 4";
        //yield return new WaitForSeconds(1);
        testing.text = "starting in 3";
        yield return new WaitForSeconds(1);
        testing.text = "starting in 2";
        yield return new WaitForSeconds(1);
        testing.text = "starting in 1";
        yield return new WaitForSeconds(1);

        //CommonPrototypeVariables.trainingAnimationIndex = 0;
        CommonPrototypeVariables.isExperimentStarted = true;
        experimentCountdownCoroutine = null;
        gameObject.SetActive(false);

    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
