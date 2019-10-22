using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyVariable<T> where T : struct
{
    //public List<FuzzySet> fuzzySets = new List<FuzzySet>(); 
    public T linguisticVariable { get; private set; }
    public AnimationCurve membershipFunction { get; private set; }
    public float DOM { get; private set; }

    public FuzzyVariable(T linguisticVariable, AnimationCurve membershipFunction)
    {
        this.linguisticVariable = linguisticVariable;
        this.membershipFunction = membershipFunction; 
    }

    public void Evaluate(float x)
    {
        DOM = membershipFunction.Evaluate(x);
        Debug.Log(DOM.ToString("F4"));
    }
}
