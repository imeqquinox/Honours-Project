using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    private Camera m_camera; 

    private void Start()
    {
        m_camera = GetComponent<Camera>(); 
    }

    private void Update()
    {
        RaycastHit hit; 

        if (Physics.Raycast(m_camera.transform.position, m_camera.transform.TransformDirection(Vector3.forward), out hit, 1000))
        {
            if (hit.collider.tag == "Door")
            {
                Debug.Log("Door found");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("I'm opening the door");
                    bool is_open = hit.collider.GetComponentInParent<Animator>().GetBool("open");
                    hit.collider.GetComponentInParent<Animator>().SetBool("open", !is_open);
                }
            }
        }
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Vector3 direction = m_camera.transform.TransformDirection(Vector3.forward) * 5;
    //    Gizmos.DrawRay(m_camera.transform.position, direction); 
    //}
}
