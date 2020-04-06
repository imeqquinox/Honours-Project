using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionOutput : MonoBehaviour
{
    enum Arousal { low, mid_low, medium, mid_high, high }; 
    enum Valence { low, mid_low, medium, mid_high, high }; 

    // Fuzzy variables
    public FuzzyVariable arousal { get; private set; }
    public FuzzyVariable valence { get; private set; }

    // Arousal sets
    public FuzzySet arousal_low { get; private set; }
    public FuzzySet arousal_mid_low { get; private set; }
    public FuzzySet arousal_medium { get; private set; }
    public FuzzySet arousal_mid_high { get; private set; }
    public FuzzySet arousal_high { get; private set; }

    // Valence sets
    public FuzzySet valence_low { get; private set; }
    public FuzzySet valence_mid_low { get; private set; }
    public FuzzySet valence_medium { get; private set; }
    public FuzzySet valence_mid_high { get; private set; }
    public FuzzySet valence_high { get; private set; }

    [SerializeField] private AnimationCurve[] arousal_curve;
    [SerializeField] private AnimationCurve[] valence_curve;

    private void Start()
    {
        arousal_low = new FuzzySet(Arousal.low.ToString(), arousal_curve[0]);
        arousal_mid_low = new FuzzySet(Arousal.mid_low.ToString(), arousal_curve[1]);
        arousal_medium = new FuzzySet(Arousal.medium.ToString(), arousal_curve[2]);
        arousal_mid_high = new FuzzySet(Arousal.mid_high.ToString(), arousal_curve[3]);
        arousal_high = new FuzzySet(Arousal.high.ToString(), arousal_curve[4]);

        valence_low = new FuzzySet(Valence.low.ToString(), valence_curve[0]);
        valence_mid_low = new FuzzySet(Valence.mid_low.ToString(), valence_curve[1]);
        valence_medium = new FuzzySet(Valence.medium.ToString(), valence_curve[2]);
        valence_mid_high = new FuzzySet(Valence.mid_high.ToString(), valence_curve[3]);
        valence_high = new FuzzySet(Valence.high.ToString(), valence_curve[4]);

        arousal = new FuzzyVariable();
        valence = new FuzzyVariable();

        arousal.SetsInit(5);
        valence.SetsInit(5); 

        arousal.Set(arousal_low);
        arousal.Set(arousal_mid_low);
        arousal.Set(arousal_medium);
        arousal.Set(arousal_mid_high);
        arousal.Set(arousal_high);

        valence.Set(valence_low);
        valence.Set(valence_mid_low);
        valence.Set(valence_medium);
        valence.Set(valence_mid_high);
        valence.Set(valence_high); 
    }
}
