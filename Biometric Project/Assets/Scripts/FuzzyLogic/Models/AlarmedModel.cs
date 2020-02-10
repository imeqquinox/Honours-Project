using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmedModel : EmotionModel
{
    private FuzzyVariable alarmed;

    protected override void Start()
    {
        base.Start();

        alarmed = new FuzzyVariable(); 

        alarmed.Set(low);
        alarmed.Set(mid_low);
        alarmed.Set(medium);
        alarmed.Set(mid_high);
        alarmed.Set(high);  
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    public void CalculateOutput()
    {
        alarmed.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(95);
        input.valence.Evaluate(95);

        this.Defuzzify(); 
    }
}
