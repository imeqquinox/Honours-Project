using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRInputModel : MonoBehaviour
{
    private PlayerManager player_manager; 

    enum HeartRate { low, medium, high }; 
    enum Arousal { low, mid_low, mid_high, high };

    private FuzzyVariable arousal;
    private FuzzyVariable heart_rate;

    private FuzzySet heartRate_low;
    private FuzzySet heartRate_medium;
    private FuzzySet heartRate_high;

    private FuzzySet arousal_low;
    private FuzzySet arousal_midLow;
    private FuzzySet arousal_midHigh;
    private FuzzySet arousal_high;

    [SerializeField] private AnimationCurve[] arousal_curve;
    [SerializeField] private AnimationCurve[] heartRate_curve;

    private FuzzyRule[] rules = new FuzzyRule[3];

    public float outcome { get; private set; }

    private void Start()
    {
        outcome = 0; 

        player_manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>(); 

        arousal_low = new FuzzySet(Arousal.low.ToString(), arousal_curve[0]);
        arousal_midLow = new FuzzySet(Arousal.mid_low.ToString(), arousal_curve[1]);
        arousal_midHigh = new FuzzySet(Arousal.mid_high.ToString(), arousal_curve[2]);
        arousal_high = new FuzzySet(Arousal.high.ToString(), arousal_curve[3]);

        heartRate_low = new FuzzySet(HeartRate.low.ToString(), heartRate_curve[0]);
        heartRate_medium = new FuzzySet(HeartRate.medium.ToString(), heartRate_curve[1]);
        heartRate_high = new FuzzySet(HeartRate.high.ToString(), heartRate_curve[2]);

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
        FuzzyRule[] rules = new FuzzyRule[3];
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
        float arousal_lowAV, arousal_midLowAV, arousal_midHighAV, arousal_highAV;

        Keyframe[] arousal_lowKeys = arousal_curve[0].keys;
        Keyframe[] arousal_midLowKeys = arousal_curve[1].keys;
        Keyframe[] arousal_midHighKeys = arousal_curve[2].keys;
        Keyframe[] arousal_highKeys = arousal_curve[3].keys;

        arousal_lowAV = (arousal_lowKeys[0].time + arousal_lowKeys[1].time) / 2;
        arousal_midLowAV = (arousal_midLowKeys[1].time);
        arousal_midHighAV = (arousal_midHighKeys[1].time);
        arousal_highAV = (arousal_highKeys[0].time + arousal_highKeys[1].time) / 2;

        outcome = ((arousal_lowAV * arousal_low.DOM) + (arousal_midLowAV * arousal_midLow.DOM) + (arousal_midHighAV * arousal_midHigh.DOM) + (arousal_highAV * arousal_high.DOM))
            / (arousal_low.DOM + arousal_midLow.DOM + arousal_midHigh.DOM + arousal_high.DOM); 
    }

    public void CalculateArousal()
    {
        heart_rate.ClearDOMs();
        arousal.ClearDOMs();

        heart_rate.Evaluate(player_manager.current_heartRate);

        Defuzzify(); 
    }
}
