using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyTerm
{
    protected string linguisticVariable;
    protected AnimationCurve membershipFunction; 
    public float DOM { get; protected set; }

    /// <summary>
    /// Apply fuzzy AND function, returns the fuzzySet with the lowest DOM
    /// </summary>
    public static FuzzySet AND(FuzzySet input1, FuzzySet input2)
    {
        if (input1.DOM < input2.DOM)
            return input1;
        else
            return input2; 
    }

 
    public static FuzzySet OR(FuzzySet input1, FuzzySet input2)
    {
        if (input1.DOM > input2.DOM)
            return input1;
        else
            return input2;
    }

    private float ORDOM(float otherDOM)
    {
        if (this.DOM > otherDOM)
            return this.DOM;
        else
            return otherDOM;
    }

    public void ORwithDOM(float value)
    {
        DOM = ORDOM(value);
    }
}
