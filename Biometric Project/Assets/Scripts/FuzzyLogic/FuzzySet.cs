using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fuzzy Set which acts as a single membershipfunction within a fuzzy variable
/// </summary>
public class FuzzySet : FuzzyTerm
{
    public FuzzySet(string linguisticVariable, AnimationCurve membershipFunction)
    {
        this.linguisticVariable = linguisticVariable;
        this.membershipFunction = membershipFunction; 
    }

    public void Evaulate(float x)
    {
        this.DOM = membershipFunction.Evaluate(x);
        //Debug.Log(DOM.ToString("F4"));
    }

    public void ClearDOM()
    {
        this.DOM = 0; 
    }
}
