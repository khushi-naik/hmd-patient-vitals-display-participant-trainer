using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BpBlock1
{
    public int[] vitalValue;
    public BpBlock1(int[] vitalValues)
    {
        this.vitalValue = vitalValues;
    }
}

public class Bp1ExperimentSequence
{
    // Start is called before the first frame update
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static int bp1Block1Start = 154;

    //patient 1 block1
    public static readonly BpBlock1[] BpExperimentBlock1 =
    {
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //o2-l
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //hr-h
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //o2-l
        new BpBlock1(new int[]{129,130,137,140,142,143,145,146,149,150,153,154,155,155,155,140,133,121,121,121}),       //bp-h
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //nothing
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //hr-l
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //hr-l
        new BpBlock1(new int[]{129,130,137,140,142,143,145,146,149,150,153,154,155,155,155,140,133,121,121,121}),      //bp-h
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129}),       //hr-l
        new BpBlock1(new int[]{129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129,129})       //o2-l
        
    };

    
}
