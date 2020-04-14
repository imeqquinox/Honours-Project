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

    public void RunSelectedRules(int heart, int valence, int EMG)
    {
        for (int i = 0; i < rules.Count; i++)
        {
            if (rules[i].data_input_type == Rule.DataInputType.HeartRate)
            {
                rules[i].RunCondition(heart);
            }
            else if (rules[i].data_input_type == Rule.DataInputType.Valence)
            {
                rules[i].RunCondition(valence);
            }
            else if (rules[i].data_input_type == Rule.DataInputType.EMG)
            {
                rules[i].RunCondition(EMG);
            }
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
