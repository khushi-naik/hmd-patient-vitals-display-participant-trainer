using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TestDwellBehavior : MonoBehaviour
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

    private Material material;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

    public void OnSelectEntered(SelectEnterEventArgs _)
    {
        //material.color = onSelectColor;
        //textDesc.SetActive(true);
        textHr.enabled = true;
        textHr.text = "tt";

        textBp.enabled = true;
        textBp.text = "tt";

        textO2.enabled = true;
        textO2.text = "tt";


    }

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

