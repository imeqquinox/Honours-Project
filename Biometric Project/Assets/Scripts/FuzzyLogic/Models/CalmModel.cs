using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalmModel : EmotionModel
{
    private FuzzyVariable calm;

    protected override void Start()
    {
        base.Start();

        calm = new FuzzyVariable();

        calm.Set(low);
        calm.Set(mid_low);
        calm.Set(medium);
        calm.Set(mid_high);
        calm.Set(high); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    public void CalculateOutput()
    {
        calm.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(95);
        input.valence.Evaluate(95);

        this.Defuzzify(); 
    }
}
