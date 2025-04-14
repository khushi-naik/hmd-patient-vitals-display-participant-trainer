using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class O2Block1
{
    public int[] vitalValue;
    public bool isProbe;
    public O2Block1(int[] vitalValues, bool isProbeValue)
    {
        this.vitalValue = vitalValues;
        this.isProbe = isProbeValue;
    }
}

public static class O21ExperimentSequence
{
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static int o21Block1Start = 96;

    //patient 1 block 1
    public static readonly O2Block1[] o2ExperimentBlock1 =
    {
        new O2Block1(new int[]{90,90,90,90,87,86,85,83,82,79,78,77,76,75,82,85,87,88,89,89},false),     //o2-l
        new O2Block1(new int[]{90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,90,91,92,94,97},false),     //hr-h
        new O2Block1(new int[]{97,97,97,97,97,95,94,93,92,91,90,89,87,86,85,90,92,93,95,97},false),     //o2-l
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false),     //bp-h
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false),     //nothing
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false),     //hr-l
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false),     //hr-l
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false),     //bp-h
        new O2Block1(new int[]{97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97,97},false),     //hr-l
        new O2Block1(new int[]{90,90,90,90,87,86,85,83,82,79,78,77,76,75,82,85,87,88,89,89},false)      //o2-l

       
    };

   
}
