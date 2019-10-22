using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyRule<T> where T : struct
{
    public FuzzyTerm outputLinguisticVariable { get; private set; }
    public FuzzyTerm Expression { get; private set; }

    public FuzzyRule(FuzzyTerm outputVar, FuzzyTerm exp)
    {
        outputLinguisticVariable = outputVar;
        Expression = exp; 
    }

    public void Calculate()
    {
        // Follow calculation stuff from book 
        // consequence.dom = fuzzyterm.or(antecedent.dom, consequence.dom); 
    }

}
