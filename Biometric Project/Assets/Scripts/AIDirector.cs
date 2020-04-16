using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDirector : MonoBehaviour
{
    // AI system toggles
    public bool onFuzzy = false;
    public bool onDynamic = false;

    [SerializeField] private Transform monster_spawn;
    [SerializeField] private GameObject monster_prefab; 

    // Managers
    private PlayerManager player_manager;
    private AudioManager audio_manager;
    private UI ui_display; 

    private bool started = false; 
    private bool monster_spawned = false;

    // Fuzzy outputs
    private FearModel fear_output;
    private ExcitedModel excited_output;
    private CalmModel calm_output;
    private SadModel sad_output;

    // Dynamic scripting
    private DynamicScripting dynamic_scripting; 

    private float rule_timer = 0;

    private void Start()
    {
        GameObject fuzzy = GameObject.Find("Fuzzy Logic Emotional Outputs");
        fear_output = fuzzy.GetComponent<FearModel>();
        excited_output = fuzzy.GetComponent<ExcitedModel>();
        calm_output = fuzzy.GetComponent<CalmModel>();
        sad_output = fuzzy.GetComponent<SadModel>();

        dynamic_scripting = GameObject.Find("Dynamic Scripting").GetComponent<DynamicScripting>();

        player_manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        audio_manager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        ui_display = GameObject.Find("Level UI").GetComponent<UI>(); 
    }

    private void Update()
    {
        GameBasedRules();

        if (onFuzzy) //&& started)
        {
            // Do not activate 
            if (rule_timer > 20)
            {
                FuzzyRules();
                rule_timer = 0; 
            }
        }

        if (onDynamic) //&& started)
        {
            // Do not activate rules for 20 seconds
            if (rule_timer > 20)
            {
                Debug.Log("Started dynamic");
                Dynamic();
                rule_timer = 0; 
            }
        }

        rule_timer += Time.deltaTime; 
        //Debug.Log()
    }

    // General rules to be triggered based off game progress
    private void GameBasedRules()
    {
        // IF keys = 1 THEN spawn monster
        if (player_manager.m_key_count == 1 && !monster_spawned)
        { 
            GameObject.Instantiate(monster_prefab, monster_spawn.position, Quaternion.identity);
            audio_manager.MonsterSpawnClip(); 
            monster_spawned = true; 
        }
    }

    // *NOTE* Both fuzzy and dynamic rule based are the same rules to be tested but with different inputs
    // Fuzzylogic rulebase
    private void FuzzyRules()
    {


        // Jump scare 
        if (fear_output.outcome < 25 && excited_output.outcome < 25)
        {
            ui_display.JumpScare();
            audio_manager.JumpScareScream();
        }

        // Play eerie sound effect 
        if (calm_output.outcome > 50 && sad_output.outcome < 25)
        {

        }

        // Play ambient sound effect 
        if ((calm_output.outcome < 50 && calm_output.outcome > 25) && (sad_output.outcome > 25 && sad_output.outcome < 50))
        {

        }

        // Play scream sound effect 
        if (excited_output.outcome > 70)
        {

        }
        
        // Play evil laugh sound effect 
        if (calm_output.outcome < 25 && sad_output.outcome > 50)
        {

        }

        // Turn lights off 
        if (fear_output.outcome < 20 && excited_output.outcome < 20)
        {

        }

        // Slow player movement 
        if (excited_output.outcome > 50)
        {

        }
    }

    // Dynamicrule base
    private void Dynamic()
    {
        for (int i = 0; i < dynamic_scripting.script_gen.main_script.rules.Count; i++)
        {
            Debug.Log(dynamic_scripting.script_gen.main_script.rules[i].weight);
        }

        dynamic_scripting.StartValues(player_manager.normalized_heartRate, 0);

        float dynamic_timer = 0;
        while (!dynamic_scripting.CheckRuleTrigger() && dynamic_timer < 10)
        {
            // Keep checking for rule until 1 triggers
            dynamic_scripting.RunScript(player_manager.normalized_heartRate, 0);
            
            dynamic_timer += Time.deltaTime;
        }

        // Update fitness value, adjust weights and create new script for next interaction
        dynamic_scripting.FitnessUpdate(player_manager.normalized_heartRate, 0);
        dynamic_scripting.weight_adjustment.WeightAdjust(dynamic_scripting.fitness_value);
        dynamic_scripting.script_gen.CreateScript();
        Debug.Log("Weights updated & new script made"); 

        for (int i = 0; i < dynamic_scripting.script_gen.main_script.rules.Count; i++)
        {
            Debug.Log(dynamic_scripting.script_gen.main_script.rules[i].weight); 
        }
    }
}
