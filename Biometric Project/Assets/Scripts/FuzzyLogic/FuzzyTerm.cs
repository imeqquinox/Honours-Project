using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyTerm : MonoBehaviour
{
    //Type T = typeof(struct); 

    // FuzzySet input1, FuzzySet input2
    // AnimationCurve input1? 
    public static FuzzyVariable<T> AND<T>(FuzzyVariable<T> input) where T : struct
    {
        // float var1 = input1.evaluate();
        // float var2 = input2.evaluate();
        // return Mathf.Clamp01(Mathf.Min(var1, var2));
        return input;
    }

    // FuzzySet input
    public static float NOT()
    {
        //float var = Mathf.Clamp01(input.evaluate());
        return 0f; 
    }

    // FuzzySet input1, FuzzySet input2
    public static float OR()
    {
        // float var1 = input.evaluate(); 
        // float var2 = input.evaluate(); 
        // return Mathf.Clamp01(Mathf.Max(var1, var2)); 
        return 0f; 
    }
}
