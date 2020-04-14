using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGeneration : MonoBehaviour
{
    private Rulebase rulebase = null;
    public Script main_script { get; private set; } = null;

    private int sum_weights = 0;
    private int numberOfRules;

    private void Start()
    {
        rulebase = GetComponent<Rulebase>();

        main_script = new Script();
        main_script.ClearScript();

        numberOfRules = rulebase.number_rules;

        CreateScript();
    }

    public void CreateScript()
    {
        main_script.ClearScript();

        sum_weights = 0;

        // ruleCount - 1
        for (int i = 0; i < numberOfRules; i++)
        {
            sum_weights += rulebase.GetRule(i).weight; 
        }

        int try_;
        bool ruleAdded;

        // scriptSize - 1
        for (int i = 0; i < 3; i++)
        {
            try_ = 0;
            ruleAdded = false;

            while (try_ < 1 && !ruleAdded)
            {
                int j = 0;
                int sum = 0;
                int selected = -1;
                int fraction = Random.Range(0, sum_weights); 

                while (selected < 0)
                {
                    sum += rulebase.GetRule(j).weight;
                    if (sum > fraction)
                    {
                        selected = j; 
                    }
                    else
                    {
                        j += 1; 
                    }
                }

                ruleAdded = InsertInScript(rulebase.GetRule(selected));
                try_ += 1;
            }
        }

        // Finish Script adds 1 or more rules to ensure the script always finds an action
    }

    private bool InsertInScript(Rule new_rule)
    {
        /*
         * if (rule exists)
         *      return false;
         * else
         *      return true; 
         */
        return main_script.CheckRule(new_rule);
    }

    public Script GetMainScript()
    {
        return main_script; 
    }

    private void Update()
    {
        //Debug.Log(main_script.rules.Count);
        //Debug.Log(main_script.rules[0].condition.Method);
    }
}
