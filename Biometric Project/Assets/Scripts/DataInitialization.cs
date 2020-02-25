using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DataInitialization : MonoBehaviour
{
    [SerializeField] private Button start_btn;
    [SerializeField] private Text progressTxt; 
    [SerializeField] private Text timerTxt;
    [SerializeField] private Text outputTxt;
    [SerializeField] private Text currentHRTxt; 
    [SerializeField] private wrmhlRead data_input; 

    private List<int> heart_rate_samples = new List<int>();
    private int init_time = 60; // in seconds
    private float time_passed = 0; 
    private float average_heart_rate = 0;
    private int current_heart_rate = 0;
    private bool in_progress = false;

    private void Start()
    {
        start_btn.onClick.AddListener( delegate { StartCoroutine(RecordData()); } ); 
    }

    private void Update()
    {
        if (in_progress)
        {
            progressTxt.text = "Processing";
            progressTxt.color = Color.green; 
        }
        else
        {
            current_heart_rate = int.Parse(data_input.myDevice.readQueue());
            progressTxt.text = "Not processing";
            progressTxt.color = Color.red; 
        }

        timerTxt.text = "Timer: " + time_passed.ToString("F2");
        outputTxt.text = "Average heart rate: " + average_heart_rate;
        currentHRTxt.text = "Current heart rate: " + current_heart_rate;
    }

    private IEnumerator RecordData()
    {
        in_progress = true; 
        time_passed = 0; 

        while (time_passed < init_time)
        {
            time_passed += Time.deltaTime;
            heart_rate_samples.Add(int.Parse(data_input.myDevice.readQueue()));
            current_heart_rate = heart_rate_samples[heart_rate_samples.Count - 1];

            yield return null;
        }

        CalculateAverage(); 
    }

    private void CalculateAverage()
    {
        in_progress = false; 
        int temp = 0; 

        for (int i = 0; i < heart_rate_samples.Count; i++)
        {
            temp += heart_rate_samples[i]; 
        }

        average_heart_rate = temp / heart_rate_samples.Count; 

        Debug.LogWarning("Average heart rate: " + average_heart_rate); 
    }
}
