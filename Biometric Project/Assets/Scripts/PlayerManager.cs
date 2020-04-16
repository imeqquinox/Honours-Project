using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //private wrmhlRead data_input;
    private NormalizeHeartRate data_input;
    public int m_key_count { get; private set; } = 0;
    public int m_key_total { get; private set; } = 5;

    public int normalized_heartRate { get; private set; } = 0;
    private int min_heartRate = 0;
    private int max_heartRate = 0; 

    private void Start()
    {
        //data_input = GameObject.Find("wrmhlRead").GetComponent<wrmhlRead>(); 
        data_input = GameObject.Find("Normalize Heart Rate").GetComponent<NormalizeHeartRate>(); 
    }

    private void Update()
    {
        //current_heartRate = int.Parse(data_input.myDevice.readQueue());
        normalized_heartRate = data_input.normalizeHeartRate; 
    }

    public void AddKeyCount(int value)
    {
        m_key_count += value; 
    }
}
