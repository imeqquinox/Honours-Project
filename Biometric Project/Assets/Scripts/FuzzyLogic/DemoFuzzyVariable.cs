using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoFuzzyVariable 
{
    private FuzzySet[] sets = new FuzzySet[4];
    private int index = 0; 

    public void Set(string linguisticVariable, AnimationCurve fx)
    {
        this.Set(new FuzzySet(linguisticVariable, fx)); 
    }

    public void Set(FuzzySet fuzzySet)
    {
        if (fuzzySet == null)
            return;

        this.sets[index] = fuzzySet;
        index++; 
    }

    public void Evaluate(float x)
    {
        for (int i = 0; i < this.sets.Length; i++)
        {
            sets[i].Evaulate(x); 
        }
    }

    public void ClearDOMS()
    {
        for (int i = 0; i < this.sets.Length; i++)
        {
            sets[i].ClearDOM(); 
        }
    }
}
