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

        excited.SetsInit(5); 

        excited.Set(low);
        excited.Set(mid_low);
        excited.Set(medium);
        excited.Set(mid_high);
        excited.Set(high); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];
        rules[0] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_low), low);
        rules[1] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_mid_low), low);
        rules[2] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_medium), low);
        rules[3] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_mid_high), low);
        rules[4] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_high), low);

        rules[5] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_low), low);
        rules[6] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_mid_low), low);
        rules[7] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_medium), low);
        rules[8] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_mid_high), mid_low);
        rules[9] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_high), mid_low);

        rules[10] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_low), low);
        rules[11] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_mid_low), low);
        rules[12] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_medium), mid_low);
        rules[13] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_mid_high), mid_low);
        rules[14] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_high), medium);

        rules[15] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_low), low);
        rules[16] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_mid_low), mid_low);
        rules[17] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_medium), mid_low);
        rules[18] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_mid_high), medium);
        rules[19] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_high), mid_high);

        rules[20] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_low), low);
        rules[21] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_mid_low), mid_low);
        rules[22] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_medium), medium);
        rules[23] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_mid_high), mid_high);
        rules[24] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_high), high);

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
