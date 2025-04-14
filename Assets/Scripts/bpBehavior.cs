using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


public class bpBehavior : MonoBehaviour
{
    private Animator anim;
    private float elapsedTime = 0f;
    public TextMeshProUGUI textBp;
    private float updateTime = 1f;
    private float elapsedTimeNumber = 0f;
    //Bp1Block[] testArray;
    int currentBlockIndex = 0;
    int currentValueIndex = 0;
    private string previousTrend = "";
    int prevValue = 0;
    private BpBlock1[] expArray;
    private bool[] alarmLog;
    private TcpConnectionScript tcpObj;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        expArray = Bp1ExperimentSequence.BpExperimentBlock1;
        textBp.enabled = false;
        alarmLog = new bool[expArray.Length];

        GameObject obj = GameObject.Find("testTCP");
        if (obj != null)
        {
            tcpObj = obj.GetComponent<TcpConnectionScript>();
        }
    }

    void Update()
    {
        if (CommonPrototypeVariables.isExperimentStarted)
        {
            BpBlock1 currentBlock = expArray[currentBlockIndex];
            if (currentBlockIndex < expArray.Length)
            {
                if (elapsedTimeNumber >= updateTime)
                {
                    int previousVital = currentBlock.vitalValue[Mathf.Max(currentValueIndex - 1, 0)];
                    Bp1ExperimentSequence.bp1Block1Start = currentBlock.vitalValue[currentValueIndex];
                    if (Bp1ExperimentSequence.bp1Block1Start > previousVital)
                    {
                        if (Bp1ExperimentSequence.bp1Block1Start >= 138)
                        {
                            anim.speed = 1.75f;
                            anim.Play("bpNormalToHigh2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, normal to high_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + Bp1ExperimentSequence.bp1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveBp");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpReturnLowToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        
                        previousTrend = "increase";
                    }
                    else if (Bp1ExperimentSequence.bp1Block1Start < previousVital)
                    {
                        if (Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 1.75f;
                            anim.Play("bpNormalToLow2");
                            if (!alarmLog[currentBlockIndex])
                            {
                                tcpObj.sendMessage("BP1, normal to low_blockno" + currentBlockIndex + "_curval" + currentValueIndex.ToString() + "_prev" + previousVital + "_blstval" + HR1ExperimentSequence.hr1Block1Start + "," + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                alarmLog[currentBlockIndex] = true;
                            }
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveBp");
                            alarmLog[currentBlockIndex] = false;
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpReturnHighToNormal2");
                            alarmLog[currentBlockIndex] = false;
                        }
                        
                        previousTrend = "decrease";
                    }
                    else if (Bp1ExperimentSequence.bp1Block1Start == previousVital)
                    {
                        if (Bp1ExperimentSequence.bp1Block1Start > 102 && Bp1ExperimentSequence.bp1Block1Start < 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("justMoveBp");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start <= 102)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpStatNToL");
                        }
                        else if (Bp1ExperimentSequence.bp1Block1Start >= 138)
                        {
                            anim.speed = 0.5f;
                            anim.Play("bpStatNToH");
                        }
                        
                        alarmLog[currentBlockIndex] = false;
                    }
                    currentValueIndex++;
                    if (currentValueIndex >= currentBlock.vitalValue.Length)
                    {
                        currentValueIndex = 0;
                        currentBlockIndex++;
                    }
                    System.Random random = new System.Random();
                    int diastolicBpValue = random.Next(30, 51);
                    diastolicBpValue = Bp1ExperimentSequence.bp1Block1Start - diastolicBpValue;
                    textBp.text = "BP: " + Bp1ExperimentSequence.bp1Block1Start.ToString() + "/" + diastolicBpValue.ToString();
                    elapsedTimeNumber = 0f;
                }
                elapsedTimeNumber += Time.deltaTime;
            }
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 0)
        {
            anim.speed = 0.5f;
            anim.Play("justMoveBp");
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 1)
        {
            anim.speed = 1.75f;
            anim.Play("bpNormalToLow2");
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 2)
        {
            anim.speed = 0.5f;
            anim.Play("bpStatNToL");
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 3)
        {
            anim.speed = 0.5f;
            anim.Play("bpReturnLowToNormal2");
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 4)
        {
            anim.speed = 1.75f;
            anim.Play("bpNormalToHigh2");
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 5)
        {
            anim.speed = 0.5f;
            anim.Play("bpStatNToH");
        }
        else if (CommonPrototypeVariables.trainingAnimationIndex == 6)
        {
            anim.speed = 0.5f;
            anim.Play("bpReturnHighToNormal2");
        }
    
    }

}
