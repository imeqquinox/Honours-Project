using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyModule : MonoBehaviour
{
    private FuzzySet _distanceToTarget; 

    enum Desirability { Undersirable = 0, Desirable = 1, VeryDesirable = 2 };
    enum DistanceToTarget { Close = 0, Medium = 1, Far = 2 };
    enum AmmoStatus { Low = 0, Okay = 1, Loads = 2 };

    private void Update()
    {
        int help = _distanceToTarget.membershipFunctions[(int)DistanceToTarget.Far].length;
    }

    /* Fuzzy Rules 
     * 
     * Private void Rules();
     * 
     * FuzzyRule[] rules; 
     * 
     * "IF Target_Far AND Ammo_Okay THEN Undesirable
     * "FuzzySetName.Undersirable.Evalutate("Result of"FuzzyOps.And(DistanceToTarget.Far, Ammo.Okay));
     * rule[0] = Desirability.Undersirable.Evalutate(And(DistanceToTarget.Far, AmmoStatus.Okay)); 
     * 
     * 
     */

    /* Fuzzy Rule Evaluation
     * 
     * Private void RuleEvaluation();
     * 
     */
}

// setup of map of fuzzy variables? map(string, fuzzyVariable*)

// DefuzzifyType either max_AV or centroid; (enum)
// cross sections required for smapling centroid; (double check about centroid calculation) 

// map of all fuzzy varaibles this module uses
// map(string, fuzzyVariable) m_variables; 

// vector containing all fuzzy rules
// vector<FuzzyRule> m_Rules; 

// zero the DOMs of consequents of each rule. Used by defuzzify()? 

// create new "empty" fuzzy variable
// fuzzyVariable CreateFLV(string VarName); 

// Add rule to module
// void AddRule(FuzzyTerm input, FuzzyTerm output) 

// Fuzzy function 
// void Fuzzify(string NameOfFLV, double value); 

// given a fuzzy variable and a defuzzification method this returns a crisp value
// double Defuzzify(const string key, DefuzzifyType method); 
