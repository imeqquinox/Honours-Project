using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UI : MonoBehaviour
{
    [SerializeField] FearModel fear;
    [SerializeField] CalmModel calm;
    [SerializeField] ExcitedModel excited;
    [SerializeField] SadModel sad; 
    [SerializeField] private PlayerManager player_manager;

    [Space(10)]
    [SerializeField] private Text fear_text = null;
    [SerializeField] private Text calm_text = null;
    [SerializeField] private Text excited_text = null;
    [SerializeField] private Text sad_text = null; 

    [Space(10)]
    [SerializeField] private Text key_value = null;
    [SerializeField] private Text total_keys = null;
    [SerializeField] private Text heart_rate = null;

    [Space(10)]
    [SerializeField] private GameObject jumpScare = null;

    private void Start()
    {
        jumpScare.SetActive(false); 
    }

    private void Update()
    {
        fear_text.text = "Fear: " + fear.outcome;
        calm_text.text = "Calm: " + calm.outcome;
        excited_text.text = "Excited: " + excited.outcome;
        sad_text.text = "Sad: " + sad.outcome; 

        key_value.text = player_manager.m_key_count.ToString();
        total_keys.text = player_manager.m_key_total.ToString();
        heart_rate.text = "Current heart rate: " + player_manager.normalized_heartRate.ToString();
    }

    public void JumpScare()
    {
        float time = 0;

        jumpScare.SetActive(true);

        while (time < 2)
        {
            time += Time.deltaTime;
        }

        jumpScare.SetActive(false);
    }
}
