using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private float rot_speed = 0.10f;
    private float rot_angle = 0f; 

    private void Start()
    {
        rot_angle = Random.Range(5, 45); 
    }

    private void Update()
    {
        transform.Rotate(new Vector3(rot_angle, rot_angle, rot_angle) * rot_speed); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerManager>().AddKeyCount(1);

            Destroy(this.gameObject);
        }
    }
}
