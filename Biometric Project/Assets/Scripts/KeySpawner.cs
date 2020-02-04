using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private GameObject key_prefab; 
    [SerializeField] private PlayerManager player_manager; 
    [SerializeField] private Transform[] key_spawn_points;

    private int last_key_position;
    private GameObject last_key; 

    private void Start()
    {
        // Random starting position
        int key_position = Random.Range(0, key_spawn_points.Length);
        last_key_position = key_position;

        // Spawn key
        last_key = Instantiate(key_prefab, key_spawn_points[key_position]); 
    }

    private void Update()
    {
        // Need another key?
        // Spawn one!
        if (!last_key && player_manager.m_key_count != player_manager.m_key_total)
        {
            int key_position = RandomKey();

            last_key = Instantiate(key_prefab, key_spawn_points[key_position]); 
        }
    }

    // Simple recursion method for making sure next position isn't the same as the last
    private int RandomKey()
    {
        int temp_position = Random.Range(0, key_spawn_points.Length); 

        if (temp_position != last_key_position)
        {
            return temp_position; 
        }

        return RandomKey(); 
    }
}
