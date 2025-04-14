using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;

public class DwellBehavior : MonoBehaviour
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

    public TextMeshProUGUI conObj;

    private Material material;
    private Coroutine resetTextCoroutine;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        textHr.enabled = false;
        textHr.GetComponent<BoxCollider>().enabled = false;
        textBp.enabled = false;
        textO2.enabled = false;
    }

    public void OnSelectEntered(SelectEnterEventArgs _)
    {
        //material.color = onSelectColor;
        //textDesc.SetActive(true);
        textHr.enabled = true;
        textHr.text = "HR: " + HR1ExperimentSequence.hr1Block1Start.ToString();

        textBp.enabled = true;
        textBp.text = "BP: " + Bp1ExperimentSequence.bp1Block1Start.ToString();

        textO2.enabled = true;
        textO2.text = "O2: " + O21ExperimentSequence.o21Block1Start.ToString();

        textHr.GetComponent<BoxCollider>().enabled = true;
        //conObj.text = "activated " + textHr.GetComponent<BoxCollider>().enabled.ToString()+ " "+ _.interactorObject.transform.name;
        if (resetTextCoroutine != null)
        {
            StopCoroutine(resetTextCoroutine);
            resetTextCoroutine = null;
        }
        resetTextCoroutine = StartCoroutine(waiterCountdown());

    }

    //if user does not look at text, disable text in 5 secs
    IEnumerator waiterCountdown()
    {

        //Debug.Log("enter sleep ");
        //Wait for 4 seconds
        //conObj.text = "before countdown";
        yield return new WaitForSeconds(2);
        //deb.text = "wait over";
        //Debug.Log("about toooo false ");
        if (CommonPrototypeVariables.hasSeenText == false)
        {
            //deb.text = "disabling all..";
            textHr.GetComponent<BoxCollider>().enabled = false;
            textHr.enabled = false;
            textBp.enabled = false;
            textO2.enabled = false;
        }
        resetTextCoroutine = null;
        //conObj.text = "afterrr countdown";
        //textDesc.enabled = false;
    }

    /*public void OnSelectEntered(SelectEnterEventArgs _)
    {
        //material.color = onSelectColor;
        //textDesc.SetActive(true);
        textHr.enabled = true;
        textHr.text = "HR: 60";

        textBp.enabled = true;
        textBp.text = "BP: "+ Bp1ExperimentSequence.bp1Block1Start.ToString();

        textO2.enabled = true;
        textO2.text = "O2: "+ O21ExperimentSequence.o21Block1Start.ToString();


    }*/

    /// <summary>
    /// Triggered when the attached <see cref="StatefulInteractable"/> is de-selected.
    /// </summary>
    public void OnSelectExited(SelectExitEventArgs _)
    {
        textHr.enabled = false;
        textBp.enabled = false;
        textO2.enabled = false;
        //material.color = idleStateColor;
        //textDesc.SetActive(false);
        //textDesc.text = "not anymore";
    }
}

