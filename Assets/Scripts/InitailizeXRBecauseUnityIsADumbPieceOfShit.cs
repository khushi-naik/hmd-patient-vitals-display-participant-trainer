using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class InitailizeXRBecauseUnityIsADumbPieceOfShit : MonoBehaviour
{
    void Start() => StartCoroutine(StartXRRoutine());

    public IEnumerator StartXRRoutine()
    {
        var xrInstanceManager = XRGeneralSettings.Instance.Manager;
        yield return xrInstanceManager.InitializeLoader();

        if (xrInstanceManager.activeLoader != null)
        {
            xrInstanceManager.StartSubsystems();                     
        }
        else
        {
            Debug.LogError("Initializing XR Failed becuase Unity is a dumb piece of shit.");
        }
    }
}