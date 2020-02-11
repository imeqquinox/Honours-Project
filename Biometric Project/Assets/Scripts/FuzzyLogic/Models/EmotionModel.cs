using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionModel : MonoBehaviour
{
    enum Level { low, mid_low, medium, mid_high, high };

    protected EmotionOutput input; 

    protected FuzzySet low;
    protected FuzzySet mid_low;
    protected FuzzySet medium;
    protected FuzzySet mid_high;
    protected FuzzySet high;

    [SerializeField] protected AnimationCurve[] model_curve;

    protected FuzzyRule[] rules = new FuzzyRule[25]; 

    public float outcome { get; protected set; }

    protected virtual void Start()
    {
        input = GetComponent<EmotionOutput>();

        outcome = 0;

        low = new FuzzySet(Level.low.ToString(), model_curve[0]);
        mid_low = new FuzzySet(Level.mid_low.ToString(), model_curve[1]);
        medium = new FuzzySet(Level.medium.ToString(), model_curve[2]);
        mid_high = new FuzzySet(Level.mid_high.ToString(), model_curve[3]);
        high = new FuzzySet(Level.high.ToString(), model_curve[4]);
    }

    protected virtual FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    protected void Defuzzify()
    {
        rules = GetRules(); 

        for (int i = 0; i < rules.Length; i++)
        {
            rules[i].Calculate(); 
        }

        CalculateMaxAV(); 
    }

    protected void CalculateMaxAV()
    {
        float lowAV, midLowAV, mediumAV, midHighAV, highAV;

        Keyframe[] low_keys = model_curve[0].keys;
        Keyframe[] midLow_keys = model_curve[1].keys;
        Keyframe[] medium_keys = model_curve[2].keys;
        Keyframe[] midHigh_keys = model_curve[3].keys;
        Keyframe[] high_keys = model_curve[4].keys;

        lowAV = (low_keys[0].time + low_keys[1].time) / 2;
        midLowAV = (midLow_keys[1].time + midLow_keys[2].time) / 2;
        mediumAV = (medium_keys[1].time + medium_keys[2].time) / 2;
        midHighAV = (midHigh_keys[1].time + midHigh_keys[2].time) / 2;
        highAV = (high_keys[1].time + high_keys[2].time) / 2;

        outcome = ((lowAV * low.DOM) + (midLowAV * mid_low.DOM) + (mediumAV * medium.DOM) + (midHighAV * mid_high.DOM) + (highAV * high.DOM))
            / (low.DOM + mid_low.DOM + medium.DOM + mid_high.DOM + high.DOM);

        //Debug.Log(outcome); 
    }
}
