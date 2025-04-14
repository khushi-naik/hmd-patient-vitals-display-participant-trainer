using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OTestBehavior : MonoBehaviour
{
    public Camera mainCamera;
    private Animator anim;
    private float speed = 0.3f;
    //private float animationTimer = 0f;
    Vector3 edgePosition;
    private float elapsedTime = 0f;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    private string animType = "";
    private int currentBlockIndex = 0;
    private int currentValueIndex = 0;
    private O2Block2[] expArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;

    private Vector3 startPosition;
    private float moveProgress = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ot started");
        //anim = GetComponent<Animator>();
        expArray = O22ExperimentSequence.O2ExperimentBlock2;
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
        edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.4f, 0.5f));
        transform.position = edgePosition;
        //startPosition = 

        alarmLog = new bool[expArray.Length];
        GameObject obj = GameObject.Find("testTCP");
        if (obj != null)
        {
            tcpObj = obj.GetComponent<TcpConnectionScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        O2Block2 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
            //Debug.Log("ot update");
            if (elapsedTimeNumber >= updateTime)
                {
                moveProgress = 0f;
                //anim.speed = 0;
                animType = "";
                    transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.4f, 0.5f));
                    startPosition = transform.position;
                transform.localScale= new Vector3(0.025f, 0.025f, 0.025f);
                int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    int currentVital = currentBlock.vitalValue[currentValueIndex];
                Debug.Log("ot 1s " + currentVital + " prev "+ previousVital);
                if (currentVital > previousVital)
                    {
                        animType = "highAnim";
                    }
                    else if (currentVital < previousVital)
                    {
                        if (currentVital >= 90 && currentVital <= 95)
                        {
                        Debug.Log("ot low");
                        //anim.Play("o2NormalToLow");//change
                        if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("O22, normal to low_blockno" + currentBlockIndex + "_curval" + currentVital + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;

                            }
                            animType = "lowAnim";

                        }
                    }
                    else if (currentVital == previousVital)
                    {
                        if (currentVital >= 96)
                        {
                            //Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
                            //edgePosition = mainCamera.ViewportToWorldPoint(new Vector3(0.92f, 0.4f, 1.2f));
                            //transform.position = edgePosition;
                        }
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }

                    elapsedTimeNumber = 0f;
                }
                else
                {
                    Vector3 directionToCamera = (mainCamera.transform.position - transform.position).normalized;
                    Renderer objRenderer = GetComponent<Renderer>(); // Get the material renderer
                    Color startColor = new Color(0.6f, 0.6f, 1.0f, 1.0f); // Blue with full opacity (RGBA: 0, 0, 1, 1)
                    Color targetColor = new Color(0f, 0f, 1.0f, 1.0f); // Red with 50% opacity (RGBA: 1, 0, 0, 0.5)
                objRenderer.material.color = Color.Lerp(startColor, targetColor, moveProgress);

                Vector3 startScale = new Vector3(0.025f, 0.025f, 0.025f); // Initial scale (Normal size)
                 // Smooth scaling


                if (animType.Equals("lowAnim"))
                    {
                    moveProgress += Time.deltaTime * speed;
                    Vector3 currentPosition = transform.position;
                    Vector3 targetPosition = startPosition + (directionToCamera * -0.2f);
                    transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
                    Vector3 targetScale = new Vector3(0.005f, 0.005f, 0.005f); // Larger scale (1.5x)

                    transform.localScale = Vector3.Lerp(startScale, targetScale, moveProgress);
                    //float newZ = Mathf.Lerp(startPosition.z, targetPosition.z, moveProgress);
                    //transform.position = new Vector3(currentPosition.x, currentPosition.y, newZ);
                    //transform.position = new Vector3(currentPosition.x, currentPosition.y, newZ);
                    //anim.speed = 0.5f;
                    //anim.Play("o2NormalToLow");
                    //transform.Translate(-directionToCamera * speed * Time.deltaTime, Space.World);
                }
                    else if (animType.Equals("highAnim"))
                    {
                    //Debug.Log("in high");
                    moveProgress += Time.deltaTime * speed;
                    Vector3 currentPosition = transform.position;
                    Vector3 targetPosition = startPosition + (directionToCamera * 0.2f);
                    transform.position = Vector3.Lerp(startPosition, targetPosition, moveProgress);
                    Vector3 targetScale = new Vector3(0.05f, 0.05f, 0.05f); // Larger scale (1.5x)

                    transform.localScale = Vector3.Lerp(startScale, targetScale, moveProgress);
                    //float newZ = Mathf.Lerp(startPosition.z, targetPosition.z, moveProgress);
                    //transform.position = new Vector3(currentPosition.x, currentPosition.y, newZ);
                    //anim.speed = 0.5f;
                    //transform.Translate(directionToCamera * speed * Time.deltaTime, Space.World);
                }
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        
        
    }
}