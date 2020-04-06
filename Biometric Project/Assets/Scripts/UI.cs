using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerManager player_manager; 

    [SerializeField] private Text key_value = null;
    [SerializeField] private Text total_keys = null;

    [SerializeField] private Text heart_rate = null; 

    private wrmhlRead data_input;
    private int current_heart_rate; 

    private void Awake()
    {
        //data_input = GameObject.Find("wrmhlRead").GetComponent<wrmhlRead>();
    }

    //private void Update()
    //{
    //    key_value.text = player_manager.m_key_count.ToString();
    //    total_keys.text = player_manager.m_key_total.ToString();

    //    current_heart_rate = int.Parse(data_input.myDevice.readQueue());
    //    heart_rate.text = "Current heart rate: " + current_heart_rate;
    //}
}
