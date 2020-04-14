using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScripting : MonoBehaviour
{
    // Required components for dynamic scripting
    private Rulebase rulebase = null;
    public ScriptGeneration script_gen { get; private set; } = null;
    public WeightAdjustment weight_adjustment { get; private set; } = null; 

    public float fitness_value { get; private set; } = 0;

    private int start_heart = 0;
    private int start_valence = 0;
    private int start_EMG = 0; 

    private void Start()
    {
        rulebase = GetComponent<Rulebase>();
        script_gen = GetComponent<ScriptGeneration>();
        weight_adjustment = GetComponent<WeightAdjustment>(); 
    }

    public void StartValues(int heart_input, int valence_input, int EMG_input)
    {
        start_heart = heart_input;
        start_valence = valence_input;
        start_EMG = EMG_input;
    }

    public void RunScript(int heart_input, int valence_input, int EMG_input)
    {
        script_gen.main_script.RunSelectedRules(heart_input, valence_input, EMG_input);
    }

    public bool CheckRuleTrigger()
    {
        bool check_trigger = false;

        for (int i = 0; i < script_gen.main_script.GetRuleCount(); i++)
        {
            if (script_gen.main_script.rules[i].activated)
            {
                check_trigger = true;
                return check_trigger; 
            }
        }

        return check_trigger;
    }

    public void FitnessUpdate(int heart_input, int valence_input, int EMG_input)
    {
        fitness_value = (heart_input - start_heart) / start_heart;
    }
}
