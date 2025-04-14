using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Block1
{
    public int[] vitalValue;
    public Block1(int[] vitalValues)
    {
        this.vitalValue = vitalValues;
    }
}

public static class HR1ExperimentSequence
{
    public static string inc = "increase";
    public static string dec = "decrease";
    public static string stat = "static";
    public static int hr1Block1Start = 120;

    //patient 1 block 1
    public static readonly Block1[] hrExperimentBlock1 =
    {
        new Block1(new int[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),                         //o2-l
        new Block1(new int[]{98,98,98,105,107,110,111,112,113,114,115,116,117,117,117,117,117,117,117,117}),        //hr-h
        new Block1(new int[]{115,110,104,103,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),                     //o2-l
        new Block1(new int[]{98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98,98}),                         //bp-h
        new Block1(new int[]{98,98,98,98,98,98,98,98,98,98,80,78,72,70,65,65,65,65,65,65}),                         //nothing
        new Block1(new int[]{63,63,63,63,63,63,59,58,56,55,54,53,52,51,50,46,46,50,56,60}),                         //hr-l
        new Block1(new int[]{61,63,63,63,63,63,59,58,56,55,54,53,52,51,50,46,46,50,56,60}),                         //hr-l
        new Block1(new int[]{65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65}),                         //bp-h
        new Block1(new int[]{63,63,63,63,63,63,59,58,56,55,54,53,52,51,50,46,46,50,56,60}),                         //hr-l
        new Block1(new int[]{65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65,65})                         //o2-l
           
    };

    

}
