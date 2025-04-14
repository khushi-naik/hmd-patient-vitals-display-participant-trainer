using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class BackButtonScript : MonoBehaviour
{
    public TextMeshProUGUI testing;
    //public TextMeshProUGUI probeAlertText;
    private Coroutine backButtonCoroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnSelectEntered(SelectEnterEventArgs _)
    {
        //testing.text = "started";
        if (backButtonCoroutine != null)
        {
            StopCoroutine(backButtonCoroutine);
            backButtonCoroutine = null;
        }
        backButtonCoroutine = StartCoroutine(countDownFunction());
        //gameObject.SetActive(false);
        //set global variable to start experiment sequence


    }

    IEnumerator countDownFunction()
    {
        //testing.text = "in 2";
        //yield return new WaitForSeconds(1);
        testing.text = "in 1";
        yield return new WaitForSeconds(1);

        //CommonPrototypeVariables.isExperimentStarted = true;
        if (CommonPrototypeVariables.trainingAnimationIndex - 1 >= 0 && CommonPrototypeVariables.trainingAnimationIndex - 1 <= 6)
        {
            CommonPrototypeVariables.trainingAnimationIndex -= 1;
        }
        
        backButtonCoroutine = null;
        testing.text = "back";
        //gameObject.SetActive(false);

    }
}
