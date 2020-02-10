using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcitedModel : EmotionModel
{
    private FuzzyVariable excited;

    protected override void Start()
    {
        base.Start();

        excited = new FuzzyVariable();

        excited.Set(low);
        excited.Set(mid_low);
        excited.Set(medium);
        excited.Set(mid_high);
        excited.Set(high); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    public void CalculateOutput()
    {
        excited.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(95);
        input.valence.Evaluate(95);

        this.Defuzzify(); 
    }
}
