using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyRule
{
    public FuzzyTerm antecedent { get; private set; } 
    public FuzzyTerm consequence { get; private set; }

    public FuzzyRule(FuzzyTerm input, FuzzyTerm output)
    {
        this.antecedent = input;
        this.consequence = output; 
    }

    public void Calculate()
    {
        consequence.ORwithDOM(antecedent.DOM);
    }

}
