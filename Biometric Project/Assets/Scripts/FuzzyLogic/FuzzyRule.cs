using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyRule : MonoBehaviour
{
    public FuzzySet antecedent { get; private set; }
    public FuzzySet consequence { get; private set; }

    public FuzzyRule(FuzzySet input, FuzzySet output)
    {
        antecedent = input;
        consequence = output; 
    }

    public void Calculate()
    {
        // Follow calculation stuff from book 
        // consequence.dom = fuzzyterm.or(antecedent.dom, consequence.dom); 
    }

}
