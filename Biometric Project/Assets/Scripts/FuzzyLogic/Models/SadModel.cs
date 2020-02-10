﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadModel : EmotionModel
{
    private FuzzyVariable sad; 

    protected override void Start()
    {
        base.Start();

        sad = new FuzzyVariable();

        sad.Set(low);
        sad.Set(mid_low);
        sad.Set(medium);
        sad.Set(mid_high);
        sad.Set(high); 
    }

    protected override FuzzyRule[] GetRules()
    {
        FuzzyRule[] rules = new FuzzyRule[25];

        return rules; 
    }

    public void CalculateOutput()
    {
        sad.ClearDOMs();
        input.arousal.ClearDOMs();
        input.valence.ClearDOMs();

        input.arousal.Evaluate(95);
        input.valence.Evaluate(95);

        this.Defuzzify(); 
    }
}
