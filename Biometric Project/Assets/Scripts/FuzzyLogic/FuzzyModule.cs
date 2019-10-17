using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyModule : MonoBehaviour
{
    enum Desirability { Undersirable, Desirable, VeryDesirable };

   
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
