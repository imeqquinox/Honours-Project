using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearModel : EmotionModel
{
    private FuzzyVariable fear;

    protected override void Start()
    {
        base.Start();

        fear = new FuzzyVariable();

        fear.Set(low);
        fear.Set(mid_low);
        fear.Set(medium);
        fear.Set(mid_high);
        fear.Set(high); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    public void CalculateOutput()
    {
        fear.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(95);
        input.valence.Evaluate(95);

        this.Defuzzify();
    }
}
