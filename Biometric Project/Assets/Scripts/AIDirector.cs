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

    private PlayerManager player_manager;
    private bool spawned = false; 


    private void Start()
    {
        player_manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>(); 
    }

    private void Update()
    {
        GameBasedRules();

        if (onFuzzy)
        {
            FuzzyRules();
        }

        if (onDynamic)
        {
            DynamicRules();
        }
    }

    // General rules to be triggered based off game progress
    private void GameBasedRules()
    {
        // IF keys = 1 THEN spawn monster
        if (player_manager.m_key_count == 1 && !spawned)
        { 
            GameObject.Instantiate(monster_prefab, monster_spawn.position, Quaternion.identity);
            spawned = true; 
        }
    }

    // *NOTE* Both fuzzy and dynamic rule based are the same rules to be tested but with different inputs
    // Fuzzylogic rulebase
    private void FuzzyRules()
    {

    }

    // Dynamicrule base
    private void DynamicRules()
    {

    }

   
}
