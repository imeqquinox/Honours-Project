using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script : MonoBehaviour
{
    public List<Rule> rules { get; private set; } = new List<Rule>();

    public void AddRule(Rule new_rule)
    {
        rules.Add(new_rule);
    }

    public void ClearScript()
    {
        for (int i = 0; i < rules.Count; i++)
        {
            rules[i].SetActivated(false);
        }

        rules.Clear();
    }

    public bool CheckRule(Rule new_rule)
    {
        for (int i = 0; i < rules.Count; i++)
        {
            if (new_rule.condition == rules[i].condition)
            {
                return false;
            }
        }

        rules.Add(new_rule);
        return true;
    }

    public void RunSelectedRules(int heart, int valence)
    {
        //bool rule_triggered = false;

        for (int i = 0; i < rules.Count; i++)
        {
            // If rule has been triggered back out of loop
            //if (rule_triggered)
                //break;

            rules[i].RunCondition(heart, valence);
            //rule_triggered = rules[i].activated; 
        }
    }

    public Rule GetScriptRules(int value)
    {
        return rules[value]; 
    }

    public int GetRuleCount()
    {
        return rules.Count;
    }
}
