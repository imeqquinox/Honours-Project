using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    public int weight { get; private set; } = 100;
    public bool activated { get; private set; } = false;
    public System.Func<int, int, bool> condition { get; private set; }
    public System.Action action { get; private set; }
    private bool result = false; 

    // Setters
    public void SetWeight(int value)
    {
        weight = value; 
    }

    public void SetActivated(bool value)
    {
        activated = value; 
    }

    // Condition adder
    public void AddCondition(System.Func<int, int, bool> _condition, System.Action _action)
    {
        condition = _condition;
        action = _action; 
    }

    // Check if the rule is triggered, then run action
    public void RunCondition(int HR, int Val)
    {
        result = condition(HR, Val);

        if (result)
        {
            Action();
        }
    }

    public void Action()
    {
        activated = true;
        action.Invoke(); 
        Debug.Log("Action triggered"); 
    }
}
