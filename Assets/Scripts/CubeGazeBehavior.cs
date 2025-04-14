using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CubeGazeBehavior : MonoBehaviour
{
    public TextMeshProUGUI textCb;
    // Start is called before the first frame update

    private void Awake()
    {
        textCb.enabled = false;
    }

    public void OnGazeHoverEntered()
    {
        textCb.enabled = true;
    }
    public void OnGazeHoverExited()
    {
        textCb.enabled = false;
    }
}
