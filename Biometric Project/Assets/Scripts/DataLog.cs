using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataLog : MonoBehaviour
{
    // Data inputs
    private PlayerManager heartRate_input;
    // Add valence

    // Text file paths
    private string heartRate_path = "Assets/Resources/HeartRate.txt";
    private string valence_path = "Assets/Resources/Valence.txt";

    private float heartRate_timer = 0;

    private void Start()
    {
        heartRate_input = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>(); 

        CreateHeartRateFile();
        CreateValenceFile();
    }

    private void Update()
    {
        // Take data reading every 2.5 seconds
        if (heartRate_timer > 2.5)
        {
            HeartRateStream();
            heartRate_timer = 0; 
        }

        heartRate_timer += Time.deltaTime;
    }

    private void CreateHeartRateFile()
    {
        // Create file if it doesn't exist
        if (!File.Exists(heartRate_path))
        {
            File.WriteAllText(heartRate_path, "Heart Rate\n\n"); 
        }
    }

    private void CreateValenceFile()
    {

    }

    private void HeartRateStream()
    {
        string content = heartRate_input.normalized_heartRate + "\n";

        File.AppendAllText(heartRate_path, content); 
    }
}
