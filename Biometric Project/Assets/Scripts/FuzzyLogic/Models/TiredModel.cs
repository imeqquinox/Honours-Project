﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiredModel : EmotionModel
{
    private FuzzyVariable tired;

    protected override void Start()
    {
        base.Start();

        tired = new FuzzyVariable();

        tired.SetsInit(5);

        tired.Set(low);
        tired.Set(mid_low);
        tired.Set(medium);
        tired.Set(mid_high);
        tired.Set(high);

        //CalculateOutput(); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];
        rules[0] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_low), mid_high);
        rules[1] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_mid_low), high);
        rules[2] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_medium), mid_high);
        rules[3] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_mid_high), medium);
        rules[4] = new FuzzyRule(FuzzyTerm.AND(input.valence_low, input.arousal_high), mid_low);

        rules[5] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_low), medium);
        rules[6] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_mid_low), mid_high);
        rules[7] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_medium), medium);
        rules[8] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_mid_high), mid_low);
        rules[9] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_low, input.arousal_high), low);

        rules[10] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_low), mid_low);
        rules[11] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_mid_low), medium);
        rules[12] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_medium), mid_low);
        rules[13] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_mid_high), low);
        rules[14] = new FuzzyRule(FuzzyTerm.AND(input.valence_medium, input.arousal_high), low);

        rules[15] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_low), low);
        rules[16] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_mid_low), mid_low);
        rules[17] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_medium), low);
        rules[18] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_mid_high), low);
        rules[19] = new FuzzyRule(FuzzyTerm.AND(input.valence_mid_high, input.arousal_high), low);

        rules[20] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_low), low);
        rules[21] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_mid_low), low);
        rules[22] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_medium), low);
        rules[23] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_mid_high), low);
        rules[24] = new FuzzyRule(FuzzyTerm.AND(input.valence_high, input.arousal_high), low);

        return rules; 
    }

    public void CalculateOutput()
    {
        tired.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(0);
        input.valence.Evaluate(100);

        this.Defuzzify();
    }
}
