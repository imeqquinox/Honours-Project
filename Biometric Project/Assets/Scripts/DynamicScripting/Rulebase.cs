using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rulebase : MonoBehaviour
{
    private UI ui_display = null; 
    private AudioManager audio_manager = null;
    private PlayerController player_controller = null; 

    public int number_rules { get; private set; } = 7;
    private Rule[] rules;

    // Rule condition variables
    private List<System.Func<int, int, bool>> condition = new List<System.Func<int, int, bool>>();

    // Rule actions 
    private List<System.Action> action = new List<System.Action>();

    private void Start()
    {
        audio_manager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        ui_display = GameObject.Find("Level UI").GetComponent<UI>();
        player_controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        rules = new Rule[number_rules];

        for (int i = 0; i < rules.Length; i++)
        {
            rules[i] = new Rule();
        }

        // Rule conditions // 
        // Jump scare
        condition.Add((HR, Val) => HR < 25 && Val > 55);
        // Play eerie sound effect
        condition.Add((HR, Val) => HR < 50 && Val > 60);
        // Play ambient sound effect
        condition.Add((HR, Val) => HR < 50 && (Val < 60 && Val > 30));
        // Play scream sound effect
        condition.Add((HR, Val) => HR > 65 && Val > 65);
        // Play evil laugh sound effect
        condition.Add((HR, Val) => HR < 50 && Val < 25);
        // Turn lights off
        condition.Add((HR, Val) => HR < 50 && Val <= 100);
        // Slow player movement
        condition.Add((HR, Val) => HR > 50 && Val > 60);

        // Rule actions //
        action.Add(JumpScare);
        action.Add(PlayEerie);
        action.Add(PlayAmbient);
        action.Add(PlayScream);
        action.Add(PlayEvilLaugh);
        action.Add(TurnLightsOff);
        action.Add(SlowPlayer);

        CreateRules();
    }

    // Add rules conditions to individual rules
    private void CreateRules()
    {
        for (int i = 0; i < rules.Length; i++)
        {
            rules[i].AddCondition(condition[i], action[i]);
        }
    }

    public Rule GetRule(int value)
    {
        return rules[value];
    }

    // Rules Actions //
    // Jump scare actions
    private void JumpScare()
    {
        ui_display.JumpScare();
        audio_manager.JumpScareScream();
    }

    // Play eerie sound effect 
    private void PlayEerie()
    {
        audio_manager.Eerie();
    }

    // Play ambient sound effect
    private void PlayAmbient()
    {
        audio_manager.Ambient();
    }

    // Play scream sound effect
    private void PlayScream()
    {
        audio_manager.JumpScareScream();
    }

    // Play evil laugh sound effect
    private void PlayEvilLaugh()
    {
        audio_manager.EvilLaugh();
    }

    // Turn lights off
    private void TurnLightsOff()
    {
        float time = 0;

        GameObject[] lights = GameObject.FindGameObjectsWithTag("Light");
        foreach (GameObject light in lights)
        {
            light.SetActive(false);
        }

        while (time < 5)
        {
            time += Time.deltaTime;
        }

        foreach (GameObject light in lights)
        {
            light.SetActive(true);
        }
    }

    // Slow player movement
    private void SlowPlayer()
    {
        float time = 0;

        player_controller.SetSpeed(3);

        while (time < 10)
        {
            time += Time.deltaTime;
        }

        player_controller.SetSpeed(6);
    }
}

