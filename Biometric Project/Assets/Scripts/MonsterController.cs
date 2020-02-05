using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

[RequireComponent(typeof(NavMeshAgent))]
public class MonsterController : MonoBehaviour
{
    [SerializeField] private Transform target = null;
    [SerializeField] private Transform door_ray = null;

    private float rot_speed = 10f; 
    private float look_radius = 10f;
    private NavMeshAgent agent; 

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position); 

        if (distance <= look_radius)
        {
            agent.SetDestination(target.position); 

            if (distance <= agent.stoppingDistance)
            {
                FaceTarget(); 
            }
        }

        //DoorDetection(); 
    }

    // Rotation function towards target
    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion look_rot = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, look_rot, Time.deltaTime * rot_speed); 
    }

    // Cast ray to check if there is a door closed in front
    private void DoorDetection()
    {
        RaycastHit hit;

        if (Physics.Raycast(door_ray.position, door_ray.TransformDirection(Vector3.forward), out hit, look_radius))
        {
            if (hit.collider.tag == "Door")
            {
                Debug.Log("Door found"); 
                agent.isStopped = true; 
            }
            else
            {
                agent.isStopped = false; 
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, look_radius);
    }
}
