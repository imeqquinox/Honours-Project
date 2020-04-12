using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    public int weight { get; private set; } = 5;
    public bool activated { get; private set; } = false;
    public System.Func<int, bool> condition { get; private set; }
    private bool result; 

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
    public void AddCondition(System.Func<int, bool> _condition)
    {
        condition = _condition;
    }

    // Check if the rule is triggered, then run action
    public void RunCondition(int n1)
    {
        result = condition(n1);

        if (result)
        {
            Action();
        }
    }

    public void Action()
    {
        Debug.Log("Action triggered"); 
        // Insert action to be taken
    }
}
