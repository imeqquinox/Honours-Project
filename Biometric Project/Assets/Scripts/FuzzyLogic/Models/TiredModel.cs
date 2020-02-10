using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiredModel : EmotionModel
{
    private FuzzyVariable tired;

    protected override void Start()
    {
        base.Start();

        tired = new FuzzyVariable();

        tired.Set(low);
        tired.Set(mid_low);
        tired.Set(medium);
        tired.Set(mid_high);
        tired.Set(high); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    public void CalculateOutput()
    {
        tired.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(95);
        input.valence.Evaluate(95);

        this.Defuzzify();
    }
}
