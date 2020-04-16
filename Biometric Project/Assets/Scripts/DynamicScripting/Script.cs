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
        for (int i = 0; i < rules.Count; i++)
        {
            rules[i].RunCondition(heart, valence);
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
