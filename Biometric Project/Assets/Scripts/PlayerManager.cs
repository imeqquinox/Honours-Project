using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private wrmhlRead data_input; 
    public int m_key_count { get; private set; } = 0;
    public int m_key_total { get; private set; } = 5;
    public int current_heartRate { get; private set; } = 0;

    private void Start()
    {
        data_input = GameObject.Find("wrmhlRead").GetComponent<wrmhlRead>(); 
    }

    private void Update()
    {
        current_heartRate = int.Parse(data_input.myDevice.readQueue());
    }

    public void AddKeyCount(int value)
    {
        m_key_count += value; 
    }
}
