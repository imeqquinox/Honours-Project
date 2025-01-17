﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuzzyModule : MonoBehaviour
{
    [SerializeField] Button testBtn;
    [SerializeField] InputField distance;
    [SerializeField] InputField ammo;
    [SerializeField] Text outcomeText; 

    enum Desirability { Undersirable, Desirable, VeryDesirable };
    enum DistanceToTarget { Close, Medium, Far };
    enum AmmoStatus { Low, Okay, Loads };

    FuzzyVariable desirability;
    FuzzyVariable distanceToTarget;
    FuzzyVariable ammoStatus;

    FuzzySet undersirable;
    FuzzySet desirable;
    FuzzySet veryDesirable;

    FuzzySet targetClose;
    FuzzySet targetMedium;
    FuzzySet targetFar;

    FuzzySet ammoLow;
    FuzzySet ammoOkay;
    FuzzySet ammoLoads; 

    [SerializeField] private AnimationCurve[] desirabilitySets;
    [SerializeField] private AnimationCurve[] distanceToTargetSets;
    [SerializeField] private AnimationCurve[] ammoStatusSets;

    // List of rules m_Rules; 
    private FuzzyRule[] rules = new FuzzyRule[9];

    float outcome = 0; 

    private void Start()
    {
        testBtn.onClick.AddListener(CalculateDesirability);

        undersirable = new FuzzySet(Desirability.Undersirable.ToString(), desirabilitySets[0]);
        desirable = new FuzzySet(Desirability.Desirable.ToString(), desirabilitySets[1]);
        veryDesirable = new FuzzySet(Desirability.VeryDesirable.ToString(), desirabilitySets[2]);

        targetClose = new FuzzySet(DistanceToTarget.Close.ToString(), distanceToTargetSets[0]);
        targetMedium = new FuzzySet(DistanceToTarget.Medium.ToString(), distanceToTargetSets[1]);
        targetFar = new FuzzySet(DistanceToTarget.Far.ToString(), distanceToTargetSets[2]);

        ammoLow = new FuzzySet(AmmoStatus.Low.ToString(), ammoStatusSets[0]);
        ammoOkay = new FuzzySet(AmmoStatus.Okay.ToString(), ammoStatusSets[1]);
        ammoLoads = new FuzzySet(AmmoStatus.Loads.ToString(), ammoStatusSets[2]);

        desirability = new FuzzyVariable();
        distanceToTarget = new FuzzyVariable();
        ammoStatus = new FuzzyVariable();

        desirability.Set(undersirable);
        desirability.Set(desirable);
        desirability.Set(veryDesirable);

        distanceToTarget.Set(targetClose);
        distanceToTarget.Set(targetMedium);
        distanceToTarget.Set(targetFar);

        ammoStatus.Set(ammoLow);
        ammoStatus.Set(ammoOkay);
        ammoStatus.Set(ammoLoads);
    }

    private FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[9];
        // rules[0] = new FuzzyRule(FuzzyTerm.And(fuzzyVariable1, fuzzyVariable2), outputVar);
        rules[0] = new FuzzyRule(FuzzyTerm.AND(targetClose, ammoLoads), undersirable);
        rules[1] = new FuzzyRule(FuzzyTerm.AND(targetClose, ammoOkay), undersirable);
        rules[2] = new FuzzyRule(FuzzyTerm.AND(targetClose, ammoLow), undersirable);
        rules[3] = new FuzzyRule(FuzzyTerm.AND(targetMedium, ammoLoads), veryDesirable);
        rules[4] = new FuzzyRule(FuzzyTerm.AND(targetMedium, ammoOkay), veryDesirable);
        rules[5] = new FuzzyRule(FuzzyTerm.AND(targetMedium, ammoLow), desirable);
        rules[6] = new FuzzyRule(FuzzyTerm.AND(targetFar, ammoLoads), undersirable);
        rules[7] = new FuzzyRule(FuzzyTerm.AND(targetFar, ammoOkay), undersirable);
        rules[8] = new FuzzyRule(FuzzyTerm.AND(targetFar, ammoLow), undersirable);

        return rules;
    }

    private void Defuzzify()
    {
        // Process rules 
        rules = GetRules();
        for (int i = 0; i < rules.Length; i++)
        {
            rules[i].Calculate();
        }

        //Debug.Log("Undesirable confidence: " + undersirable.DOM);
        //Debug.Log("Desirable confidence: " + desirable.DOM);
        //Debug.Log("Very Desirable confidence " + veryDesirable.DOM);

        // defuzzy MaxAV
        CalculateMaxAV();
    }

    private void CalculateMaxAV()
    {
        float undersirableAV, desirableAV, veryDesirableAV;

        Keyframe[] undersirableKeys = desirabilitySets[0].keys;
        Keyframe[] desirableKeys = desirabilitySets[1].keys;
        Keyframe[] veryDesirableKeys = desirabilitySets[2].keys; 

        undersirableAV = (undersirableKeys[0].time + undersirableKeys[1].time) / 2;
        desirableAV = desirableKeys[1].time;
        veryDesirableAV = (veryDesirableKeys[1].time + veryDesirableKeys[2].time) / 2;

        Debug.Log(undersirableAV);
        Debug.Log(desirableAV);
        Debug.Log(veryDesirableAV);

        outcome = ((undersirableAV * undersirable.DOM) + (desirableAV * desirable.DOM) + (veryDesirableAV * veryDesirable.DOM)) / ((undersirable.DOM + desirable.DOM + veryDesirable.DOM));
    }

    //float distanceVal, float ammoVal
    public void CalculateDesirability()
    {
        desirability.ClearDOMs();
        distanceToTarget.ClearDOMs();
        ammoStatus.ClearDOMs();

        // Fuzzify() basically get the DOM from a fuzzyVariable
        distanceToTarget.Evaluate(float.Parse(distance.text));
        ammoStatus.Evaluate(float.Parse(ammo.text));

        Defuzzify();
    }

    private void Update()
    {
        outcomeText.text = "Outcome: " + outcome.ToString(); 
    }
}



/*private FuzzyVariable GetDesirabilitySet()
    {
        FuzzyVariable variableSet = new FuzzyVariable();
        variableSet.Set(new FuzzySet(Desirability.Undersirable.ToString(), desirabilitySets[0]));
        variableSet.Set(new FuzzySet(Desirability.Desirable.ToString(), desirabilitySets[1]));
        variableSet.Set(new FuzzySet(Desirability.VeryDesirable.ToString(), desirabilitySets[2]));
        return variableSet;
    }

    private FuzzyVariable GetDistanceToTargetSet()
    {
        FuzzyVariable variableSet = new FuzzyVariable();
        variableSet.Set(new FuzzySet(DistanceToTarget.Close.ToString(), distanceToTargetSets[0]));
        variableSet.Set(new FuzzySet(DistanceToTarget.Medium.ToString(), distanceToTargetSets[1]));
        variableSet.Set(new FuzzySet(DistanceToTarget.Far.ToString(), distanceToTargetSets[2]));
        return variableSet;
    }

    private FuzzyVariable GetAmmoStatusSet()
    {
        FuzzyVariable variableSet = new FuzzyVariable();
        variableSet.Set(new FuzzySet(AmmoStatus.Low.ToString(), ammoStatusSets[0]));
        variableSet.Set(new FuzzySet(AmmoStatus.Okay.ToString(), ammoStatusSets[1]));
        variableSet.Set(new FuzzySet(AmmoStatus.Loads.ToString(), ammoStatusSets[2]));
        //set.Set(AmmoStatus.Low, ammoStatusSets[0]);
        //set.Set(AmmoStatus.Okay, ammoStatusSets[1]);
        //set.Set(AmmoStatus.Loads, ammoStatusSets[2]);
        return variableSet;
    }*/
