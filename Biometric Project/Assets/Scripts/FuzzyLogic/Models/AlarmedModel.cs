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
        rules[0] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_low), low);
        rules[1] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_mid_low), low);
        rules[2] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_medium), low);
        rules[3] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_mid_high), mid_low);
        rules[4] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_high), medium);

        rules[5] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_low), low);
        rules[6] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_mid_low), low);
        rules[7] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_medium), mid_low);
        rules[8] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_mid_high), medium);
        rules[9] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_high), mid_high);

        rules[10] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_low), low);
        rules[11] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_mid_low), mid_low);
        rules[12] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_medium), medium);
        rules[13] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_mid_high), mid_high);
        rules[14] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_high), high);

        rules[15] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_low), low);
        rules[16] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_mid_low), low);
        rules[17] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_medium), mid_low);
        rules[18] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_mid_high), medium);
        rules[19] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_high), mid_high);

        rules[20] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_low), low);
        rules[21] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_mid_low), low);
        rules[22] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_medium), low);
        rules[23] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_mid_high), mid_low);
        rules[24] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_high), medium);

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
