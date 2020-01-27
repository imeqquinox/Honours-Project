using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class UI : MonoBehaviour
{
    [SerializeField] private PlayerManager player_manager; 

    [SerializeField] private Text key_value = null;
    [SerializeField] private Text total_keys = null;

    private void Update()
    {
        key_value.text = player_manager.m_key_count.ToString();
        total_keys.text = player_manager.m_key_total.ToString(); 
    }
}
