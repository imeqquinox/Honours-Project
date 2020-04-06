using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Fuzzy variable acts a linguistic variable for array of fuzzy sets ie// Ammo Status (Low, Okay, Loads) 
/// </summary>
public class FuzzyVariable
{
    //private FuzzySet[] sets = new FuzzySet[5];
    private FuzzySet[] sets; 
    private int index = 0; 

    public void SetsInit(int value)
    {
        sets = new FuzzySet[value];
    }

    public void Set(string linguisticVariable, AnimationCurve fx)
    {
        this.Set(new FuzzySet(linguisticVariable, fx));
    }

    public void Set(FuzzySet fuzzySet)
    {
        if (fuzzySet == null)
            return;

        // The order you write and setup the set is the order of the fuzzysets 
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

    public void ClearDOMs()
    {
        for (int i = 0; i < this.sets.Length; i++)
        {
            sets[i].ClearDOM();
        }
    }
}

