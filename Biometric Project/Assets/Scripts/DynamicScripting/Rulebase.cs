﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulebase : MonoBehaviour
{
    public int number_rules { get; private set; } = 5;
    private Rule[] rules;
    
    // rule condition variables
    private System.Func<int, bool> condition1;
    private System.Func<int, bool> condition2;
    private System.Func<int, bool> condition3;
    private System.Func<int, bool> condition4;
    private System.Func<int, bool> condition5; 

    private void Start()
    {
        rules = new Rule[number_rules];

        for (int i = 0; i < rules.Length; i++)
        {
            rules[i] = new Rule();
        }

        // Add rules here
        condition1 = x => x < 25;
        condition2 = x => x > 75;
        condition3 = x => x < 50;
        condition4 = x => x > 80;
        condition5 = x => x < 10; 
        
        CreateRules();
    }

    // Add rules conditions to individual rules
    private void CreateRules()
    {        
        rules[0].AddCondition(condition1);
        rules[1].AddCondition(condition2);
        rules[2].AddCondition(condition3);
        rules[3].AddCondition(condition4);
        rules[4].AddCondition(condition5); 
    }

    // Input parameters are from AI director to run selected rules
    private void RunSelectedRules()
    {
        rules[0].RunCondition(5);
    }

    public Rule GetRule(int value)
    {
        return rules[value];
    }
}
