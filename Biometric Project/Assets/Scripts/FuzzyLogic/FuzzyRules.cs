using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyRules : MonoBehaviour
{
    private UI ui_display = null;
    private AudioManager audio_manager = null;
    private PlayerController player_controller = null;

    // Fuzzy outputs
    private FearModel fear_output;
    private ExcitedModel excited_output;
    private CalmModel calm_output;
    private SadModel sad_output;

    private List<int> selection = new List<int>();
    public bool activated { get; private set; } = false;

    private void Start()
    {
        fear_output = GetComponent<FearModel>();
        excited_output = GetComponent<ExcitedModel>();
        calm_output = GetComponent<CalmModel>();
        sad_output = GetComponent<SadModel>();

        audio_manager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
        ui_display = GameObject.Find("Level UI").GetComponent<UI>();
        player_controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public void Rules()
    {
        activated = false;
        selection.Clear();

        // Jump scare 
        if (fear_output.outcome < 25 && excited_output.outcome < 25)
        {
            selection.Add(1); 
        }
        // Play eerie sound effect 
        if (calm_output.outcome > 50 && sad_output.outcome < 25)
        {
            selection.Add(2); 
        }
        // Play ambient sound effect 
        if ((calm_output.outcome < 50 && calm_output.outcome > 25) && (sad_output.outcome > 25 && sad_output.outcome < 50))
        {
            selection.Add(3); 
        }
        // Play scream sound effect 
        if (excited_output.outcome > 70)
        {
            selection.Add(4);
        }
        // Play evil laugh sound effect 
        if (calm_output.outcome < 25 && sad_output.outcome > 50)
        {
            selection.Add(5);
        }
        // Turn lights off 
        if (fear_output.outcome < 20 && excited_output.outcome < 20)
        {
            selection.Add(6);
        }
        // Slow player movement 
        if (excited_output.outcome > 50)
        {
            selection.Add(7);
        }

        // More than 1 
        int choice = Random.Range(0, selection.Count);
        switch (selection[choice])
        {
            case 1:
                JumpScare();
                activated = true;
                break;

            case 2:
                PlayEerie();
                activated = true;
                break;

            case 3:
                PlayAmbient();
                activated = true;
                break;

            case 4:
                PlayScream();
                activated = true;
                break;

            case 5:
                PlayEvilLaugh();
                activated = true;
                break;

            case 6:
                TurnLightsOff();
                activated = true;
                break;

            case 7:
                SlowPlayer();
                activated = true;
                break;

            default:
                break;
        }
    }

    // Rule Actions // 
    // Jump scare
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
        foreach(GameObject light in lights)
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
