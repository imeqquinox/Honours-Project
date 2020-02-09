using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadModel : MonoBehaviour
{
    enum Arousal { low, mid_low, medium, mid_high, high }; 
    enum Valence { low, mid_low, medium, mid_high, high }; 
    enum Sad { low, mid_low, medium, mid_high, high };

    FuzzyVariable arousal;
    FuzzyVariable valence;
    FuzzyVariable sad;

    [SerializeField] private AnimationCurve[] arousal_curve;
    [SerializeField] private AnimationCurve[] valence_curve;
    [SerializeField] private AnimationCurve[] sad_curve;

    private FuzzyRule[] rules = new FuzzyRule[25];

    public float outcome { get; private set; }

    private void Start()
    {
        outcome = 0; 


    }
}
