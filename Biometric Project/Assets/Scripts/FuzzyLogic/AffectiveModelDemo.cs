using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AffectiveModelDemo : MonoBehaviour
{
    [SerializeField] private Button enterBtn;
    [SerializeField] private InputField arousalInput;
    [SerializeField] private InputField valenceInput;
    [SerializeField] private Text outcomeText; 

    enum Arousal { veryLow, low, midLow, midHigh, high, veryHigh };
    enum Valence { veryLow, low, midLow, midHigh, high, veryHigh };
    enum Fun { veryLow, low, medium, high };

    FuzzyVariable arousal;
    FuzzyVariable valence;
    DemoFuzzyVariable fun;

    FuzzySet fun_veryLow;
    FuzzySet fun_low;
    FuzzySet fun_medium;
    FuzzySet fun_high;

    FuzzySet arousal_veryLow;
    FuzzySet arousal_low;
    FuzzySet arousal_midLow;
    FuzzySet arousal_midHigh;
    FuzzySet arousal_high;
    FuzzySet arousal_veryHigh;

    FuzzySet valence_veryLow;
    FuzzySet valence_low;
    FuzzySet valence_midLow;
    FuzzySet valence_midHigh;
    FuzzySet valence_high;
    FuzzySet valence_veryHigh;

    [SerializeField] private AnimationCurve[] arousalCurve;
    [SerializeField] private AnimationCurve[] valenceCurve;
    [SerializeField] private AnimationCurve[] funCurve;

    private FuzzyRule[] rules = new FuzzyRule[10];

    private float outcome = 0;

    private void Start()
    {
        enterBtn.onClick.AddListener(CalculateFun); 

        fun_veryLow = new FuzzySet(Fun.veryLow.ToString(), funCurve[0]);
        fun_low = new FuzzySet(Fun.low.ToString(), funCurve[1]);
        fun_medium = new FuzzySet(Fun.medium.ToString(), funCurve[2]);
        fun_high = new FuzzySet(Fun.high.ToString(), funCurve[3]);

        arousal_veryLow = new FuzzySet(Arousal.veryLow.ToString(), arousalCurve[0]);
        arousal_low = new FuzzySet(Arousal.low.ToString(), arousalCurve[1]);
        arousal_midLow = new FuzzySet(Arousal.midLow.ToString(), arousalCurve[2]);
        arousal_midHigh = new FuzzySet(Arousal.midHigh.ToString(), arousalCurve[3]);
        arousal_high = new FuzzySet(Arousal.high.ToString(), arousalCurve[4]);
        arousal_veryHigh = new FuzzySet(Arousal.veryHigh.ToString(), arousalCurve[5]);

        valence_veryLow = new FuzzySet(Valence.veryLow.ToString(), valenceCurve[0]);
        valence_low = new FuzzySet(Valence.low.ToString(), valenceCurve[1]);
        valence_midLow = new FuzzySet(Valence.midLow.ToString(), valenceCurve[2]);
        valence_midHigh = new FuzzySet(Valence.midHigh.ToString(), valenceCurve[3]);
        valence_high = new FuzzySet(Valence.high.ToString(), valenceCurve[4]);
        valence_veryHigh = new FuzzySet(Valence.veryHigh.ToString(), valenceCurve[5]);

        fun = new DemoFuzzyVariable();
        arousal = new FuzzyVariable();
        valence = new FuzzyVariable();

        fun.Set(fun_veryLow);
        fun.Set(fun_low);
        fun.Set(fun_medium);
        fun.Set(fun_high);

        arousal.Set(arousal_veryLow);
        arousal.Set(arousal_low);
        arousal.Set(arousal_midLow);
        arousal.Set(arousal_midHigh);
        arousal.Set(arousal_high);
        arousal.Set(arousal_veryHigh);

        valence.Set(valence_veryLow);
        valence.Set(valence_low);
        valence.Set(valence_midLow);
        valence.Set(valence_midHigh);
        valence.Set(valence_high);
        valence.Set(valence_veryHigh);
    }

    private FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[10];
        rules[0] = new FuzzyRule(FuzzyTerm.AND(FuzzyTerm.NOT(arousal_veryLow), valence_midHigh), fun_low);
        rules[1] = new FuzzyRule(FuzzyTerm.AND(FuzzyTerm.NOT(arousal_low), valence_midHigh), fun_low);
        rules[2] = new FuzzyRule(FuzzyTerm.AND(FuzzyTerm.NOT(arousal_veryLow), valence_high), fun_medium);
        rules[3] = new FuzzyRule(valence_veryHigh, fun_high);
        rules[4] = new FuzzyRule(valence_veryLow, fun_veryLow);
        rules[5] = new FuzzyRule(valence_low, fun_veryLow);
        rules[6] = new FuzzyRule(FuzzyTerm.AND(arousal_veryLow, valence_midHigh), fun_veryLow);
        rules[7] = new FuzzyRule(FuzzyTerm.AND(arousal_low, valence_high), fun_veryLow);
        rules[8] = new FuzzyRule(FuzzyTerm.AND(arousal_veryLow, valence_high), fun_low);
        rules[9] = new FuzzyRule(valence_midLow, fun_veryLow);

        return rules; 
    }

    private void Defuzzify()
    {
        rules = GetRules(); 

        for (int i = 0; i < rules.Length; i++)
        {
            rules[i].Calculate();
        }

        CalculateMaxAV(); 
    }

    private void CalculateMaxAV()
    {
        float fun_veryLowAV, fun_lowAV, fun_mediumAV, fun_highAV;

        Keyframe[] fun_veryLowKeys = funCurve[0].keys;
        Keyframe[] fun_lowKeys = funCurve[1].keys;
        Keyframe[] fun_mediumKeys = funCurve[2].keys;
        Keyframe[] fun_highKeys = funCurve[3].keys;

        fun_veryLowAV = (fun_veryLowKeys[0].time + fun_veryLowKeys[1].time) / 2;
        fun_lowAV = (fun_lowKeys[1].time + fun_lowKeys[2].time) / 2;
        fun_mediumAV = (fun_mediumKeys[1].time + fun_mediumKeys[2].time) / 2;
        fun_highAV = (fun_highKeys[1].time + fun_highKeys[2].time) / 2; 

        outcome = ((fun_veryLowAV * fun_veryLow.DOM) + (fun_lowAV * fun_low.DOM) + (fun_mediumAV * fun_medium.DOM) + (fun_highAV * fun_high.DOM))
            / (fun_veryLow.DOM + fun_low.DOM + fun_medium.DOM + fun_high.DOM); 
    }
    
    public void CalculateFun()
    {
        fun.ClearDOMS(); 
        arousal.ClearDOMs();
        valence.ClearDOMs();

        arousal.Evaluate(float.Parse(arousalInput.text));
        valence.Evaluate(float.Parse(valenceInput.text));

        Defuzzify(); 
    }

    private void Update()
    {
        outcomeText.text = "Fun percentage: " + outcome.ToString(); 
    }
}
