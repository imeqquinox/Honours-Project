using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalizeHeartRate : MonoBehaviour
{
    private wrmhlRead data_input; 
    
    public int normalizeHeartRate { get; private set; } = 0;
    public int min_heartRate { get; private set; } = 60;
    public int max_heartRate { get; private set; } = 90;
    public int current_heartRate { get; private set; } = 0;

    private void Start()
    {
        data_input = GameObject.Find("wrhmlRead").GetComponent<wrmhlRead>(); 
    }

    private void Update()
    {
        current_heartRate = int.Parse(data_input.myDevice.readQueue());
        
        if (current_heartRate < min_heartRate)
        {
            min_heartRate = current_heartRate; 
        }

        if (current_heartRate > max_heartRate)
        {
            max_heartRate = current_heartRate;
        }
    }

    private void CalculateNormalized()
    {
        normalizeHeartRate = ((current_heartRate - min_heartRate) / (max_heartRate - min_heartRate) * 100); 
    }
}
