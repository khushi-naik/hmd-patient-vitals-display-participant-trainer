using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCube : MonoBehaviour
{
    public Camera mainCamera;
    public float distanceFromCamera = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.9f, 0.5f, distanceFromCamera));
        Vector3 temp = transform.position;
        
        //edgePosition.y = -temp.y;
        //edgePosition.z = -temp.z;
        //Debug.Log("position of cube " + edgePosition.x + " " + edgePosition.y + " " + edgePosition.z);
        transform.position = edgePosition;
    }
}
