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

    private float rule_timer = 0; 

    private void Start()
    {
        GameObject fuzzy = GameObject.Find("Fuzzy Logic Emotional Outputs");
        fear_output = fuzzy.GetComponent<FearModel>();
        excited_output = fuzzy.GetComponent<ExcitedModel>();
        calm_output = fuzzy.GetComponent<CalmModel>();
        sad_output = fuzzy.GetComponent<SadModel>(); 

        player_manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        audio_manager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        ui_display = GameObject.Find("Level UI").GetComponent<UI>(); 
    }

    private void Update()
    {
        GameBasedRules();

        if (onFuzzy && started)
        {
            if (rule_timer > 20)
            {
                FuzzyRules();
                rule_timer = 0; 
            }
        }

        if (onDynamic && started)
        {
            DynamicRules();
        }

        rule_timer += Time.deltaTime; 
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
        // IF fear < 25 AND excited < 25 THEN 
        if (fear_output.outcome < 25 && excited_output.outcome < 25)
        {
            // Jump scare picture
            ui_display.JumpScare();
            audio_manager.JumpScareScream();
        }

        // IF calm > 50 AND excited > 50 THEN 
        if (calm_output.outcome > 75 && excited_output.outcome > 75)
        {
            // Spawn monster for chasing
            GameObject.Instantiate(monster_prefab, monster_spawn.position, Quaternion.identity);
            audio_manager.MonsterSpawnClip();
            monster_spawned = true;
        }

        // IF fear < 75 THEN
        if (fear_output.outcome < 75)
        {
            // Player scary/eerie sound effect
            audio_manager.Eerie();
        }

        // IF monster_spawned = true AND fear < 75 THEN 
        if (monster_spawned && fear_output.outcome < 75)
        {
            // Make monster faster and scarier
        }
    }

    // Dynamicrule base
    private void DynamicRules()
    {

    }

   
}
