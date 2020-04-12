using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightAdjustment : MonoBehaviour
{
    private ScriptGeneration script_gen = null;
    private Script main_script = null; 

    private int active = 0;

    private void Start()
    {
        script_gen = GetComponent<ScriptGeneration>();
        main_script = script_gen.GetMainScript();
    }

    private void WeightAdjust()
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

        int nonActive = main_script.GetRuleCount() - active;
        // adjustment = CalculateAdjustment(Fitness); 
        // compensation = -active * adjustment/nonActive; 
        // remainder = 0; 
    }

    private void CreditAssignment()
    {
        for (int i = 0; i < main_script.GetRuleCount(); i++)
        {
            if (main_script.GetScriptRules(i).activated)
            {
                // rule[i].weight += adjustment; 
            }
            else
            {
                // rule[i].weight += compensation
            }

            // minWeight
            if (main_script.GetScriptRules(i).weight < 0)
            {
                // remainder = remainder + (rule[i].weight - minWeight); 
                // rule[i].weight = minWeight;
            }
            // maxWeight
            else if (main_script.GetScriptRules(i).weight > 5)
            {
                // remainder = remainder + (rule[i].weight - maxWeight); 
                // rule[i].weight = maxWeight; 
            }
        }

        // DistributeRemainder();
    }
}
