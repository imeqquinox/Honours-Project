using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyModule : MonoBehaviour
{
    enum Desirability { Undersirable, Desirable, VeryDesirable };
    enum DistanceToTarget { Close, Medium, Far };
    enum AmmoStatus { Low, Okay, Loads };

    //private FuzzyVariable desirability; 
    //private FuzzyVariable distanceToTarget;
    //private FuzzyVariable ammoStatus;

    [SerializeField] private AnimationCurve[] desirabilitySets; 
    [SerializeField] private AnimationCurve[] distanceToTargetSets;
    [SerializeField] private AnimationCurve[] ammoStatusSets;
    
    // List of rules m_Rules; 
    //private List<FuzzyRule> rules = new List<FuzzyRule>();

    private FuzzySet<Desirability> GetDesirabilitySet()
    {
        FuzzySet<Desirability> set = new FuzzySet<Desirability>();
        set.Set(new FuzzyVariable<Desirability>(Desirability.Undersirable, desirabilitySets[0]));
        set.Set(new FuzzyVariable<Desirability>(Desirability.Desirable, desirabilitySets[1]));
        set.Set(new FuzzyVariable<Desirability>(Desirability.VeryDesirable, desirabilitySets[2]));
        return set;
    }

    private FuzzySet<DistanceToTarget> GetDistanceToTargetSet()
    {
        FuzzySet<DistanceToTarget> set = new FuzzySet<DistanceToTarget>();
        set.Set(new FuzzyVariable<DistanceToTarget>(DistanceToTarget.Close, distanceToTargetSets[0]));
        set.Set(new FuzzyVariable<DistanceToTarget>(DistanceToTarget.Medium, distanceToTargetSets[1]));
        set.Set(new FuzzyVariable<DistanceToTarget>(DistanceToTarget.Far, distanceToTargetSets[2]));
        return set;
    }

    private FuzzySet<AmmoStatus> GetAmmoStatusSet()
    {
        FuzzySet<AmmoStatus> set = new FuzzySet<AmmoStatus>();
        set.Set(new FuzzyVariable<AmmoStatus>(AmmoStatus.Low, ammoStatusSets[0]));
        set.Set(new FuzzyVariable<AmmoStatus>(AmmoStatus.Okay, ammoStatusSets[1]));
        set.Set(new FuzzyVariable<AmmoStatus>(AmmoStatus.Loads, ammoStatusSets[2]));
        //set.Set(AmmoStatus.Low, ammoStatusSets[0]);
        //set.Set(AmmoStatus.Okay, ammoStatusSets[1]);
        //set.Set(AmmoStatus.Loads, ammoStatusSets[2]);
        return set;
    }

    private FuzzyRule<Desirability>[] getRules()
    {
        FuzzyRule<Desirability>[] rules = new FuzzyRule<Desirability>[9];
        // rules[0] = new FuzzyRule(FuzzyTerm.And(fuzzyVariable1, fuzzyVariable2), outputVar);

        return rules;
    }

    public void Fuzzy()
    {
        FuzzySet<AmmoStatus> ammoSet = GetAmmoStatusSet();
        ammoSet.Evaluate(8);
    }
}
//private void SetupFuzzySets()
//{
//    desirability.fuzzySets.Add(new FuzzySet("Undersirable", desirabilitySets[0]));
//    desirability.fuzzySets.Add(new FuzzySet("Desirable", desirabilitySets[1]));
//    desirability.fuzzySets.Add(new FuzzySet("VeryDesirable", desirabilitySets[2]));

//    distanceToTarget.fuzzySets.Add(new FuzzySet("Close", distanceToTargetSets[0]));
//    distanceToTarget.fuzzySets.Add(new FuzzySet("Medium", distanceToTargetSets[1]));
//    distanceToTarget.fuzzySets.Add(new FuzzySet("Far", distanceToTargetSets[2]));

//    ammoStatus.fuzzySets.Add(new FuzzySet("Low", ammoStatusSets[0]));
//    ammoStatus.fuzzySets.Add(new FuzzySet("Okay", ammoStatusSets[1]));
//    ammoStatus.fuzzySets.Add(new FuzzySet("Loads", ammoStatusSets[2]));
//}

//if this fuzzy set is part of a consequent FLV and it is fired by a rule,
//then this method sets the DOM (in this context, the DOM represents a
//confidence level) to the maximum of the parameter value or the set's
//existing m_dDOM value
// ORwithDOM(float val); 

//private void SetupFuzzyRules()
//{
//    rules.Add(new FuzzyRule(FuzzyTerm.AND(distanceToTarget.fuzzySets.Find(x => x.setName == "Close"),
//        ammoStatus.fuzzySets.Find(x => x.setName == "Loads")), desirability.fuzzySets.Find(x => x.setName == "Undersirable")));


//    float i = FuzzyTerm.AND(distanceToTarget.fuzzySets.Find(x => x.setName == "Close"),
//        ammoStatus.fuzzySets.Find(x => x.setName == "Loads"));
//}
