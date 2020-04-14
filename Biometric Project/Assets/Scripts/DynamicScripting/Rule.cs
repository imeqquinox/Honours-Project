using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rule : MonoBehaviour
{
    public enum DataInputType
    {
        HeartRate,
        Valence, 
        EMG
    };

    public int weight { get; private set; } = 100;
    public bool activated { get; private set; } = false;
    public System.Func<int, bool> condition { get; private set; }
    public DataInputType data_input_type { get; private set; }
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

    public void SetDataInput(DataInputType input)
    {
        data_input_type = input;
    }

    // Condition adder
    public void AddCondition(System.Func<int, bool> _condition, DataInputType data_input)
    {
        condition = _condition;
        data_input_type = data_input;
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
        activated = true;
        Debug.Log("Action triggered"); 
        // Insert action to be taken
    }
}
