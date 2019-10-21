using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyModule : MonoBehaviour
{
    private FuzzyVariable desirability; 
    private FuzzyVariable distanceToTarget;
    private FuzzyVariable ammoStatus;

    [SerializeField] private AnimationCurve[] desirabilitySets; 
    [SerializeField] private AnimationCurve[] distanceToTargetSets;
    [SerializeField] private AnimationCurve[] ammoStatusSets;
    

    // List of rules m_Rules; 
    private List<FuzzyRule> rules = new List<FuzzyRule>();

    //enum Desirability { Undersirable = 0, Desirable = 1, VeryDesirable = 2 };
    //enum DistanceToTarget { Close = 0, Medium = 1, Far = 2 };
    //enum AmmoStatus { Low = 0, Okay = 1, Loads = 2 };

    private void Start()
    {
        desirabilitySets[0].
        SetupFuzzySets();
        SetupFuzzyRules();
    }

    private void SetupFuzzySets()
    {
        desirability.fuzzySets.Add(new FuzzySet("Undersirable", desirabilitySets[0]));
        desirability.fuzzySets.Add(new FuzzySet("Desirable", desirabilitySets[1]));
        desirability.fuzzySets.Add(new FuzzySet("VeryDesirable", desirabilitySets[2]));

        distanceToTarget.fuzzySets.Add(new FuzzySet("Close", distanceToTargetSets[0]));
        distanceToTarget.fuzzySets.Add(new FuzzySet("Medium", distanceToTargetSets[1]));
        distanceToTarget.fuzzySets.Add(new FuzzySet("Far", distanceToTargetSets[2]));

        ammoStatus.fuzzySets.Add(new FuzzySet("Low", ammoStatusSets[0]));
        ammoStatus.fuzzySets.Add(new FuzzySet("Okay", ammoStatusSets[1]));
        ammoStatus.fuzzySets.Add(new FuzzySet("Loads", ammoStatusSets[2]));
    }

    private void SetupFuzzyRules()
    {
        rules.Add(new FuzzyRule(FuzzyTerm.AND(distanceToTarget.fuzzySets.Find(x => x.setName == "Close"),
            ammoStatus.fuzzySets.Find(x => x.setName == "Loads")), desirability.fuzzySets.Find(x => x.setName == "Undersirable")));


        float i = FuzzyTerm.AND(distanceToTarget.fuzzySets.Find(x => x.setName == "Close"),
            ammoStatus.fuzzySets.Find(x => x.setName == "Loads"));
    }

    /* Fuzzy Rules 
     * 
     * Private void Rules();
     * 
     * FuzzyRule[] rules; 
     * 
     * "IF Target_Far AND Ammo_Okay THEN Undesirable"
     * AddRule(FzAND(Target_Far, Ammo_Loads), Undesirable); 
     * 
     */

    // In defuzzfy function go through the array of rules and use calulation function
    // It's used to update DOM of sets which is used in defuzzy?
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
