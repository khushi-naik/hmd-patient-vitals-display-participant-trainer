using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextGazeBehavior : MonoBehaviour
{
    [Tooltip("hr Text")]
    [SerializeField]
    private TextMeshProUGUI textHr;

    [Tooltip("bp Text")]
    [SerializeField]
    private TextMeshProUGUI textBp;

    [Tooltip("o2 Text")]
    [SerializeField]
    private TextMeshProUGUI textO2;

    public TextMeshProUGUI consoleObj;

    private Coroutine visibilityCoroutine;
    private bool flag;

    public void OnGazeHoverEntered()
    {

        flag = true;
        //consoleObj.text = flag.ToString();
        CommonPrototypeVariables.hasSeenText = true;
        //textDesc.GetComponent<BoxCollider>().enabled = true;
        //textDesc.text = "text2";
        //material.color = onHoverColor;
    }

    public void OnGazeHoverExited()
    {
        //textDesc.text = "text333!";
        Debug.Log("exittttttt!!! ");

        flag = false;
        //consoleObj.text = flag.ToString();
        if (visibilityCoroutine != null)
        {
            StopCoroutine(visibilityCoroutine);
            visibilityCoroutine = null;
        }
        visibilityCoroutine = StartCoroutine(waiter());
        //deb.text = "routine! " + flag;
        /*if (visibilityCoroutine == null)
        {
            visibilityCoroutine = StartCoroutine(waiter());
        }*/

        //deb.text = "text disabled";
        //textDesc.enabled = false;
        //material.color = idleStateColor;
    }

    IEnumerator waiter()
    {

        Debug.Log("enter sleep ");
        //Wait for 4 seconds
        yield return new WaitForSeconds(4);
        //deb.text = "wait over";
        Debug.Log("about toooo false ");
        if (flag == false)
        {
            //deb.text = "disabling all..";
            textHr.GetComponent<BoxCollider>().enabled = false;
            textHr.enabled = false;
            textBp.enabled = false;
            textO2.enabled = false;
            CommonPrototypeVariables.hasSeenText = false;
        }
        visibilityCoroutine = null;
        //textDesc.enabled = false;
    }

}
