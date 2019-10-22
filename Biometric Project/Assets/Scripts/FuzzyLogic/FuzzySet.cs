using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzySet<T> where T : struct, IConvertible
{
    //public float DOM { get; private set; }
    private FuzzyVariable<T>[] variables = new FuzzyVariable<T>[3];
    private int index = 0; 

    public void Set(T linguisticVariable, AnimationCurve fx)
    {
        this.Set(new FuzzyVariable<T>(linguisticVariable, fx));
    }

    public void Set(FuzzyVariable<T> fuzzyVariable)
    {
        if (fuzzyVariable == null)
            return;

        // The order you write and setup the set is the order of the fuzzyvariables
        this.variables[index] = fuzzyVariable;
        index++; 
    }

    // Evaluate 
    public void Evaluate(float x)
    {
        for (int i = 0; i < this.variables.Length; i++)
        {
            variables[i].Evaluate(x);
        }
    }
}
