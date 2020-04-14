using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAdjustment : MonoBehaviour
{
    private Rulebase rulebase = null; 
    private ScriptGeneration script_gen = null;
    private Script main_script = null;

    private int minWeight = 0;
    private int maxWeight = 2000; 

    private int active = 0;
    private int nonActive = 0; 
    private int remainder = 0; 
    private int adjustment = 0;
    private int compensation = 0; 

    private void Start()
    {
        rulebase = GetComponent<Rulebase>();
        script_gen = GetComponent<ScriptGeneration>();
        main_script = script_gen.GetMainScript();
    }

    public void WeightAdjust(float fitnessValue)
    {
        active = 0; 

        for (int i = 0; i < main_script.GetRuleCount(); i++)
        {
            if (main_script.GetScriptRules(i).activated)
            {
                active += 1; 
            }
        }

        if (active <= 0 && active >= main_script.GetRuleCount())
        {
            // Return no updates needed
        }

        nonActive = main_script.GetRuleCount() - active;
        adjustment = CalculateAdjustment(fitnessValue); 
        compensation = -active * adjustment/nonActive; 
        remainder = 0; 

        for (int i = 0; i < main_script.GetRuleCount(); i++)
        {
            if (main_script.GetScriptRules(i).activated)
            {
                // rule[i].weight += adjustment; 
                int weightUpdate = rulebase.GetRule(i).weight + adjustment;
                rulebase.GetRule(i).SetWeight(weightUpdate);
            }
            else
            {
                // rule[i].weight += compensation
                int weightUpdate = rulebase.GetRule(i).weight + compensation;
                rulebase.GetRule(i).SetWeight(weightUpdate);
            }

            // minWeight
            if (main_script.GetScriptRules(i).weight < minWeight)
            {
                // remainder = remainder + (rule[i].weight - minWeight); 
                // rule[i].weight = minWeight;
                remainder = remainder + (rulebase.GetRule(i).weight - minWeight);
                rulebase.GetRule(i).SetWeight(minWeight);
            }
            // maxWeight
            else if (main_script.GetScriptRules(i).weight > maxWeight)
            {
                // remainder = remainder + (rule[i].weight - maxWeight); 
                // rule[i].weight = maxWeight; 
                remainder = remainder + (rulebase.GetRule(i).weight - maxWeight);
                rulebase.GetRule(i).SetWeight(maxWeight);
            }
        }

        // DistributeRemainder();
    }

    private int CalculateAdjustment(float fitness)
    {
        float breakEven = 0.3f;
        int Rmax = 100;
        int Pmax = 70; 

        // { F < b } 
        if (fitness < breakEven)
        {
            return (int)-(Pmax * ((breakEven - fitness) / (breakEven)));
        }
        // { F >= b} 
        else if (fitness >= breakEven)
        {
            return (int)(Rmax * ((fitness - breakEven) / (1 - breakEven))); 
        }

        // default
        return 0; 
    }
}
