using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulebase : MonoBehaviour
{ 
    public int number_rules { get; private set; } = 7;
    private Rule[] rules;

    // Rule condition variables
    private List<System.Func<int, int, bool>> condition = new List<System.Func<int, int, bool>>();

    // Rule actions 
    private List<System.Action> action = new List<System.Action>();

    //private System.Func<int, int, bool> condition1;
    //private System.Func<int, int, bool> condition2;
    //private System.Func<int, int, bool> condition3;
    //private System.Func<int, int, bool> condition4;
    //private System.Func<int, int, bool> condition5;
    //private System.Func<int, int, bool> condition6;
    //private System.Func<int, int, bool> condition7;

    private void Start()
    {
        rules = new Rule[number_rules];

        for (int i = 0; i < rules.Length; i++)
        {
            rules[i] = new Rule();
        }

        // Rule conditions // 
        // Jump scare
        condition[0] = (HR, Val) => HR < 25 && Val > 55;
        // Play eerie sound effect
        condition[1] = (HR, Val) => HR < 50 && Val > 60;
        // Play ambient sound effect
        condition[2] = (HR, Val) => HR < 50 && (Val < 60 && Val > 30);
        // Play scream sound effect
        condition[3] = (HR, Val) => HR > 65 && Val > 65;
        // Play evil laugh sound effect
        condition[4] = (HR, Val) => HR < 50 && Val < 25;
        // Turn lights off
        condition[5] = (HR, Val) => HR < 50 && Val <= 100;
        // Slow player movement
        condition[6] = (HR, Val) => HR > 50 && Val > 60;

        // Rule actions //
        action[0] = JumpScare;
        action[1] = PlayEerie;
        action[2] = PlayAmbient;
        action[3] = PlayScream;
        action[4] = PlayEvilLaugh;
        action[5] = TurnLightsOff;
        action[6] = SlowPlayer; 

        CreateRules();
    }

    // Add rules conditions to individual rules
    private void CreateRules()
    {        
        for (int i = 0; i <rules.Length; i++)
        {
            rules[i].AddCondition(condition[i], action[i]);
        }

        //rules[0].AddCondition(condition1);
        //rules[1].AddCondition(condition2);
        //rules[2].AddCondition(condition3);
        //rules[3].AddCondition(condition4);
        //rules[4].AddCondition(condition5);
        //rules[6].AddCondition(condition6);
        //rules[7].AddCondition(condition7); 
    }

    public Rule GetRule(int value)
    {
        return rules[value];
    }

    // Rules Actions //
    // Jump scare actions
    private void JumpScare()
    {
        Debug.Log("Hello there"); 
    }

    // Play eerie sound effect 
    private void PlayEerie()
    {
        Debug.Log("Hello there");
    }

    // Play ambient sound effect
    private void PlayAmbient()
    {
        Debug.Log("Hello there");
    }

    // Play scream sound effect
    private void PlayScream()
    {
        Debug.Log("Hello there");
    }

    // Play evil laugh sound effect
    private void PlayEvilLaugh()
    {
        Debug.Log("Hello there");
    }

    // Turn lights off
    private void TurnLightsOff()
    {
        Debug.Log("Hello there");
    }

    // Slow player movement
    private void SlowPlayer()
    {
        Debug.Log("Hello there");
    }
}

