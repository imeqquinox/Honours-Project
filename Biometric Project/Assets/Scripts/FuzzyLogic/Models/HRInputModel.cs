using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRInputModel : MonoBehaviour
{
    enum HeartRate { low, medium, high }; 
    enum Arousal { low, mid_low, mid_high, high };

    FuzzyVariable arousal;
    FuzzyVariable heart_rate;

    FuzzySet heartRate_low;
    FuzzySet heartRate_medium;
    FuzzySet heartRate_high;

    FuzzySet arousal_low;
    FuzzySet arousal_midLow;
    FuzzySet arousal_midHigh;
    FuzzySet arousal_high;

    [SerializeField] private AnimationCurve[] arousal_curve;
    [SerializeField] private AnimationCurve[] heartRate_curve;

    private FuzzyRule[] rules = new FuzzyRule[2];

    private float arousal_outcome = 0;
    private void Start()
    {
        heartRate_low = new FuzzySet(HeartRate.low.ToString(), heartRate_curve[0]);
        heartRate_medium = new FuzzySet(HeartRate.medium.ToString(), heartRate_curve[1]);
        heartRate_high = new FuzzySet(HeartRate.high.ToString(), heartRate_curve[2]);

        arousal_low = new FuzzySet(Arousal.low.ToString(), arousal_curve[0]);
        arousal_midLow = new FuzzySet(Arousal.mid_low.ToString(), arousal_curve[1]);
        arousal_midHigh = new FuzzySet(Arousal.mid_high.ToString(), arousal_curve[2]);
        arousal_high = new FuzzySet(Arousal.high.ToString(), arousal_curve[3]);

        heart_rate = new FuzzyVariable();
        arousal = new FuzzyVariable();

        heart_rate.SetsInit(3);
        arousal.SetsInit(4);

        heart_rate.Set(heartRate_low);
        heart_rate.Set(heartRate_medium);
        heart_rate.Set(heartRate_high);

        arousal.Set(arousal_low);
        arousal.Set(arousal_midLow);
        arousal.Set(arousal_midHigh);
        arousal.Set(arousal_high); 
    }

    private FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[2];
        rules[0] = new FuzzyRule(heartRate_low, arousal_low);
        rules[1] = new FuzzyRule(heartRate_medium, arousal_midHigh);
        rules[2] = new FuzzyRule(heartRate_high, arousal_high);

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
        float heartRate_lowAV, heartRate_mediumAV, heartRate_highAV;

        Keyframe[] heartRate_lowKeys = heartRate_curve[0].keys;
        Keyframe[] heartRate_mediumKeys = heartRate_curve[1].keys;
        Keyframe[] heartRate_highKeys = heartRate_curve[2].keys;

        heartRate_lowAV = (heartRate_lowKeys[2].time);
        heartRate_mediumAV = (heartRate_mediumKeys[2].time);
        heartRate_highAV = (heartRate_highKeys[2].time);

        arousal_outcome = ((heartRate_lowAV * heartRate_low.DOM) + (heartRate_mediumAV * heartRate_medium.DOM) + (heartRate_highAV * heartRate_high.DOM))
            / (heartRate_low.DOM + heartRate_medium.DOM + heartRate_high.DOM); 
    }

    public void CalculateHeartRate()
    {
        heart_rate.ClearDOMs();
        arousal.ClearDOMs();

        heart_rate.Evaluate(90);

        Defuzzify(); 
    }
}
